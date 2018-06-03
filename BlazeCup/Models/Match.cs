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
    }
}
