using BlazeCup.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazeCup.Models
{
    public class Match
    {
        public Team Home { get; set; }
        public Team Away { get; set; }
        public int HomePredictedGoals { get; set; }
        public int AwayPredictedGoals { get; set; }
        public int HomeActualGoals { get; set; }
        public int AwayActualGoals { get; set; }

        public int Points
        {
            get
            {
                if (HomeActualGoals == -1 || AwayActualGoals == -1)
                {
                    return -1;
                }

                return Scoring.ScoreGame(HomePredictedGoals, AwayPredictedGoals, HomeActualGoals, AwayActualGoals);
            }
        }
    }
}
