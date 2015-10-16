using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class HanoiTowers
    {
        [TestMethod]
        public void TestFor0Disk()
        {
            int[] initialTower = new int[0];
            int[] finalTower = new int[0];
            int[] auxTower = new int[0];
            int[] test = initialTower;

            MoveAllDisksHanoiTowers(0, ref initialTower, ref finalTower, ref auxTower);
            CollectionAssert.AreEqual(test, finalTower);
        }

        [TestMethod]
        public void TestFor1Disk()
        {
            int[] initialTower = new int[] { 1 };
            int[] finalTower = new int[0];
            int[] auxTower = new int[0];
            int[] test = initialTower;

            MoveAllDisksHanoiTowers(0, ref initialTower, ref finalTower, ref auxTower);
            CollectionAssert.AreEqual(test, finalTower);
        }

        [TestMethod]
        public void TestFor6Disks()
        {
            int[] initialTower = new int[] { 6, 5, 4, 3, 2, 1 };
            int[] finalTower = new int[0];
            int[] auxTower = new int[0];
            int[] test = initialTower;

            MoveAllDisksHanoiTowers(0, ref initialTower, ref finalTower, ref auxTower);
            CollectionAssert.AreEqual(test, finalTower);
        }

        [TestMethod]
        public void TestFor20Disks()
        {
            int[] initialTower = new int[] { 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] finalTower = new int[0];
            int[] auxTower = new int[0];
            int[] test = initialTower;

            MoveAllDisksHanoiTowers(0, ref initialTower, ref finalTower, ref auxTower);
            CollectionAssert.AreEqual(test, finalTower);
        }
        
        private void MoveAllDisksHanoiTowers (int bottomPosToMove, ref int[] initialTower, ref int[] finalTower, ref int[] auxTower)
        {
            int topDisk = initialTower.Length - 1;
            if (topDisk < 0)
                return;

            if (bottomPosToMove == topDisk)
                MoveTopDisk(ref initialTower, ref finalTower);
            else
            {
                MoveAllDisksHanoiTowers(bottomPosToMove + 1, ref initialTower, ref auxTower, ref finalTower);
                MoveTopDisk(ref initialTower, ref finalTower);
                bottomPosToMove = GiveMeNextPositionFromAuxTower(auxTower, finalTower);
                MoveAllDisksHanoiTowers(bottomPosToMove, ref auxTower, ref finalTower, ref initialTower);
            }
        }

        private void MoveTopDisk(ref int[] initialTower, ref int[] finalTower)
        {
            var topDisk = initialTower.Length - 1;
            Array.Resize(ref finalTower, finalTower.Length + 1);
            finalTower[finalTower.Length - 1] = initialTower[initialTower.Length - 1];
            Array.Resize(ref initialTower, initialTower.Length - 1);
        }

        private int GiveMeNextPositionFromAuxTower(int[] auxTower, int[] finalTower)
        {
            int result = 0;
            int lastDiskValue = finalTower[finalTower.Length - 1];
            int nextDiskValue =  lastDiskValue - 1;
            
            foreach(int i in auxTower)
            {
                if (i > nextDiskValue)
                    result++;
            }
            return result;
        }
                
    }
}
