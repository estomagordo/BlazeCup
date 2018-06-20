using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlazeCup.Models;
using System.Collections.Generic;

namespace BlazeCupTests
{
    [TestClass]
    public class RankingTests
    {
        [TestMethod]
        public void WorldCup1998GroupA_RankedCorrectly()
        {
            var group = new Group();
            group.Teams = new List<Team>()
            {
                new Team() {Name = "Brasilien"},
                new Team() {Name = "Marocko"},
                new Team() {Name = "Norge"},
                new Team() {Name = "Skottland"}
            };
            group.PlayedMatches = new List<List<string>>()
            {
                new List<string>() { "Brasilien", "Skottland", "2", "1" },
                new List<string>() { "Marocko", "Norge", "2", "2" },
                new List<string>() { "Skottland", "Norge", "1", "1" },
                new List<string>() { "Brasilien", "Marocko", "3", "0" },
                new List<string>() { "Skottland", "Marocko", "0", "3" },
                new List<string>() { "Brasilien", "Norge", "1", "2" }
            };

            var ranking = group.Ranking();

            Assert.AreEqual(4, ranking.Count);
            Assert.AreEqual("Brasilien", ranking[0].Name);
            Assert.AreEqual("Norge", ranking[1].Name);
            Assert.AreEqual("Marocko", ranking[2].Name);
            Assert.AreEqual("Skottland", ranking[3].Name);
        }

        [TestMethod]
        public void WorldCup1998GroupB_RankedCorrectly()
        {
            var group = new Group();
            group.Teams = new List<Team>()
            {
                new Team() {Name = "Chile"},
                new Team() {Name = "Italien"},
                new Team() {Name = "Kamerun"},
                new Team() {Name = "Österrike"}
            };
            group.PlayedMatches = new List<List<string>>()
            {
                new List<string>() { "Kamerun", "Österrike", "1", "1" },
                new List<string>() { "Italien", "Chile", "2", "2" },
                new List<string>() { "Chile", "Österrike", "1", "1" },
                new List<string>() { "Italien", "Kamerun", "3", "0" },
                new List<string>() { "Italien", "Österrike", "2", "1" },
                new List<string>() { "Chile", "Kamerun", "1", "1" }
            };

            var ranking = group.Ranking();

            Assert.AreEqual(4, ranking.Count);
            Assert.AreEqual("Italien", ranking[0].Name);
            Assert.AreEqual("Chile", ranking[1].Name);
            Assert.AreEqual("Österrike", ranking[2].Name);
            Assert.AreEqual("Kamerun", ranking[3].Name);
        }

        [TestMethod]
        public void WorldCup1998GroupE_RankedCorrectly()
        {
            var group = new Group();
            group.Teams = new List<Team>()
            {
                new Team() {Name = "Belgien"},
                new Team() {Name = "Mexiko"},
                new Team() {Name = "Nederländerna"},
                new Team() {Name = "Sydkorea"}
            };
            group.PlayedMatches = new List<List<string>>()
            {
                new List<string>() { "Nederländerna", "Belgien", "0", "0" },
                new List<string>() { "Sydkorea", "Mexiko", "1", "3" },
                new List<string>() { "Nederländerna", "Sydkorea", "5", "0" },
                new List<string>() { "Belgien", "Mexiko", "2", "2" },
                new List<string>() { "Belgien", "Sydkorea", "1", "1" },
                new List<string>() { "Nederländerna", "Mexiko", "2", "2" }
            };

            var ranking = group.Ranking();

            Assert.AreEqual(4, ranking.Count);
            Assert.AreEqual("Nederländerna", ranking[0].Name);
            Assert.AreEqual("Mexiko", ranking[1].Name);
            Assert.AreEqual("Belgien", ranking[2].Name);
            Assert.AreEqual("Sydkorea", ranking[3].Name);
        }

        [TestMethod]
        public void WorldCup1998GroupH_RankedCorrectly()
        {
            var group = new Group();
            group.Teams = new List<Team>()
            {
                new Team() {Name = "Argentina"},
                new Team() {Name = "Jamaica"},
                new Team() {Name = "Japan"},
                new Team() {Name = "Kroatien"}
            };
            group.PlayedMatches = new List<List<string>>()
            {
                new List<string>() { "Jamaica", "Kroatien", "1", "3" },
                new List<string>() { "Argentina", "Japan", "1", "0" },
                new List<string>() { "Japan", "Kroatien", "0", "1" },
                new List<string>() { "Argentina", "Jamaica", "5", "0" },
                new List<string>() { "Japan", "Jamaica", "1", "2" },
                new List<string>() { "Argentina", "Kroatien", "1", "0" }
            };

            var ranking = group.Ranking();

            Assert.AreEqual(4, ranking.Count);
            Assert.AreEqual("Argentina", ranking[0].Name);
            Assert.AreEqual("Kroatien", ranking[1].Name);
            Assert.AreEqual("Jamaica", ranking[2].Name);
            Assert.AreEqual("Japan", ranking[3].Name);
        }

