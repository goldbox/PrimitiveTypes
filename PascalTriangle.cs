using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class PascalTriangle
    {
        [TestMethod]
        public void TestForNoRows()
        {
            int numberOfRows = 0;
            int[][] tempPascal = new int[0][];

            int[][] finalPascalTriangle = GeneratePascalTriangle(numberOfRows, tempPascal);

            int[][] test = new int[0][];

            CollectionAssertJaggedArray(tempPascal, finalPascalTriangle);
        }

        [TestMethod]
        public void TestForOneRow()
        {
            int numberOfRows = 1;
            int[][] tempPascal = new int[0][];

            int[][] finalPascalTriangle = GeneratePascalTriangle(numberOfRows, tempPascal);

            int[][] test = new int[1][] { new int[] { 1 } };

            CollectionAssertJaggedArray(test, finalPascalTriangle);
        }

        [TestMethod]
        public void TestForSixRows()
        {
            int numberOfRows = 6;
            int[][] tempPascal = new int[0][];

            int[][] finalPascalTriangle = GeneratePascalTriangle(numberOfRows, tempPascal);

            int[][] test = new int[6][]
            {
                new int[] { 1 },
                new int[] { 1, 1 },
                new int[] { 1, 2, 1 },
                new int[] {1, 3, 3, 1},
                new int[] {1, 4, 6, 4, 1 },
                new int[] {1, 5, 10, 10, 5, 1}
            };
            CollectionAssertJaggedArray(test, finalPascalTriangle);
        }

        public int[][] GeneratePascalTriangle(int totalRows, int[][] tempPascal)
        {
            int rowsTempPascal = tempPascal.Length;
            if (totalRows == 0 || totalRows == rowsTempPascal)  
               return tempPascal;

            tempPascal = AddNewRow(tempPascal, rowsTempPascal);

            return  GeneratePascalTriangle(totalRows, tempPascal);
            
        }

        private int[][] AddNewRow(int[][] tempPascal, int rowsTempPascal)
        {
            ResizeByAddingOneEmptyRow(ref tempPascal, rowsTempPascal);
            
            if (rowsTempPascal == 0)
                tempPascal[rowsTempPascal][0] = 1;
            else
            {
                PlaceFirstAndLastNumber(ref tempPascal, rowsTempPascal);
                AddLeftRightFromUpperRow(ref tempPascal, rowsTempPascal);

            }
            return tempPascal;
        }

        private static void AddLeftRightFromUpperRow(ref int[][] tempPascal, int rowsTempPascal)
        {
            for (int i = 1; i < rowsTempPascal; i++)
            {
                var leftUp = tempPascal[rowsTempPascal - 1][i - 1];
                var rightUp = tempPascal[rowsTempPascal - 1][i];

                tempPascal[rowsTempPascal][i] = leftUp + rightUp;
            }
        }

        private static void PlaceFirstAndLastNumber(ref int[][] tempPascal, int rowsTempPascal)
        {
            tempPascal[rowsTempPascal][0] = 1;
            tempPascal[rowsTempPascal][rowsTempPascal] = 1;
        }

        private void ResizeByAddingOneEmptyRow(ref int[][] tempPascal, int rowsTempPascal)
        {
            var addOne = rowsTempPascal + 1;
            Array.Resize(ref tempPascal, addOne);
            Array.Resize(ref tempPascal[rowsTempPascal], addOne);
        }

        private void CollectionAssertJaggedArray(int[][] expected, int[][] finalTower)
        {
            int length = finalTower.Length;
            for (int i = 0; i < length; i++)
            {
                CollectionAssert.AreEqual(expected[i], finalTower[i]);
            }
        }

    }
}
