using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    
    [TestClass]
    public class ChessTable
    {
        [TestMethod]
        public void TestForChessTable()
        {
            int lenghtOfSquare = 8;

            Assert.AreEqual(204, CalculateNumberOfSquares(lenghtOfSquare));
        }

        [TestMethod]
        public void TestForZeroSquares()
        {
            int lenghtOfSquare = 0;

            Assert.AreEqual(0, CalculateNumberOfSquares(lenghtOfSquare));
        }

        [TestMethod]
        public void TestForOneSqare()
        {
            int lenghtOfSquare = 1;

            Assert.AreEqual(1, CalculateNumberOfSquares(lenghtOfSquare));
        }

        [TestMethod]
        public void TestFor100()
        {
            int lenghtOfSquare = 100;

            Assert.AreEqual(338350, CalculateNumberOfSquares(lenghtOfSquare));
        }


        private int CalculateNumberOfSquares (int lenghtOfSquare)
        {
            int result = 0;
            for (int i=1; i<=lenghtOfSquare; i++)
            {
                result += i * i;
            }
            return result;
        }
    }
}
