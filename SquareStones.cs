using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class SquareStones
    {
        [TestMethod]
        //All dimensions are higher that 0 and Lenght and Width of the square are higher than Stones.
        public void Test1()
        {
            int squareLenght = 6;
            int squareWidth = 7;
            int stoneSize = 4;
            int totalStonesInput = 4;
            int totalStonesOutput = CalculateStones(squareLenght, squareWidth, stoneSize);

            Assert.AreEqual(totalStonesInput, totalStonesOutput);
        }

        [TestMethod]
        //Square lenght dividing without remainder
        public void Test2_LenghtMultipleOfStoneSize()
        {
            int squareLenght = 8;
            int squareWidth = 7;
            int stoneSize = 4;
            int totalStonesInput = 4;
            int totalStonesOutput = CalculateStones(squareLenght, squareWidth, stoneSize);

            Assert.AreEqual(totalStonesInput, totalStonesOutput);
        }

        [TestMethod]
        //Square Width dividing without remainder
        public void Test3_WidthMultipleOfStoneSize()
        {
            int squareLenght = 8;
            int squareWidth = 8;
            int stoneSize = 4;
            int totalStonesInput = 4;
            int totalStonesOutput = CalculateStones(squareLenght, squareWidth, stoneSize);

            Assert.AreEqual(totalStonesInput, totalStonesOutput);
        }

        [TestMethod]
        //Square lenght is 0 or lower than 0
        public void Test4_LenghtZero()
        {
            int squareLenght = 0;
            int squareWidth = 7;
            int stoneSize = 4;
            int totalStonesInput = 0;
            int totalStonesOutput = CalculateStones(squareLenght, squareWidth, stoneSize);

            Assert.AreEqual(totalStonesInput, totalStonesOutput);
        }

        [TestMethod]
        //Square Width is 0 or lower than 0
        public void Test5_WidthZero()
        {
            int squareLenght = 6;
            int squareWidth = 0;
            int stoneSize = 4;
            int totalStonesInput = 0;
            int totalStonesOutput = CalculateStones(squareLenght, squareWidth, stoneSize);

            Assert.AreEqual(totalStonesInput, totalStonesOutput);
        }

        [TestMethod]
        //Stone size is 0 or lower than 0
        public void Test6_StoneSizeZero()
        {
            int squareLenght = 6;
            int squareWidth = 7;
            int stoneSize = 0;
            int totalStonesInput = 0;
            int totalStonesOutput = CalculateStones(squareLenght, squareWidth, stoneSize);

            Assert.AreEqual(totalStonesInput, totalStonesOutput);
        }

        [TestMethod]
        //Lenght is lower stone size
        public void Test7_LenghtLowerThanStoneSize()
        {
            int squareLenght = 4;
            int squareWidth = 7;
            int stoneSize = 4;
            int totalStonesInput = 3;
            int totalStonesOutput = CalculateStones(squareLenght, squareWidth, stoneSize);

            Assert.AreEqual(totalStonesInput, totalStonesOutput);
        }

        [TestMethod]
        //Width is lower stone size
        public void Test8_WidthLowerThanStoneSize()
        {
            int squareLenght = 6;
            int squareWidth = 2;
            int stoneSize = 4;
            int totalStonesInput = 3;
            int totalStonesOutput = CalculateStones(squareLenght, squareWidth, stoneSize);

            Assert.AreEqual(totalStonesInput, totalStonesOutput);
        }

        private int CalculateStones(int squareLenght, int squareWidth, int stoneSize)
        {
            if (stoneSize <= 0 || squareLenght <= 0 || squareWidth <= 0)
            {
                return 0;
            }
            else
            {
                int squareColumns = squareLenght / stoneSize;
                if (squareLenght % stoneSize > 0)
                {
                    squareColumns++;
                }
                int squareRows = squareWidth / stoneSize;
                if (squareWidth % stoneSize > 0)
                {
                    squareRows++;
                }
                return (squareColumns == 1 || squareRows == 1) ? squareColumns + squareRows : squareColumns * squareRows;
            }


        }
    }
}
