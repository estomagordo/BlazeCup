using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazeCup.Models
{
    public class Group
    {
        public List<Team> Teams { get; set; }
        public List<Match> Matches { get; set; }
    }
}
