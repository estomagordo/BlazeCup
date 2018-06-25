using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BlazeCup.Enums.Enums;

namespace BlazeCup.Models
{
    public class Team
    {
        public string Name { get; set; }
        public string FlagUrl { get; set; }
        public TeamStage Stage { get; set; }

        public string SecondRoundColour
        {
            get
            {
                return Stage == TeamStage.Outgroup ?
                    "colour-red" :
                    Stage == TeamStage.Undecided ?
                        string.Empty :
                        "colour-green";
            }
        }

        public string QuarterFinalColour
        {
            get
            {
                return (Stage <= TeamStage.Outgroup && Stage >= TeamStage.Out16) ?
                    "colour-red" :
                    (Stage <= TeamStage.ThroughGroup && Stage >= TeamStage.Undecided) ?
                        string.Empty :
                        "colour-green";
            }
        }

        public string SemiFinalColour
        {
            get
            {
                return (Stage <= TeamStage.Outgroup && Stage >= TeamStage.OutQuarter) ?
                    "colour-red" :
                    (Stage <= TeamStage.Through16 && Stage >= TeamStage.Undecided) ?
                        string.Empty :
                        "colour-green";
            }
        }

        public string FinalColour
        {
            get
            {
                return (Stage <= TeamStage.Outgroup && Stage >= TeamStage.OutSemi) ?
                    "colour-red" :
                    (Stage <= TeamStage.ThroughQuarter && Stage >= TeamStage.Undecided) ?
                        string.Empty :
                        "colour-green";
            }
        }

        public string ChampionColour
        {
            get
            {
                return (Stage <= TeamStage.Outgroup && Stage >= TeamStage.RunnersUp) ?
                    "colour-red" :
                    (Stage <= TeamStage.ThroughSemi && Stage >= TeamStage.Undecided) ?
                        string.Empty :
                        "colour-green";
            }
        }
    }
}
