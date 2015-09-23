using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class ArchaeologicalSite
    {
        [TestMethod]
        public void Test1()
        {
            //Coordinates are A(xA, yA); B(xB, yX); c(xC, yC)
            double xA = 0.000000;
            double yA = 0.000000;
            double xB = 1.000000;
            double yB = 1.000000;
            double xC = 0.000000;
            double yC = 1.000000;
            double siteAreaActual = 1;

            bool coordinatesAEqualB = TestIfSameCoordinates(xA, yA, xB, yB);
            bool coordinatesBEqualC = TestIfSameCoordinates(xB, yB, xC, yC);
            bool coordinatesAEqualC = TestIfSameCoordinates(xA, yA, xC, yC);

            if (coordinatesAEqualB || coordinatesBEqualC || coordinatesAEqualC)
            {
                Assert.AreEqual(0, siteAreaActual);
            } else
            {
                //Distance from A to B
                double lenghtAB = DistanceBetweenTwoCoordinates(xA, yA, xB, yB);
                //Distance from B to C
                double lenghtBC = DistanceBetweenTwoCoordinates(xB, yB, xC, yC);
                //Distance from A to C
                double lenghtAC = DistanceBetweenTwoCoordinates(xA, yA, xC, yC);
            
                //Triangle Area between those 3 coordinates
                double triangleArea = CalculateTriangleArea(lenghtAB, lenghtBC, lenghtAC);
                // site area if the house was a rectangle = triangle area * 2
                double siteAreaExpected = triangleArea * 2; 

                Assert.AreEqual(siteAreaExpected, siteAreaActual, 0.0000001);
            }
        }

        [TestMethod]
        //A Coordinates same as B coordinates 
        public void Test2()
        {
            //Coordinates are A(xA, yA); B(xB, yX); c(xC, yC)
            double xA = 0.000000;
            double yA = 0.000000;
            double xB = 0.000000;
            double yB = 0.000000;
            double xC = 0.000000;
            double yC = 1.000000;
            double siteAreaActual = 0;

            bool coordinatesAEqualB = TestIfSameCoordinates(xA, yA, xB, yB);
            bool coordinatesBEqualC = TestIfSameCoordinates(xB, yB, xC, yC);
            bool coordinatesAEqualC = TestIfSameCoordinates(xA, yA, xC, yC);

            if (coordinatesAEqualB || coordinatesBEqualC || coordinatesAEqualC)
            {
                Assert.AreEqual(0, siteAreaActual);
            }
            else
            {
                //Distance from A to B
                double lenghtAB = DistanceBetweenTwoCoordinates(xA, yA, xB, yB);
                //Distance from B to C
                double lenghtBC = DistanceBetweenTwoCoordinates(xB, yB, xC, yC);
                //Distance from A to C
                double lenghtAC = DistanceBetweenTwoCoordinates(xA, yA, xC, yC);

                //Triangle Area between those 3 coordinates
                double triangleArea = CalculateTriangleArea(lenghtAB, lenghtBC, lenghtAC);
                // site area if the house was a rectangle = triangle area * 2
                double siteAreaExpected = triangleArea * 2;

                Assert.AreEqual(siteAreaExpected, siteAreaActual);
            }
        }

        [TestMethod]
        //A Coordinates same as C coordinates 
        public void Test3()
        {
            //Coordinates are A(xA, yA); B(xB, yX); c(xC, yC)
            double xA = 0.000000;
            double yA = 0.000000;
            double xB = 1.000000;
            double yB = 1.000000;
            double xC = 0.000000;
            double yC = 0.000000;
            double siteAreaActual = 0;

            bool coordinatesAEqualB = TestIfSameCoordinates(xA, yA, xB, yB);
            bool coordinatesBEqualC = TestIfSameCoordinates(xB, yB, xC, yC);
            bool coordinatesAEqualC = TestIfSameCoordinates(xA, yA, xC, yC);

            if (coordinatesAEqualB || coordinatesBEqualC || coordinatesAEqualC)
            {
                Assert.AreEqual(0, siteAreaActual);
            }
            else
            {
                //Distance from A to B
                double lenghtAB = DistanceBetweenTwoCoordinates(xA, yA, xB, yB);
                //Distance from B to C
                double lenghtBC = DistanceBetweenTwoCoordinates(xB, yB, xC, yC);
                //Distance from A to C
                double lenghtAC = DistanceBetweenTwoCoordinates(xA, yA, xC, yC);

                //Triangle Area between those 3 coordinates
                double triangleArea = CalculateTriangleArea(lenghtAB, lenghtBC, lenghtAC);
                // site area if the house was a rectangle = triangle area * 2
                double siteAreaExpected = triangleArea * 2;

                Assert.AreEqual(siteAreaExpected, siteAreaActual);
            }
        }

        [TestMethod]
        //B Coordinates same as C coordinates 
        public void Test4()
        {
            //Coordinates are A(xA, yA); B(xB, yX); c(xC, yC)
            double xA = 0.000000;
            double yA = 0.000000;
            double xB = 1.000000;
            double yB = 1.000000;
            double xC = 1.000000;
            double yC = 1.000000;
            double siteAreaActual = 0;

            bool coordinatesAEqualB = TestIfSameCoordinates(xA, yA, xB, yB);
            bool coordinatesBEqualC = TestIfSameCoordinates(xB, yB, xC, yC);
            bool coordinatesAEqualC = TestIfSameCoordinates(xA, yA, xC, yC);

            if (coordinatesAEqualB || coordinatesBEqualC || coordinatesAEqualC)
            {
                Assert.AreEqual(0, siteAreaActual);
            }
            else
            {
                //Distance from A to B
                double lenghtAB = DistanceBetweenTwoCoordinates(xA, yA, xB, yB);
                //Distance from B to C
                double lenghtBC = DistanceBetweenTwoCoordinates(xB, yB, xC, yC);
                //Distance from A to C
                double lenghtAC = DistanceBetweenTwoCoordinates(xA, yA, xC, yC);

                //Triangle Area between those 3 coordinates
                double triangleArea = CalculateTriangleArea(lenghtAB, lenghtBC, lenghtAC);
                // site area if the house was a rectangle = triangle area * 2
                double siteAreaExpected = triangleArea * 2;

                Assert.AreEqual(siteAreaExpected, siteAreaActual);
            }
        }

        private bool TestIfSameCoordinates(double x1, double y1, double x2, double y2)
        {
            if (x1 == x2 && y1 == y2)
            {
                return true;
            } else
            {
                return false;
            }
        }

        private double DistanceBetweenTwoCoordinates (double x1, double y1, double x2, double y2)
        {
            //distance between two coordinates
            double distance = (x2 - x1)*(x2 - x1) + (y2 - y1)*(y2 - y1);
            distance = Math.Sqrt(distance);

            return distance;
        }

        private double CalculateTriangleArea (double a, double b, double c)
        {
            //semiperimeter
            double p = (a + b + c) / 2;
            //Heron's formula
            double triangleArea = p * (p - a) * (p - b) * (p - c);
            triangleArea = Math.Sqrt(triangleArea);

            return triangleArea;
        }
        
    }
}
