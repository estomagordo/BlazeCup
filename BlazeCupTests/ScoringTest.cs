using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlazeCup.Logic;
using System.Collections.Generic;

namespace BlazeCupTests
{
    [TestClass]
    public class ScoringTest
    {
        [TestMethod]
        public void ScoringGame_EntirelyWrong_ZeroPoints()
        {
            var expectedHome = 0;
            var expectedAway = 2;
            var actualHome = 1;
            var actualAway = 0;

            var score = Scoring.ScoreGame(expectedHome, expectedAway, actualHome, actualAway);
            var expectedScore = 0;

            Assert.AreEqual(score, expectedScore);
        }

        [TestMethod]
        public void ScoringGame_HomeGoalsRight_OnePoint()
        {
            var expectedHome = 0;
            var expectedAway = 2;
            var actualHome = 0;
            var actualAway = 0;

            var score = Scoring.ScoreGame(expectedHome, expectedAway, actualHome, actualAway);
            var expectedScore = 1;

            Assert.AreEqual(score, expectedScore);
        }

        [TestMethod]
        public void ScoringGame_AwayGoalsRight_OnePoint()
        {
            var expectedHome = 0;
            var expectedAway = 2;
            var actualHome = 2;
            var actualAway = 2;

            var score = Scoring.ScoreGame(expectedHome, expectedAway, actualHome, actualAway);
            var expectedScore = 1;

            Assert.AreEqual(score, expectedScore);
        }

        [TestMethod]
        public void ScoringGame_BothGoalsRight_SixPoints()
        {
            var expectedHome = 0;
            var expectedAway = 2;
            var actualHome = 0;
            var actualAway = 2;

            var score = Scoring.ScoreGame(expectedHome, expectedAway, actualHome, actualAway);
            var expectedScore = 6;

            Assert.AreEqual(score, expectedScore);
        }

        [TestMethod]
        public void ScoringGame_RightSignNoGoalsRight_TwoPoints()
        {
            var expectedHome = 0;
            var expectedAway = 2;
            var actualHome = 1;
            var actualAway = 3;

            var score = Scoring.ScoreGame(expectedHome, expectedAway, actualHome, actualAway);
            var expectedScore = 2;

            Assert.AreEqual(score, expectedScore);
        }

        [TestMethod]
        public void ScoringGame_RightSignOneGoalsRight_ThreePoints()
        {
            var expectedHome = 0;
            var expectedAway = 2;
            var actualHome = 0;
            var actualAway = 1;

            var score = Scoring.ScoreGame(expectedHome, expectedAway, actualHome, actualAway);
            var expectedScore = 3;

            Assert.AreEqual(score, expectedScore);
        }

        [TestMethod]
        public void ScoringSecondRound_NoRight_ZeroPoints()
        {
            var guess = new List<string>() { "Russia", "Saudi Arabia", "Morocco", "Iran", "France", "Peru", "Nigeria", "Iceland",
                "Serbia", "Switzerland", "Mexico", "South Korea", "Tunisia", "Panama", "Senegal", "Poland" };

            var actual = new List<string>() { "Egypt", "Uruguay", "Spain", "Portugal", "Australia", "Denmark", "Argentina", "Croatia",
                "Brazil", "Costa Rica", "Germany", "Sweden", "Belgium", "England", "Colombia", "Japan" };

            var score = Scoring.ScoreSecondRound(guess, actual);
            var expectedScore = 0;

            Assert.AreEqual(score, expectedScore);
        }

        [TestMethod]
        public void ScoringSecondRound_ThreeRight_SixPoints()
        {
            var guess = new List<string>() { "Egypt", "Saudi Arabia", "Morocco", "Iran", "France", "Peru", "Nigeria", "Iceland",
                "Serbia", "Switzerland", "Mexico", "South Korea", "Tunisia", "Panama", "Colombia", "Japan" };

            var actual = new List<string>() { "Egypt", "Uruguay", "Spain", "Portugal", "Australia", "Denmark", "Argentina", "Croatia",
                "Brazil", "Costa Rica", "Germany", "Sweden", "Belgium", "England", "Colombia", "Japan" };

            var score = Scoring.ScoreSecondRound(guess, actual);
            var expectedScore = 6;

            Assert.AreEqual(score, expectedScore);
        }

        [TestMethod]
        public void ScoringSecondRound_AllRight_ThirtytwoPoints()
        {
            var guess = new List<string>() { "Egypt", "Uruguay", "Spain", "Portugal", "Australia", "Denmark", "Argentina", "Croatia",
                "Brazil", "Costa Rica", "Germany", "Sweden", "Belgium", "England", "Colombia", "Japan" };

            var actual = new List<string>() { "Egypt", "Uruguay", "Spain", "Portugal", "Australia", "Denmark", "Argentina", "Croatia",
                "Brazil", "Costa Rica", "Germany", "Sweden", "Belgium", "England", "Colombia", "Japan" };

            var score = Scoring.ScoreSecondRound(guess, actual);
            var expectedScore = 32;

            Assert.AreEqual(score, expectedScore);
        }

        [TestMethod]
        public void ScoringQuarterFinal_NoRight_ZeroPoints()
        {
            var guess = new List<string>() { "Uruguay", "Portugal", "Denmark", "Croatia", "Costa Rica", "Sweden", "England", "Japan" };
            var actual = new List<string>() { "Egypt", "Spain", "Australia", "Argentina", "Brazil", "Germany", "Belgium", "Colombia" };

            var score = Scoring.ScoreQuarterFinal(guess, actual);
            var expectedScore = 0;

            Assert.AreEqual(score, expectedScore);
        }

