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
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
    }
}
