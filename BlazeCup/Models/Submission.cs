using BlazeCup.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazeCup.Models
{
    public class Submission
    {
        public List<Group> Groups {get; set;}
        public string SecondRound1 { get; set; }
        public string SecondRound2 { get; set; }
        public string SecondRound3 { get; set; }
        public string SecondRound4 { get; set; }
        public string SecondRound5 { get; set; }
        public string SecondRound6 { get; set; }
        public string SecondRound7 { get; set; }
        public string SecondRound8 { get; set; }
        public string SecondRound9 { get; set; }
        public string SecondRound10 { get; set; }
        public string SecondRound11 { get; set; }
        public string SecondRound12 { get; set; }
        public string SecondRound13 { get; set; }
        public string SecondRound14 { get; set; }
        public string SecondRound15 { get; set; }
        public string SecondRound16 { get; set; }

        public string QuarterFinalist1 { get; set; }
        public string QuarterFinalist2 { get; set; }
        public string QuarterFinalist3 { get; set; }
        public string QuarterFinalist4 { get; set; }
        public string QuarterFinalist5 { get; set; }
        public string QuarterFinalist6 { get; set; }
        public string QuarterFinalist7 { get; set; }
        public string QuarterFinalist8 { get; set; }

        public string SemiFinalist1 { get; set; }
        public string SemiFinalist2 { get; set; }
        public string SemiFinalist3 { get; set; }
        public string SemiFinalist4 { get; set; }

        public string Finalist1 { get; set; }
        public string Finalist2 { get; set; }

        public string Champion { get; set; }
        public string TopScoringTeam { get; set; }
        public string TopScoringPlayerTeam { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public List<string> SecondRounders
        {
            get
            {
                return new List<string>() {
                    SecondRound1, SecondRound2, SecondRound3, SecondRound4, SecondRound5, SecondRound6, SecondRound7, SecondRound8,
                        SecondRound9, SecondRound10, SecondRound11, SecondRound12, SecondRound13, SecondRound14, SecondRound15, SecondRound16 };
            }
        }

        public List<string> QuarterFinalists
        {
            get
            {
                return new List<string>() { QuarterFinalist1, QuarterFinalist2, QuarterFinalist3, QuarterFinalist4, QuarterFinalist5, QuarterFinalist6, QuarterFinalist7, QuarterFinalist8 };
            }
        }

        public List<string> SemiFinalists
        {
            get
            {
                return new List<string>() { SemiFinalist1, SemiFinalist2, SemiFinalist3, SemiFinalist4 };
            }
        }

        public List<string> Finalists
        {
            get
            {
                return new List<string>() { Finalist1, Finalist2 };
            }
        }

        public List<string> ActualSecondRounders { get; set; }
        public List<string> ActualQuarterfinalists { get; set; }
        public List<string> ActualSemifinalists { get; set; }
        public List<string> ActualFinalists { get; set; }
        public string ActualChampion { get; set; }
        public string ActualTopScoringTeam { get; set; }
        public string ActualTopScoringPlayerTeam { get; set; }

        public int Score
        {
            get
            {
                var score = 0;

                foreach (var group in Groups)
                {
                    foreach (var match in group.Matches)
                    {
                        if (match.HomeActualGoals >= 0 && match.AwayActualGoals >= 0)
                        {
                            score += Scoring.ScoreGame(match.HomePredictedGoals, match.AwayPredictedGoals, match.HomeActualGoals, match.AwayActualGoals);
                        }
                    }
                }

                if (ActualSecondRounders != null && ActualSecondRounders.Any())
                {
                    score += Scoring.ScoreSecondRound(SecondRounders, ActualSecondRounders);
                }

                if (ActualQuarterfinalists != null && ActualQuarterfinalists.Any())
                {
                    score += Scoring.ScoreQuarterFinal(QuarterFinalists, ActualQuarterfinalists);
                }

                if (ActualSemifinalists != null && ActualSemifinalists.Any())
                {
                    score += Scoring.ScoreSemiFinal(SemiFinalists, ActualSemifinalists);
                }

                if (ActualFinalists != null && ActualFinalists.Any())
                {
                    score += Scoring.ScoreFinal(Finalists, ActualFinalists);
                }

                if (ActualChampion != null && !string.IsNullOrWhiteSpace(ActualChampion))
                {
                    score += Scoring.ScoreChampion(Champion, ActualChampion);
                }

                if (ActualTopScoringTeam != null && !string.IsNullOrWhiteSpace(ActualTopScoringTeam))
                {
                    score += Scoring.ScoreHighestScoringTeam(TopScoringTeam, ActualTopScoringTeam);
                }

                if (ActualTopScoringPlayerTeam != null && !string.IsNullOrWhiteSpace(ActualTopScoringPlayerTeam))
                {
                    score += Scoring.ScoreHighestScoringPlayer(TopScoringPlayerTeam, ActualTopScoringPlayerTeam);
                }

                return score;
            }            
        }

        public bool Valid()
        {
            if (SecondRounders.Any(entry => String.IsNullOrWhiteSpace(entry)))
            {
                return false;
            }

            if (SecondRounders.GroupBy(n => n).Any(c => c.Count() > 1))
            {
                return false;
            }

            if (QuarterFinalists.Any(entry => String.IsNullOrWhiteSpace(entry)))
            {
                return false;
            }

            if (QuarterFinalists.GroupBy(n => n).Any(c => c.Count() > 1))
            {
                return false;
            }

            if (SemiFinalists.Any(entry => String.IsNullOrWhiteSpace(entry)))
            {
                return false;
            }

            if (SemiFinalists.GroupBy(n => n).Any(c => c.Count() > 1))
            {
                return false;
            }

            if (Finalists.Any(entry => String.IsNullOrWhiteSpace(entry)))
            {
                return false;
            }

            if (Finalists.GroupBy(n => n).Any(c => c.Count() > 1))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Champion))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(TopScoringTeam))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(TopScoringPlayerTeam))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Name))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Email))
            {
                return false;
            }

            try
            {
                var address = new System.Net.Mail.MailAddress(Email);
                return address.Address == Email;
            }
            catch
            {
                return false;
            }
        }
    }
}
