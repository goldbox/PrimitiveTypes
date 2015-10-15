using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace PrimitiveTypes
{
    public struct FootballGame
    {
        public string team1;
        public string team2;
        public int scoreTeam1;
        public int scoreTeam2;

        public FootballGame(string team1, string team2, int scoreTeam1, int scoreTeam2)
        {
            this.team1 = team1;
            this.scoreTeam1 = scoreTeam1;
            this.team2 = team2;
            this.scoreTeam2 = scoreTeam2;
        }
    }

    [TestClass]
    public class Football
    {
        [TestMethod]
        public void TestTotalGoals()
        {
            FootballGame[] footballStage = {    new FootballGame("U Cluj", "CFR Cluj", 2, 3),
                                                new FootballGame("Steaua", "Rapid", 3, 1),
                                                new FootballGame("FC Brasov", "Astra Giurgiu", 4, 1),
                                                new FootballGame("FC Viitorul", "FC Botosani", 0, 5),
                                                new FootballGame("Pandurii Targu Jiu", "Dinamo", 1, 4),
                                                new FootballGame("FC Bacau", "ASA Targu Mures", 2, 2),
                                            };
            FootballGame[] lastGame = { new FootballGame("Concordia", "CSM Iasi", 4, 3) };
            footballStage = AddLastGame(footballStage, lastGame);
            int totalGoals = CalculateTotalGoals(footballStage);
            float averageGoalsForThisStage = CalculateAverageGoalsForThisStage(footballStage);
            Assert.AreEqual(35, totalGoals);
        }

        [TestMethod]
        public void TestRemoveWeakestGame()
        {
            FootballGame[] footballStage = {    new FootballGame("U Cluj", "CFR Cluj", 2, 3),
                                                new FootballGame("Steaua", "Rapid", 3, 1),
                                                new FootballGame("FC Brasov", "Astra Giurgiu", 4, 1),
                                                new FootballGame("FC Viitorul", "FC Botosani", 0, 5),
                                                new FootballGame("Pandurii Targu Jiu", "Dinamo", 1, 4),
                                                new FootballGame("FC Bacau", "ASA Targu Mures", 2, 2),
                                            };

            FootballGame[] lastGame = { new FootballGame("Concordia", "CSM Iasi", 4, 30) };
            FootballGame[] footballStageTest = AddLastGame(footballStage, lastGame);
            FootballGame[] weekestFootballGameRemoved = RemoveWeakestGame(footballStageTest);
            CollectionAssert.AreEqual(footballStage, weekestFootballGameRemoved);
            
        }

        [TestMethod]
        public void TestLowestGoalRatio()
        {
            FootballGame[] footballStage = {    new FootballGame("U Cluj", "CFR Cluj", 2, 3),
                                                new FootballGame("Steaua", "Rapid", 3, 1),
                                                new FootballGame("FC Brasov", "Astra Giurgiu", 4, 1),
                                                new FootballGame("FC Viitorul", "FC Botosani", 0, 5),
                                                new FootballGame("Pandurii Targu Jiu", "Dinamo", 1, 4),
                                                new FootballGame("FC Bacau", "ASA Targu Mures", 2, 2),
                                            };
            FootballGame[] lastGame = { new FootballGame("Concordia", "CSM Iasi", 4, 3) };
            footballStage = AddLastGame(footballStage, lastGame);
            string teamWithLowestGoalRatio = CalculateLowestGoalRatio(footballStage);
            Assert.AreEqual("FC Viitorul", teamWithLowestGoalRatio);
        }


        private FootballGame[] AddLastGame(FootballGame[] footballStage, FootballGame[] lastGame)
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
                totalGoals += footballStage[i].scoreTeam1 + footballStage[i].scoreTeam2;
            }
            return totalGoals;
        }

        private int CalculateAverageGoalsForThisStage(FootballGame[] footballStage)
        {
            int totalGoals = CalculateTotalGoals(footballStage);
            return totalGoals / footballStage.Length;
        }

        private FootballGame[] RemoveWeakestGame(FootballGame[] footballStage)
        {
            int gameWithHighestGoalDifference = CalculateGameWithHighestGoalDifference(footballStage);
            int lenghtToCopy = footballStage.Length - gameWithHighestGoalDifference -1;
            Array.ConstrainedCopy(footballStage, gameWithHighestGoalDifference + 1, footballStage, gameWithHighestGoalDifference, lenghtToCopy);
            Array.Resize(ref footballStage, footballStage.Length - 1);

           return footballStage;
        }

        private int CalculateGameWithHighestGoalDifference(FootballGame[] footballStage)
        {
            int highestGoalDifference = 0;
            int gameWithHighestGoalDifference = 0;
            for (int i = 0; i < footballStage.Length; i++)
            {
                int gameGoalDifference = GetGoalDifferenceInAGame(footballStage[i].scoreTeam1, footballStage[i].scoreTeam2);
                if (gameGoalDifference > highestGoalDifference)
                {
                    highestGoalDifference = gameGoalDifference;
                    gameWithHighestGoalDifference = i;
                }
            }
            return gameWithHighestGoalDifference;
        }

        private int GetGoalDifferenceInAGame(int a, int b)
        {
            return (a >= b) ? a - b : b - a;
        }

        private string CalculateLowestGoalRatio(FootballGame[] footballStage)
        {
            string teamWithLowestGameRatio = string.Empty;
            teamWithLowestGameRatio = footballStage[0].team1;
            float lowestGameRatio = GetLowestRatio(footballStage[0].scoreTeam1, footballStage[0].scoreTeam2);
            for (int i = 0; i < footballStage.Length; i++)
            {
                float team1Ratio = GetLowestRatio(footballStage[i].scoreTeam1, footballStage[i].scoreTeam2);
                float team2Ratio = GetLowestRatio(footballStage[i].scoreTeam2, footballStage[i].scoreTeam1);

                if (team1Ratio <= team2Ratio && team1Ratio < lowestGameRatio)
                {
                    lowestGameRatio = team1Ratio;
                    teamWithLowestGameRatio = footballStage[i].team1;
                } else if (team2Ratio < lowestGameRatio)
                {
                    lowestGameRatio = team2Ratio;
                    teamWithLowestGameRatio = footballStage[i].team2;
                }
                
            }

            return teamWithLowestGameRatio;
        }

        private float GetLowestRatio(int scoreTeamA, int scoreTeamB)
        {
            float a = (float) scoreTeamA;
            float b = (float) scoreTeamB;
            return (b == 0) ? a : a / b;
        }
    }
}
