using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    // un sportiv a efectuat mai multe runde de pregătire
    // în prima rundă a efectuat o singură repetiție
    // în a doua rundă a efectuat două repetiții
    // și tot așa până la runda `N` când a ajuns la `N` repetiții
    // după care a început să scadă din nou nr de repetiții, cu câte 1/rundă
    // asta până ce a ajuns din nou la o singură repetiție

    // ajută-l pe sportiv să calculeze câte repetiții a efectuat în total

    [TestClass]
    public class TrainingRounds
    {
        //100 Training Rounds
        [TestMethod]
        public void Test1()
        {
            int trainingRoundN = 5;
            int totalRounds = 25;
            int totalRoundsExpected = TotalRounds(trainingRoundN);
            Assert.AreEqual(totalRoundsExpected, totalRounds);
        }

        //1 Training Round
        [TestMethod]
        public void Test2()
        {
            int trainingRoundN = 1;
            int totalRounds = 1;
            int totalRoundsExpected = TotalRounds(trainingRoundN);
            Assert.AreEqual(totalRoundsExpected, totalRounds);
        }

        //NO Training 
        [TestMethod]
        public void Test3()
        {
            int trainingRoundN = 0;
            int totalRounds = 0;
            int totalRoundsExpected = TotalRounds(trainingRoundN);
            Assert.AreEqual(totalRoundsExpected, totalRounds);
        }

        private int TotalRounds(int trainingRoundN)
        {
            if (trainingRoundN <= 0)
            {
                return 0;
            } else
            {
                int trainingRoundX = 1;
                int totalRounds = 0;
                while (trainingRoundX < trainingRoundN)
                {
                    totalRounds = totalRounds + trainingRoundX;
                    trainingRoundX++;
                }
                totalRounds = totalRounds * 2 + trainingRoundN;
                return totalRounds;
            }
        }
    }
}
