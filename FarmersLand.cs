using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class FarmersLand
    {
        [TestMethod]
        public void TestWithInitialValues()
        {
            int addedWidth = 230;
            int finalFarmersLandArea = 770000;

            double initialFarmersland = CalculateInitialFarmersLand(addedWidth, finalFarmersLandArea);

            Assert.AreEqual(592900, initialFarmersland);
        }

        private double CalculateInitialFarmersLand(int addedWidth, int finalFarmersLandArea)
        {
            //Second degree ecuation > finalFarmerLandArea = x(x + 230)
            double a = 1;
            double b = addedWidth;
            double c = -1 * finalFarmersLandArea;
            double squareLenght = SolveSecondDegreeEquation(a, b, c);
            return Math.Round(CalculateSquareArea(squareLenght), 2);

        }

        private double SolveSecondDegreeEquation (double a, double b, double c)
        {
            double x1;
            double x2;
            double delta = CalculateDelta(a, b, c);
            CalculateRoots(a, b, delta, out x1, out x2);
            double result = IsPositive(x1, x2);
            return result;
        }

        private double CalculateDelta (double a, double b, double c)
        {
            return b * b - 4 * a * c;
        }

        private void CalculateRoots (double a, double b, double delta, out double x1, out double x2)
        {
            x1 = (- b - Math.Sqrt(delta)) / 2 * a;
            x2 = (-b + Math.Sqrt(delta)) / 2 * a;
        }

        private double IsPositive (double x1, double x2)
        {
            if(x1 >= 0)
            {
                return x1;
            } else if (x2 >= 0)
            {
                return x2;        
            } else
            {
                return 0;
            } 

        }

        private double CalculateSquareArea(double squareLenght)
        {
            return squareLenght * squareLenght;
        }
    }
}
