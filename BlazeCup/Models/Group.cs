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
    }
}
