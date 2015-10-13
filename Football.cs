using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace PrimitiveTypes
{
    public struct FootballGame
    {
        private string _team1;
        private string _team2;
        private int _scoreTeam1;
        private int _scoreTeam2;


        public string Team1
        {
            get { return this._team1; }
            set { this._team1 = value; }
        }

        public string Team2
        {
            get { return this._team2; }
            set { this._team2 = value; }
        }

        public int ScoreTeam1
        {
            get { return this._scoreTeam1; }
            set { this._scoreTeam1 = value; }

        }

        public int ScoreTeam2
        {
            get { return this._scoreTeam2; }
            set { this._scoreTeam2 = value; }
        }

        public FootballGame(string team1, string team2, int scoreTeam1, int scoreTeam2)
        {
            this._team1 = team1;
            this._scoreTeam1 = scoreTeam1;
            this._team2 = team2;
            this._scoreTeam2 = scoreTeam2;
        }


    }

    [TestClass]
    public class Football
    {
        [TestMethod]
        public void TestTotalGoals()
        {
            FootballGame[] footballStage = {    new FootballGame("U Cluj", "CFR Cluj", 2, 3),
                                                new FootballGame("Steaua Bucuresti", "Rapid Bucuresti", 3, 1),
                                                new FootballGame("FC Brasov", "Astra Giurgiu", 4, 0),
                                                new FootballGame("FC Viitorul", "FC Botosani", 0, 5),
                                                new FootballGame("Pandurii Targu Jiu", "Dinamo", 1, 4),
                                                new FootballGame("FC Bacau", "ASA Targu Mures", 2, 2),
                                            };
            FootballGame[] lastGame = { new FootballGame("Concordia", "CSM Iasi", 4, 3) };
            footballStage = AddLastGameToThisStage(footballStage, lastGame);
            int totalGoals = CalculateTotalGoals(footballStage);
            float averageGoalsForThisStage = CalculateAverageGoalsForThisStage(footballStage);
            Assert.AreEqual(34, totalGoals);
        }

        [TestMethod]
        public void TestRemoveTheGameWithHighestDifferenceOfGoals()
        {
            FootballGame[] footballStage = {    new FootballGame("U Cluj", "CFR Cluj", 2, 3),
                                                new FootballGame("Steaua Bucuresti", "Rapid Bucuresti", 3, 1),
                                                new FootballGame("FC Brasov", "Astra Giurgiu", 4, 0),
                                                new FootballGame("FC Viitorul", "FC Botosani", 0, 5),
                                                new FootballGame("Pandurii Targu Jiu", "Dinamo", 1, 4),
                                                new FootballGame("FC Bacau", "ASA Targu Mures", 2, 2),
                                            };
            FootballGame[] lastGame = { new FootballGame("Concordia", "CSM Iasi", 4, 3) };
            footballStage = AddLastGameToThisStage(footballStage, lastGame);
            FootballGame[] footballStageWithoutTheGameWithHighestGoalDifference = RemoveGameWithHighestGoalDifference(footballStage);
        }

        [TestMethod]
        public void TestLowestGoalRatio()
        {
            FootballGame[] footballStage = {    new FootballGame("U Cluj", "CFR Cluj", 2, 3),
                                                new FootballGame("Steaua Bucuresti", "Rapid Bucuresti", 3, 1),
                                                new FootballGame("FC Brasov", "Astra Giurgiu", 4, 0),
                                                new FootballGame("FC Viitorul", "FC Botosani", 0, 5),
                                                new FootballGame("Pandurii Targu Jiu", "Dinamo", 1, 4),
                                                new FootballGame("FC Bacau", "ASA Targu Mures", 2, 2),
                                            };
            FootballGame[] lastGame = { new FootballGame("Concordia", "CSM Iasi", 4, 3) };
            footballStage = AddLastGameToThisStage(footballStage, lastGame);
            string teamWithLowestGoalRatio = CalculateLowestGoalRatio(footballStage);
        }

        private FootballGame[] AddLastGameToThisStage(FootballGame[] footballStage, FootballGame[] lastGame)
        {
            Array.Resize(ref footballStage, footballStage.Length + 1);
            lastGame.CopyTo(footballStage, footballStage.Length - 1);
            return footballStage;
        }

        private int CalculateTotalGoals(FootballGame[] footballStage)
        {
            int totalGoals = 0;
            for (int i = 0; i < footballStage.Length; i++)
            {
                totalGoals += footballStage[i].ScoreTeam1 + footballStage[i].ScoreTeam2;
            }
            return totalGoals;
        }

        private int CalculateAverageGoalsForThisStage(FootballGame[] footballStage)
        {
            int totalGoals = CalculateTotalGoals(footballStage);
            return totalGoals / footballStage.Length;
        }

        private FootballGame[] RemoveGameWithHighestGoalDifference(FootballGame[] footballStage)
        {
            int gameWithHighestGoalDifference = CalculateGameWithHighestGoalDifference(footballStage);
            Array.Clear(footballStage, gameWithHighestGoalDifference, 1);

            return footballStage;
        }

        private int CalculateGameWithHighestGoalDifference(FootballGame[] footballStage)
        {
            int highestGoalDifference = 0;
            int gameWithHighestGoalDifference = 0;
            for (int i = 0; i < footballStage.Length; i++)
            {
                int gameGoalDifference = (footballStage[i].ScoreTeam1 >= footballStage[i].ScoreTeam2) ? footballStage[i].ScoreTeam1 - footballStage[i].ScoreTeam2
                                                                                                      : footballStage[i].ScoreTeam2 - footballStage[i].ScoreTeam1;
                if (gameGoalDifference > highestGoalDifference)
                {
                    highestGoalDifference = gameGoalDifference;
                    gameWithHighestGoalDifference = i;
                }
            }
            return gameWithHighestGoalDifference;
        }

        private string CalculateLowestGoalRatio(FootballGame[] footballStage)
        {
            string teamWithLowestGameRatio = string.Empty;
            int[] lowestRatio = new int[] {footballStage[0].ScoreTeam1, footballStage[0].ScoreTeam2};
            teamWithLowestGameRatio = footballStage[0].Team1;
            for (int i = 0; i < footballStage.Length; i++)
            {
                if (lowestRatio[0] > footballStage[i].ScoreTeam1)
                {
                    lowestRatio[0] = footballStage[i].ScoreTeam1;
                    lowestRatio[1] = footballStage[i].ScoreTeam2;
                    teamWithLowestGameRatio = footballStage[i].Team1;
                } else if (lowestRatio[0] == footballStage[i].ScoreTeam1 && lowestRatio[1] < footballStage[i].ScoreTeam1)
                {
                    lowestRatio[1] = footballStage[i].ScoreTeam2;
                    teamWithLowestGameRatio = footballStage[i].Team1;
                }
                if (lowestRatio[0] > footballStage[i].ScoreTeam2)
                {
                    lowestRatio[0] = footballStage[i].ScoreTeam1;
                    lowestRatio[1] = footballStage[i].ScoreTeam1;
                    teamWithLowestGameRatio = footballStage[i].Team2;
                }
                else if (lowestRatio[0] == footballStage[i].ScoreTeam2 && lowestRatio[1] < footballStage[i].ScoreTeam2)
                {
                    lowestRatio[1] = footballStage[i].ScoreTeam1;
                    teamWithLowestGameRatio = footballStage[i].Team2;
                }
                //Working here. NOT FINISHED.
            }

            return teamWithLowestGameRatio;
        }
    }
}
