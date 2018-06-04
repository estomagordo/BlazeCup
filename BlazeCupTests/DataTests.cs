using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlazeCup.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace BlazeCupTests
{
    [TestClass]
    public class DataTests
    {
        private static List<Team> _teams;
        private static List<Group> _groups;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            var basePath = @"..\..\..\data\";
            var teamPath = basePath + "teams.json";
            var groupPath = basePath + "groups.json";


            using (var sr = new StreamReader(teamPath))
            {
                var json = sr.ReadToEnd();
                _teams = JsonConvert.DeserializeObject<List<Team>>(json);
            }

            using (var sr = new StreamReader(groupPath))
            {
                var json = sr.ReadToEnd();
                _groups = JsonConvert.DeserializeObject<List<Group>>(json);
            }

            _groups.ForEach(g =>
            {
                g.Teams = new List<Team>();
                g.Matches = new List<Match>();

                g.TeamNames.ForEach(tn =>
                {
                    g.Teams.Add(_teams.First(t => t.Name == tn));
                });

                g.MatchNames.ForEach(mn =>
                {
                    g.Matches.Add(new Match()
                    {
                        Home = _teams.First(t => t.Name == mn[0]),
                        Away = _teams.First(t => t.Name == mn[1])
                    });
                });
            });            

        }

        [TestMethod]
        public void Teams_Count_32()
        {
            var teamCount = _teams.Count;
            var expectedTeamCount = 32;

            Assert.AreEqual(expectedTeamCount, teamCount);
        }

        [TestMethod]
        public void Teams_UniqueCount_32()
        {
            var teamNames = _teams.Select(t => t.Name);
            var uniqueTeamNames = teamNames.ToHashSet();

            var uniqueNameCount = uniqueTeamNames.Count;
            var expectedUniqueTeamCount = 32;

            Assert.AreEqual(expectedUniqueTeamCount, uniqueNameCount);
        }

        [TestMethod]
        public void Groups_Count_8()
        {
            var groupCount = _groups.Count;
            var expectedGroupCount = 8;

            Assert.AreEqual(expectedGroupCount, groupCount); 
        }

        [TestMethod]
        public void Groups_AllTeam_Count_4()
        {
            var expectedTeamCountPerGroup = 4;

            Assert.IsTrue(_groups.All(g => g.Teams.Count == expectedTeamCountPerGroup));
        }

        [TestMethod]
        public void Groups_AllMatchCount_6()
        {
            var expectedMatchCountPerGroup = 6;

            Assert.IsTrue(_groups.All(g => g.Matches.Count == expectedMatchCountPerGroup));
        }

        [TestMethod]
        public void Groups_AllTeams_PlayThreeGames()
        {
            var expectedGamesPerTeam = 3;

            Assert.IsTrue(_groups.All(g =>
            {
                var teamsPlayed = new Dictionary<Team, int>();

                g.Matches.ForEach(m =>
                {
                    if (!teamsPlayed.ContainsKey(m.Home))
                    {
                        teamsPlayed[m.Home] = 0;
                    }
                    if (!teamsPlayed.ContainsKey(m.Away))
                    {
                        teamsPlayed[m.Away] = 0;
                    }

                    teamsPlayed[m.Home]++;
                    teamsPlayed[m.Away]++;
                });

                return teamsPlayed.Values.All(v => v == expectedGamesPerTeam);
            }));
        }

        [TestMethod]
        public void Groups_NoGroup_HasMatchWithNonGroupTeam()
        {
            Assert.IsFalse(_groups.Any(g =>
            {
                return g.Matches.Any(m =>
                {
                    return !g.Teams.Contains(m.Home) || !g.Teams.Contains(m.Away);
                });
            }));
        }

        [TestMethod]
        public void Groups_NoMatch_HappensTwicde()
        {
            var expectedUniqueMatchCountPerGroup = 6;

            Assert.IsTrue(_groups.All(g =>
            {
                var sortedMatchNames = new HashSet<List<string>>();

                g.MatchNames.ForEach(mn =>
                {
                    mn.Sort();
                    sortedMatchNames.Add(mn);
                });

                return sortedMatchNames.Count == expectedUniqueMatchCountPerGroup;
            }));
        }
    }
}
