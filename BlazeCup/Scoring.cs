using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazeCup
{
    public class Scoring
    {
        private const int _correctGoals = 1;
        private const int _correctResult = 2;
        private const int _correctSign = 2;
        private const int _correctSecondRound = 2;
        private const int _correctQuarterFinal = 4;
        private const int _correctSemiFinal = 6;
        private const int _correctFinal = 8;
        private const int _correctChampion = 10;
        private const int _correctHighestScoringPlayer = 5;
        private const int _correctHighestScoringTeam = 5;

        public static int ScoreGame(int expectedHome, int expectedAway, int actualHome, int actualAway)
        {
            var score = 0;
            
            if (expectedHome == actualHome)
            {
                score += _correctGoals;
            }

            if (expectedAway == actualAway)
            {
                score += _correctGoals;
            }

            if (score == _correctGoals * 2)
            {
                score += _correctResult;
            }

            var expectedSign = expectedHome > expectedAway ?
                '1' :
                expectedHome == expectedAway ?
                'X' :
                '2';

            var actualSign = actualHome > actualAway ?
                '1' :
                actualHome == actualAway ?
                'X' :
                '2';

            if (expectedSign == actualSign)
            {
                score += _correctSign;
            }

            return score;
        }

        public int ScoreSecondRound(IList<string> guesses, IList<string> actual)
        {
            return guesses.Where(g => actual.Contains(g)).Count() * _correctSecondRound;
        }

        public int ScoreQuarterFinal(IList<string> guesses, IList<string> actual)
        {
            return guesses.Where(g => actual.Contains(g)).Count() * _correctQuarterFinal;
        }

        public int ScoreSemiFinal(IList<string> guesses, IList<string> actual)
        {
            return guesses.Where(g => actual.Contains(g)).Count() * _correctSemiFinal;
        }

        public int ScoreFinal(IList<string> guesses, IList<string> actual)
        {
            return guesses.Where(g => actual.Contains(g)).Count() * _correctFinal;
        }

        public int ScoreChampion(string guess, string actual)
        {
            if (guess == actual)
            {
                return _correctChampion;
            }

            return 0;
        }

        public int ScoreHighestScoringPlayer(string guess, string actual)
        {
            if (guess == actual)
            {
                return _correctHighestScoringPlayer;
            }

            return 0;
        }

        public int ScoreHighestScoringTeam(string guess, string actual)
        {
            if (guess == actual)
            {
                return _correctHighestScoringTeam;
            }

            return 0;
        }
    }
}
