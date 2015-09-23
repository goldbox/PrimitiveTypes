using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class BirdAndTrains
    {
        [TestMethod]
        public void Test1()
        {
            int trainSpeed = 10;
            double initialDistanceBetweenTrains = 1500;
            double birdDistanceExpected = 750;
            double birdDistanceActual = CalculateBirdDistance(trainSpeed, initialDistanceBetweenTrains);
            Assert.AreEqual(birdDistanceExpected, birdDistanceActual);
        }

        [TestMethod]
        //Trains are stopped
        public void Test2()
        {
            int trainSpeed = 0;
            double initialDistanceBetweenTrains = 1500;
            double birdDistanceExpected = 0;
            double birdDistanceActual = CalculateBirdDistance(trainSpeed, initialDistanceBetweenTrains);
            Assert.AreEqual(birdDistanceExpected, birdDistanceActual);
        }

        [TestMethod]
        //initial distance between trains is 0
        public void Test3()
        {
            int trainSpeed = 10;
            double initialDistanceBetweenTrains = 0;
            double birdDistanceExpected = 0;
            double birdDistanceActual = CalculateBirdDistance(trainSpeed, initialDistanceBetweenTrains);
            Assert.AreEqual(birdDistanceExpected, birdDistanceActual);
        }

        private double CalculateBirdDistance (int trainSpeed, double initialDistanceBetweenTrains)
        {
            if (trainSpeed <= 0 || initialDistanceBetweenTrains <= 0)
            {
                return 0;
            } else
            {
                // Bird flies 2 times faster than train speed. 
                // Since we have 2 trains the distance bird flies = distance made by both trains combined. 
                // bird start flying only after both trains make half of initial distance, 1/4 each train. 
                return initialDistanceBetweenTrains / 2;
            }
        }
    }
}