        [TestMethod]
        public void WorldCup2002GroupB_RankedCorrectly()
        {
            var group = new Group();
            group.Teams = new List<Team>()
            {
                new Team() {Name = "Paraguay"},
                new Team() {Name = "Slovenien"},
                new Team() {Name = "Spanien"},
                new Team() {Name = "Sydafrika"}
            };
            group.PlayedMatches = new List<List<string>>()
            {
                new List<string>() { "Paraguay", "Sydafrika", "2", "2" },
                new List<string>() { "Spanien", "Slovenien", "2", "2" },
                new List<string>() { "Spanien", "Paraguay", "3", "1" },
                new List<string>() { "Sydafrika", "Slovenien", "1", "0" },
                new List<string>() { "Sydafrika", "Spanien", "2", "3" },
                new List<string>() { "Slovenien", "Paraguay", "1", "3" }
            };

            var ranking = group.Ranking();

            Assert.AreEqual(4, ranking.Count);
            Assert.AreEqual("Spanien", ranking[0].Name);
            Assert.AreEqual("Paraguay", ranking[1].Name);
            Assert.AreEqual("Sydafrika", ranking[2].Name);
            Assert.AreEqual("Slovenien", ranking[3].Name);
        }

        [TestMethod]
        public void Euro2004GroupC_RankedCorrectly()
        {
            var group = new Group();
            group.Teams = new List<Team>()
            {
                new Team() {Name = "Bulgarien"},
                new Team() {Name = "Danmark"},
                new Team() {Name = "Italien"},
                new Team() {Name = "Sverige"}
            };
            group.PlayedMatches = new List<List<string>>()
            {
                new List<string>() { "Danmark", "Italien", "0", "0" },
                new List<string>() { "Sverige", "Bulgarien", "5", "0" },
                new List<string>() { "Bulgarien", "Danmark", "0", "2" },
                new List<string>() { "Italien", "Sverige", "1", "1" },
                new List<string>() { "Italien", "Bulgarien", "2", "1" },
                new List<string>() { "Danmark", "Sverige", "2", "2" }
            };

            var ranking = group.Ranking();

            Assert.AreEqual(4, ranking.Count);
            Assert.AreEqual("Sverige", ranking[0].Name);
            Assert.AreEqual("Danmark", ranking[1].Name);
            Assert.AreEqual("Italien", ranking[2].Name);
            Assert.AreEqual("Bulgarien", ranking[3].Name);
        }

        [TestMethod]
        public void WorldCup2018GroupA_WhoCanQualify_AfterThreePlayed()
        {
            var group = new Group();
            group.Teams = new List<Team>()
            {
                new Team() {Name = "Egypten"},
                new Team() {Name = "Ryssland"},
                new Team() {Name = "Saudiarabien"},
                new Team() {Name = "Uruguay"}
            };
            group.PlayedMatches = new List<List<string>>()
            {
                new List<string>() { "Ryssland", "Saudiarabien", "5", "0" },
                new List<string>() { "Egypten", "Uruguay", "0", "1" },
                new List<string>() { "Ryssland", "Egypten", "3", "1" }
            };

            var egyptColour = group.TeamCanQualify("Egypten");
            var russiaColour = group.TeamCanQualify("Ryssland");
            var saudiArabiaColour = group.TeamCanQualify("Saudiarabien");
            var uruguayColour = group.TeamCanQualify("Uruguay");

            Assert.AreEqual("colour-gold", egyptColour);
            Assert.AreEqual("colour-gold", russiaColour);
            Assert.AreEqual("colour-gold", saudiArabiaColour);
            Assert.AreEqual("colour-gold", uruguayColour);
        }

        [TestMethod]
        public void WorldCup2018GroupA_WhoCanQualify_AfterFourPlayed()
        {
            var group = new Group();
            group.Teams = new List<Team>()
            {
                new Team() {Name = "Egypten"},
                new Team() {Name = "Ryssland"},
                new Team() {Name = "Saudiarabien"},
                new Team() {Name = "Uruguay"}
            };
            group.PlayedMatches = new List<List<string>>()
            {
                new List<string>() { "Ryssland", "Saudiarabien", "5", "0" },
                new List<string>() { "Egypten", "Uruguay", "0", "1" },
                new List<string>() { "Ryssland", "Egypten", "3", "1" },
                new List<string>() { "Uruguay", "Saudiarabien", "1", "0" }
            };

            var egyptColour = group.TeamCanQualify("Egypten");
            var russiaColour = group.TeamCanQualify("Ryssland");
            var saudiArabiaColour = group.TeamCanQualify("Saudiarabien");
            var uruguayColour = group.TeamCanQualify("Uruguay");

            Assert.AreEqual("colour-red", egyptColour);
            Assert.AreEqual("colour-green", russiaColour);
            Assert.AreEqual("colour-red", saudiArabiaColour);
            Assert.AreEqual("colour-green", uruguayColour);
        }
    }
}
