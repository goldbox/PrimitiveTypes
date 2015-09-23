using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class Goats
    {
       [TestMethod]
        public void Test1()
        {
            int goatsInitial = 2;
            int daysInitial = 3;
            double kgInitial = 6;
            double kgOneGoatOneDay = CalculateKgOneGoatOneDay(goatsInitial, daysInitial, kgInitial);

            int goatsOutput = 5;
            int daysOutput = 7;
            double kgOutput = 35;

            double kgExpected = CalculateKgExpected(goatsOutput, daysOutput, kgOneGoatOneDay);

            Assert.AreEqual(kgExpected, kgOutput);

        }

        [TestMethod]
        //No initial Goats
        public void Test2()
        {
            int goatsInitial = 0;
            int daysInitial = 3;
            double kgInitial = 6;
            double kgOneGoatOneDay = CalculateKgOneGoatOneDay(goatsInitial, daysInitial, kgInitial);

            int goatsOutput = 5;
            int daysOutput = 7;
            double kgOutput = 0;

            double kgExpected = CalculateKgExpected(goatsOutput, daysOutput, kgOneGoatOneDay);

            Assert.AreEqual(kgExpected, kgOutput);

        }

        [TestMethod]
        //0 Initial Days
        public void Test3()
        {
            int goatsInitial = 2;
            int daysInitial = 0;
            double kgInitial = 6;
            double kgOneGoatOneDay = CalculateKgOneGoatOneDay(goatsInitial, daysInitial, kgInitial);

            int goatsOutput = 5;
            int daysOutput = 7;
            double kgOutput = 0;

            double kgExpected = CalculateKgExpected(goatsOutput, daysOutput, kgOneGoatOneDay);

            Assert.AreEqual(kgExpected, kgOutput);
        }

        [TestMethod]
        //0 Initial Kg
        public void Test4()
        {
            int goatsInitial = 2;
            int daysInitial = 3;
            double kgInitial = 0;
            double kgOneGoatOneDay = CalculateKgOneGoatOneDay(goatsInitial, daysInitial, kgInitial);

            int goatsOutput = 5;
            int daysOutput = 7;
            double kgOutput = 0;

            double kgExpected = CalculateKgExpected(goatsOutput, daysOutput, kgOneGoatOneDay);

            Assert.AreEqual(kgExpected, kgOutput);

        }

        [TestMethod]
        //0 Goats to calculate
        public void Test5()
        {
            int goatsInitial = 2;
            int daysInitial = 3;
            double kgInitial = 6;
            double kgOneGoatOneDay = CalculateKgOneGoatOneDay(goatsInitial, daysInitial, kgInitial);

            int goatsOutput = 0;
            int daysOutput = 7;
            double kgOutput = 0;

            double kgExpected = CalculateKgExpected(goatsOutput, daysOutput, kgOneGoatOneDay);

            Assert.AreEqual(kgExpected, kgOutput);

        }

        [TestMethod]
        //0 Days to calculate
        public void Test6()
        {
            int goatsInitial = 2;
            int daysInitial = 3;
            double kgInitial = 6;
            double kgOneGoatOneDay = CalculateKgOneGoatOneDay(goatsInitial, daysInitial, kgInitial);

            int goatsOutput = 5;
            int daysOutput = 0;
            double kgOutput = 0;

            double kgExpected = CalculateKgExpected(goatsOutput, daysOutput, kgOneGoatOneDay);

            Assert.AreEqual(kgExpected, kgOutput);

        }

      
        private double CalculateKgOneGoatOneDay (int goatsInitial, int daysInitial, double kgInitial)
        {
            if (goatsInitial <= 0 || daysInitial <= 0 || kgInitial <= 0)
            {
                return 0;
            } else
            {
                return kgInitial / goatsInitial / daysInitial;
            }
        }

        private double CalculateKgExpected (int goatsOutput, int daysOutput, double kgOneGoatOneDay)
        {
            return kgOneGoatOneDay * goatsOutput * daysOutput;
        }

    }
}