        [TestMethod]
        public void ScoringQuarterFinal_TwoRight_EightPoints()
        {
            var guess = new List<string>() { "Uruguay", "Portugal", "Denmark", "Croatia", "Costa Rica", "Germany", "England", "Colombia" };
            var actual = new List<string>() { "Egypt", "Spain", "Australia", "Argentina", "Brazil", "Germany", "Belgium", "Colombia" };

            var score = Scoring.ScoreQuarterFinal(guess, actual);
            var expectedScore = 8;

            Assert.AreEqual(score, expectedScore);
        }

        [TestMethod]
        public void ScoringQuarterFinal_AllRight_ThirtytwoPoints()
        {
            var guess = new List<string>() { "Egypt", "Spain", "Australia", "Argentina", "Brazil", "Germany", "Belgium", "Colombia" };
            var actual = new List<string>() { "Egypt", "Spain",  "Australia", "Argentina", "Brazil", "Germany", "Belgium", "Colombia" };

            var score = Scoring.ScoreQuarterFinal(guess, actual);
            var expectedScore = 32;

            Assert.AreEqual(score, expectedScore);
        }

        [TestMethod]
        public void ScoringSemiFinal_NoRight_ZeroPoints()
        {
            var guess = new List<string>() { "Spain", "Argentina", "Germany", "Colombia" };
            var actual = new List<string>() { "Egypt", "Australia", "Brazil", "Belgium" };

            var score = Scoring.ScoreSemiFinal(guess, actual);
            var expectedScore = 0;

            Assert.AreEqual(score, expectedScore);
        }

        [TestMethod]
        public void ScoringSemiFinal_OneRight_SixPoints()
        {
            var guess = new List<string>() { "Egypt", "Argentina", "Germany", "Colombia" };
            var actual = new List<string>() { "Egypt", "Australia", "Brazil", "Belgium" };

            var score = Scoring.ScoreSemiFinal(guess, actual);
            var expectedScore = 6;

            Assert.AreEqual(score, expectedScore);
        }

        [TestMethod]
        public void ScoringSemiFinal_AllRight_TwentyfourPoints()
        {
            var guess = new List<string>() { "Egypt", "Australia", "Brazil", "Belgium" };
            var actual = new List<string>() { "Egypt", "Australia", "Brazil", "Belgium" };

            var score = Scoring.ScoreSemiFinal(guess, actual);
            var expectedScore = 24;

            Assert.AreEqual(score, expectedScore);
        }

        [TestMethod]
        public void ScoringFinal_NoneRight_ZeroPoints()
        {
            var guess = new List<string>() { "Australia", "Brazil" };
            var actual = new List<string>() { "Egypt", "Belgium" };

            var score = Scoring.ScoreFinal(guess, actual);
            var expectedScore = 0;

            Assert.AreEqual(score, expectedScore);
        }

        [TestMethod]
        public void ScoringFinal_OneRight_EightPoints()
        {
            var guess = new List<string>() { "Egypt", "Brazil" };
            var actual = new List<string>() { "Egypt", "Belgium" };

            var score = Scoring.ScoreFinal(guess, actual);
            var expectedScore = 8;

            Assert.AreEqual(score, expectedScore);
        }

        [TestMethod]
        public void ScoringFinal_BothRight_SixteenPoints()
        {
            var guess = new List<string>() { "Egypt", "Belgium" };
            var actual = new List<string>() { "Egypt", "Belgium" };

            var score = Scoring.ScoreFinal(guess, actual);
            var expectedScore = 16;

            Assert.AreEqual(score, expectedScore);
        }

        [TestMethod]
        public void ScoringChampion_Wrong_ZeroPoints()
        {
            var guess = "Belgium";
            var correct = "Egypt";

            var score = Scoring.ScoreChampion(guess, correct);
            var expectedScore = 0;

            Assert.AreEqual(score, expectedScore);
        }

        [TestMethod]
        public void ScoringChampion_Correct_TenPoints()
        {
            var guess = "Egypt";
            var correct = "Egypt";

            var score = Scoring.ScoreChampion(guess, correct);
            var expectedScore = 10;

            Assert.AreEqual(score, expectedScore);
        }

        [TestMethod]
        public void ScoringHighestScoringPlayer_Wrong_ZeroPoints()
        {
            var guess = "Belgium";
            var correct = "Egypt";

            var score = Scoring.ScoreHighestScoringPlayer(guess, correct);
            var expectedScore = 0;

            Assert.AreEqual(score, expectedScore);
        }

        [TestMethod]
        public void ScoringHighestScoringPlayer_Correct_FivePoints()
        {
            var guess = "Egypt";
            var correct = "Egypt";

            var score = Scoring.ScoreHighestScoringPlayer(guess, correct);
            var expectedScore = 5;

            Assert.AreEqual(score, expectedScore);
        }

        [TestMethod]
        public void ScoringHighestScoringTeam_Wrong_ZeroPoints()
        {
            var guess = "Belgium";
            var correct = "Egypt";

            var score = Scoring.ScoreHighestScoringTeam(guess, correct);
            var expectedScore = 0;

            Assert.AreEqual(score, expectedScore);
        }

        [TestMethod]
        public void ScoringHighestScoringTeam_Correct_FivePoints()
        {
            var guess = "Egypt";
            var correct = "Egypt";

            var score = Scoring.ScoreHighestScoringTeam(guess, correct);
            var expectedScore = 5;

            Assert.AreEqual(score, expectedScore);
        }
    }
}
