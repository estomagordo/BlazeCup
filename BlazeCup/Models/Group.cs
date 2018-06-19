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

        public List<Team> Ranking
        {
            get
            {
                var pointWeight = 1000000;
                var goalDifferenceWeight = 1000;
                var goalsForWeight = 1;

                var points = new Dictionary<Team, int>();
                Teams.ForEach(t => points[t] = 0);

                PlayedMatches.ForEach(pm =>
                {
                    var home = Teams.First(t => t.Name == pm[0]);
                    var away = Teams.First(t => t.Name == pm[1]);
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
                });

                var rankedTeams = points.Select(p => p.Key).OrderBy(t => -points[t]).ToList();

                if (points[rankedTeams[0]] == points[rankedTeams[1]])
                {
                    if (points[rankedTeams[1]] == points[rankedTeams[2]])
                    {
                        if (points[rankedTeams[2]] == points[rankedTeams[3]])
                        {
                            return rankedTeams;
                        }

                        var rerankedTeams = RankAggregate(rankedTeams.Take(3).ToList());
                        rerankedTeams.Add(rankedTeams[3]);

                        return rerankedTeams;
                    }

                    var topTeams = RankAggregate(rankedTeams.Take(2).ToList());

                    if (points[rankedTeams[2]] == points[rankedTeams[3]])
                    {                        
                        var bottomTeams = RankAggregate(rankedTeams.Skip(2).ToList());
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
                        top.AddRange(RankAggregate(rankedTeams.Skip(1).ToList()));

                        return top;
                    }

                    top.AddRange(rankedTeams.Skip(1).Take(2).ToList());
                    top.Add(rankedTeams[3]);

                    return top;
                }

                if (points[rankedTeams[2]] == points[rankedTeams[3]])
                {
                    var top = rankedTeams.Take(2).ToList();
                    top.AddRange(RankAggregate(rankedTeams.Skip(2).ToList()));

                    return top;
                }

                return rankedTeams;
            }
        }

        private List<Team> RankAggregate(List<Team> teams)
        {
            // TODO: Implement
            return teams;
        }
    }
}
