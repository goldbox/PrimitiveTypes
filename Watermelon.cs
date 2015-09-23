using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class Watermelon
    {
        [TestMethod]
        //Watermelon weight even: 4kg, 6 kg, ....
        public void Test1()
        {
            int watermelonKg = 6;
            string watermelonCanBeShared = "DA";
            string watermelonCanBeSharedExpected = WatermelonSharing(watermelonKg);

            Assert.AreEqual(watermelonCanBeSharedExpected, watermelonCanBeShared);
        }

        [TestMethod]
        //Watermelon weight odd: 5kg, 7 kg, ....
        public void Test2()
        {
            int watermelonKg = 5;
            string watermelonCanBeShared = "NU";
            string watermelonCanBeSharedExpected = WatermelonSharing(watermelonKg);

            Assert.AreEqual(watermelonCanBeSharedExpected, watermelonCanBeShared);
        }

        [TestMethod]
        //Watermelon weight under 4kg
        public void Test3()
        {
            int watermelonKg = 2;
            string watermelonCanBeShared = "NU";
            string watermelonCanBeSharedExpected = WatermelonSharing(watermelonKg);

            Assert.AreEqual(watermelonCanBeSharedExpected, watermelonCanBeShared);
        }

        private string WatermelonSharing (int watermelonKg)
        {
            if (watermelonKg >= 4)
            {
                if ((watermelonKg % 2) == 0)
                {
                    return "DA";
                } else
                {
                    return "NU";
                }

            }   else
            {
                return "NU";
            }
        }
    }
}
