using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazeCup.Models
{
    public class Group
    {
        public String Name { get; set; }
        public List<string> TeamNames { get; set; }
        public List<Team> Teams { get; set; }
        public List<List<string>> MatchNames { get; set; }
        public List<Match> Matches { get; set; }
        public List<List<string>> PlayedMatches { get; set; }

        public List<Team> Ranking()
        {            
            (var rankedTeams, var points) = RankStraight(Teams, PlayedMatches);

            if (points[rankedTeams[0]] == points[rankedTeams[1]])
            {
                if (points[rankedTeams[1]] == points[rankedTeams[2]])
                {
                    if (points[rankedTeams[2]] == points[rankedTeams[3]])
                    {
                        return rankedTeams;
                    }

                    var rerankedTeams = RankAggregate(rankedTeams.Take(3).ToList(), PlayedMatches);
                    rerankedTeams.Add(rankedTeams[3]);

                    return rerankedTeams;
                }

                var topTeams = RankAggregate(rankedTeams.Take(2).ToList(), PlayedMatches);

                if (points[rankedTeams[2]] == points[rankedTeams[3]])
                {                        
                    var bottomTeams = RankAggregate(rankedTeams.Skip(2).ToList(), PlayedMatches);
                    topTeams.AddRange(bottomTeams);

                    return topTeams;
                }

                topTeams.AddRange(rankedTeams.Skip(2));

                return topTeams;
            }

            if (points[rankedTeams[1]] == points[rankedTeams[2]])
            {
                var top = rankedTeams.Take(1).ToList();

                if (points[rankedTeams[2]] == points[rankedTeams[3]])
                {
                    top.AddRange(RankAggregate(rankedTeams.Skip(1).ToList(), PlayedMatches));

                    return top;
                }

                top.AddRange(rankedTeams.Skip(1).Take(2).ToList());
                top.Add(rankedTeams[3]);

                return top;
            }

            if (points[rankedTeams[2]] == points[rankedTeams[3]])
            {
                var top = rankedTeams.Take(2).ToList();
                top.AddRange(RankAggregate(rankedTeams.Skip(2).ToList(), PlayedMatches));

                return top;
            }

            return rankedTeams;
        }

        public string TeamCanQualify(string teamName)
        {
            if (PlayedMatches.Count == 6)
            {
                var ranking = Ranking();

                if (ranking[0].Name == teamName || ranking[1].Name == teamName)
                {
                    return "colour-green";
                }

                return "colour-red";
            }

            var playedCount = PlayedMatches.Count(pm => pm[0] == teamName || pm[1] == teamName);

            if (playedCount < 2)
            {
                return "colour-gold";//string.Empty;
            }

            var resultsToTest = new List<List<string>>() {
                new List<string>() { "0", "0" },
                new List<string>() { "1", "1" },
                new List<string>() { "20", "20" },
                new List<string>() { "60", "60" },
                new List<string>() { "1", "0" },
                new List<string>() { "25", "24" },
                new List<string>() { "200", "199" },
                new List<string>() { "70", "0" },
                new List<string>() { "1900", "0" },
                new List<string>() { "0", "1" },
                new List<string>() { "24", "25" },
                new List<string>() { "199", "200" },
                new List<string>() { "0", "70" },
                new List<string>() { "0", "1900" }
            };

            var possibleFinishes = new HashSet<int>();

            var remainingMatchups = new List<List<string>>();

            for (var i = 0; i < 3; i++)
            {
                for (var j = i + 1; j < 4; j++)
                {
                    var firstName = Teams[i].Name;
                    var secondName = Teams[j].Name;
                    var played = false;

                    PlayedMatches.ForEach(pm =>
                    {
                        if ((pm[0] == firstName && pm[1] == secondName) || (pm[1] == firstName && pm[0] == secondName))
                        {
                            played = true;
                        }
                    });

                    if (!played)
                    {
                        remainingMatchups.Add(new List<string>() { firstName, secondName });
                    }
                }
            }

            var combinationCount = 1;

            for (var i = 0; i < remainingMatchups.Count; i++)
            {
                combinationCount *= resultsToTest.Count;
            }

            for (var i = 0; i < combinationCount; i++)
            {
                var possiblePlayedMatches = new List<List<string>>(PlayedMatches);

                for (var j = 0; j < remainingMatchups.Count; j++)
                {
                    var m = 1;

                    for (var k = 0; k < j; k++)
                    {
                        m *= resultsToTest.Count;
                    }

                    var matchup = remainingMatchups[j];
                    var finish = resultsToTest[(i / m) % resultsToTest.Count];

                    possiblePlayedMatches.Add(new List<string>() { matchup[0], matchup[1], finish[0], finish[1] });
                }

                var ranking = RankStraight(Teams, possiblePlayedMatches).rankedTeams;

                for (var n = 0; n < 4; n++)
                {
                    if (ranking[n].Name == teamName)
                    {
                        possibleFinishes.Add(n);
                    }
                }
            }

            if (!possibleFinishes.Contains(2) && !possibleFinishes.Contains(3))
            {
                return "colour-green";
            }

            if (!possibleFinishes.Contains(0) && !possibleFinishes.Contains(1))
            {
                return "colour-red";
            }

            //remainingMatchups.ForEach(rm =>
            //{

            //});

            //var outcomes = remainingMatchups.SelectMany(matchup => resultsToTest, (matchup, resultToTest) => new { matchup, resultToTest }).ToList();

            //outcomes.ForEach(outcome =>
            //{
            //    var possiblePlayedMatches = new List<List<string>>(PlayedMatches);
            //    possiblePlayedMatches.AddRange(outcome.
            //});

            return "colour-gold";//string.Empty;
        }

        private (List<Team> rankedTeams, Dictionary<Team, int> points) RankStraight(List<Team> teams, List<List<string>> playedMatches)
        {
            var pointWeight = 10000000;
            var goalDifferenceWeight = 1000;
            var goalsForWeight = 1;

            var points = new Dictionary<Team, int>();
            Teams.ForEach(t => points[t] = 0);

            playedMatches.ForEach(pm =>
            {
                var home = teams.FirstOrDefault(t => t.Name == pm[0]);
                var away = teams.FirstOrDefault(t => t.Name == pm[1]);

                if (home != null && away != null)
                {
                    var homeGoals = int.Parse(pm[2]);
                    var awayGoals = int.Parse(pm[3]);

                    points[home] += homeGoals * goalsForWeight;
                    points[away] += awayGoals * goalsForWeight;

                    points[home] += (homeGoals - awayGoals) * goalDifferenceWeight;
                    points[away] += (awayGoals - homeGoals) * goalDifferenceWeight;

                    if (homeGoals > awayGoals)
                    {
                        points[home] += 3 * pointWeight;
                    }
                    else if (homeGoals == awayGoals)
                    {
                        points[home] += pointWeight;
                        points[away] += pointWeight;
                    }
                    else
                    {
                        points[away] += 3 * pointWeight;
                    }
                }                
            });

            return (points.Select(p => p.Key).OrderBy(t => -points[t]).ToList(), points);
        }

        private List<Team> RankAggregate(List<Team> teams, List<List<string>> playedMatches)
        {
            return RankStraight(teams, playedMatches).rankedTeams;
        }
    }
}
