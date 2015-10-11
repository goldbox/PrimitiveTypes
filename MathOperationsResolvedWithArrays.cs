using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class MathOperationsResolvedWithArrays
    {
        [TestMethod]
        public void TestWithBase2()
        {
            int firstNumber = 123456789;
            int secondNumber = 3;
            int baseX = 2;
            int[] numberInAnotherBase = ConvertFromDecimalToAnyBase(firstNumber, baseX);
            int decimalNumber = ConvertFromAnyBaseToDecimal(numberInAnotherBase, baseX);
            Assert.AreEqual(firstNumber, decimalNumber);
        }

        private int[] ConvertFromDecimalToAnyBase(int decimalNumber, int baseX)
        {
            int[] numberBaseX = new int[8];

            if (decimalNumber == 0)
            {
                return numberBaseX;
            }
            int i = 0;
            while (decimalNumber != 0)
            {
                if (i == numberBaseX.Length)
                {
                    numberBaseX = AddEightBitsToThisArray(numberBaseX);
                }
                numberBaseX[i] = (decimalNumber % baseX == 0) ? 0 : decimalNumber % baseX;

                decimalNumber /= baseX;
                i++;
            }
            return numberBaseX;


        }

        private int ConvertFromAnyBaseToDecimal(int[] numberInBaseX, int baseX)
        {
            int decimalNumber = 0;
            int i = 0;
            foreach (int bit in numberInBaseX)
            {
                decimalNumber += bit * (int)Math.Pow(baseX, i);
                i++;
            }
            return decimalNumber;
        }

        private int[] AddEightBitsToThisArray(int[] initialArray)
        {
            int i = initialArray.Length;
            i += 8;
            int[] resultArray = new int[i];
            initialArray.CopyTo(resultArray, 0);
            return resultArray;
        }

   //     private int[] AddTwoNumbersFromAnyBase(int[] a, int[b], int baseX)
     //   {

       // }
       
    }
    }
