using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class Mushrooms
    {
        [TestMethod]
        public void Test1()
        {
            int nMushrooms = 24;
            int xTimes = 5;

            string whiteAndRed = "4" + " and " + "20";

            int whiteMushroomsExpected = CalculateWhiteMushrooms(nMushrooms, xTimes);
            int redMushroomsExpected = CalculateRedMushrooms(whiteMushroomsExpected, xTimes);
            string whiteAndRedExpected = whiteMushroomsExpected + " and " + redMushroomsExpected;
            Assert.AreEqual(whiteAndRedExpected, whiteAndRed);
        }

        [TestMethod]
        //Wrong input Mushroom Numbers
        public void Test2()
        {
            int nMushrooms = 27;
            int xTimes = 5;

            string whiteAndRed = "0" + " and " + "0";

            int whiteMushroomsExpected = CalculateWhiteMushrooms(nMushrooms, xTimes);
            int redMushroomsExpected = CalculateRedMushrooms(whiteMushroomsExpected, xTimes);
            string whiteAndRedExpected = whiteMushroomsExpected + " and " + redMushroomsExpected;
            Assert.AreEqual(whiteAndRedExpected, whiteAndRed);
        }

        [TestMethod]
        //Wrong input X times Number 
        public void Test3()
        {
            int nMushrooms = 24;
            int xTimes = 13;

            string whiteAndRed = "0" + " and " + "0";

            int whiteMushroomsExpected = CalculateWhiteMushrooms(nMushrooms, xTimes);
            int redMushroomsExpected = CalculateRedMushrooms(whiteMushroomsExpected, xTimes);
            string whiteAndRedExpected = whiteMushroomsExpected + " and " + redMushroomsExpected;
            Assert.AreEqual(whiteAndRedExpected, whiteAndRed);
        }

        [TestMethod]
        //X times is 0. => NO red mushrooms
        public void Test4()
        {
            int nMushrooms = 24;
            int xTimes = 0;

            string whiteAndRed = "24" + " and " + "0";

            int whiteMushroomsExpected = CalculateWhiteMushrooms(nMushrooms, xTimes);
            int redMushroomsExpected = CalculateRedMushrooms(whiteMushroomsExpected, xTimes);
            string whiteAndRedExpected = whiteMushroomsExpected + " and " + redMushroomsExpected;
            Assert.AreEqual(whiteAndRedExpected, whiteAndRed);
        }

        [TestMethod]
        //X times is 1. => whites = reds
        public void Test5()
        {
            int nMushrooms = 24;
            int xTimes = 1;

            string whiteAndRed = "12" + " and " + "12";

            int whiteMushroomsExpected = CalculateWhiteMushrooms(nMushrooms, xTimes);
            int redMushroomsExpected = CalculateRedMushrooms(whiteMushroomsExpected, xTimes);
            string whiteAndRedExpected = whiteMushroomsExpected + " and " + redMushroomsExpected;
            Assert.AreEqual(whiteAndRedExpected, whiteAndRed);
        }


        private int CalculateWhiteMushrooms (int nMushrooms, int xTimes)
        {
            if (nMushrooms <= 0)
            {
                return 0;
            } else
            {
                if (xTimes == 0)
                {
                    return nMushrooms;
                } else
                {
                    xTimes++;
                    if (nMushrooms % xTimes == 0)
                    {
                        return nMushrooms / xTimes;
                    } else
                    {
                        return 0;
                    }

                }
            }
            
                
       }

        private int CalculateRedMushrooms (int whiteMushroomsExpected, int xTimes)
        {
            return whiteMushroomsExpected * xTimes;
        }

    }
}
