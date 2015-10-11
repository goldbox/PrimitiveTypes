using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class MathOperationsSolvedWithArray
    {
        [TestMethod]
        public void TestAddition()
        {
            int firstNumber = 17896589;
            int secondNumber = 255;
            int baseX = 2;
            int[] firstNumberInBaseX = ConvertFromDecimalToAnyBase(firstNumber, baseX);
            int[] secondNumberInBaseX = ConvertFromDecimalToAnyBase(secondNumber, baseX);
            int[] firstPlusSecond = AddTwoNumbersAnyBase(firstNumberInBaseX, secondNumberInBaseX, baseX);
            Assert.AreEqual(firstNumber + secondNumber, ConvertFromAnyBaseToDecimal(firstPlusSecond, baseX));
        }

        [TestMethod]
        public void TestSubstraction()
        {
            int firstNumber = 17896589;
            int secondNumber = 2758698;
            int baseX = 13;
            int[] firstNumberInBaseX = ConvertFromDecimalToAnyBase(firstNumber, baseX);
            int[] secondNumberInBaseX = ConvertFromDecimalToAnyBase(secondNumber, baseX);
            int[] firstMinusSecond = SubstractTwoNumbersAnyBase(firstNumberInBaseX, secondNumberInBaseX, baseX);
            Assert.AreEqual(firstNumber - secondNumber, ConvertFromAnyBaseToDecimal(firstMinusSecond, baseX));
        }

        [TestMethod]
        public void TestMultiplication()
        {
            int firstNumber = 5987;
            int secondNumber = 156;
            int baseX = 23;
            int[] firstNumberInBaseX = ConvertFromDecimalToAnyBase(firstNumber, baseX);
            int[] secondNumberInBaseX = ConvertFromDecimalToAnyBase(secondNumber, baseX);
            int[] firstMultiplySecond = MultiplyTwoNumbersInAnyBase(firstNumberInBaseX, secondNumberInBaseX, baseX);
            Assert.AreEqual(firstNumber * secondNumber, ConvertFromAnyBaseToDecimal(firstMultiplySecond, baseX));
        }

        [TestMethod]
        public void TestDivision()
        {
            int firstNumber = 798654;
            int secondNumber = 4568;
            int baseX = 57;
            int[] firstNumberInBaseX = ConvertFromDecimalToAnyBase(firstNumber, baseX);
            int[] secondNumberInBaseX = ConvertFromDecimalToAnyBase(secondNumber, baseX);
            int[] SecondDivideFirst = DivideTwoNumbersInAnyBase(firstNumberInBaseX, secondNumberInBaseX, baseX);
            Assert.AreEqual(firstNumber / secondNumber, ConvertFromAnyBaseToDecimal(SecondDivideFirst, baseX));
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

        private int[] AddTwoNumbersAnyBase(int[] firstNumber, int[] secondNumber, int baseX)
        {
            ConvertNumbersToTheSameLenght(ref firstNumber, ref secondNumber);
            int x = firstNumber.Length;

            int[] result = new int[x];
            int[] tempInBaseX = new int[8];
            int i = 0;
            for (; i < x; i++)
            {
                int temp = firstNumber[i] + secondNumber[i] + tempInBaseX[1];
                tempInBaseX = ConvertFromDecimalToAnyBase(temp, baseX);
                result[i] = tempInBaseX[0];
            }
            if (tempInBaseX[1] != 0)
            {
                result = AddEightBitsToThisArray(result);
                result[i] = tempInBaseX[1];
            }
            return result;
        }

        private int[] SubstractTwoNumbersAnyBase(int[] firstNumber, int[] secondNumber, int baseX)
        {
            ConvertNumbersToTheSameLenght(ref firstNumber, ref secondNumber);
            bool firstNumberIsHigher = IsFirstNumberHigher(firstNumber, secondNumber);
            if (!firstNumberIsHigher | firstNumber == secondNumber)
            {
                int[] error = new int[8];
                return error;
            }

            int x = firstNumber.Length;
            int[] result = new int[x];
            int tempToBorrow = 0;
            for (int i = 0; i < x; i++)
            {
                if (firstNumber[i] < (secondNumber[i] + tempToBorrow))
                {
                    firstNumber[i] += baseX;
                    result[i] = firstNumber[i] - secondNumber[i] - tempToBorrow;
                    tempToBorrow = 1;
                }
                else
                {
                    result[i] = firstNumber[i] - secondNumber[i] - tempToBorrow;
                    tempToBorrow = 0;
                }
            }
            return result;

        }

        private int[] MultiplyTwoNumbersInAnyBase(int[] firstNumber, int[] secondNumber, int baseX)
        {
            int x = ConvertFromAnyBaseToDecimal(secondNumber, baseX);
            int[] result = new int[8];
            for (int i = 0; i < x; i++)
            {
                result = AddTwoNumbersAnyBase(result, firstNumber, baseX);
            }
            return result;
        }

        private int[] DivideTwoNumbersInAnyBase(int[] firstNumber, int[] SecondNumber, int baseX)
        {
            int x = firstNumber.Length;
            int[] temp = SecondNumber;
            int[] result = new int[8];
            int[] one = new int[8];
            one[0] = 1;
            while (IsFirstNumberHigher(firstNumber, temp))
            {
                result = AddTwoNumbersAnyBase(result, one, baseX);
                temp = AddTwoNumbersAnyBase(temp, SecondNumber, baseX);
            }
            return result;
        }

        private bool IsFirstNumberHigher(int[] firstNumber, int[] secondNumber)
        {
            int i = firstNumber.Length;
            for (i--; i >= 0; i--)
            {
                if (firstNumber[i] < secondNumber[i])
                {
                    return false;
                }
                else if (firstNumber[i] > secondNumber[i])
                {
                    return true;
                }
            }
            return true;
        }

        private int[] AddEightBitsToThisArray(int[] initialArray)
        {
            int i = initialArray.Length;
            i += 8;
            int[] resultArray = new int[i];
            initialArray.CopyTo(resultArray, 0);
            return resultArray;
        }

        private void ConvertNumbersToTheSameLenght(ref int[] FirstNumber, ref int[] secondNumber)
        {
            while (FirstNumber.Length != secondNumber.Length)
            {
                if (FirstNumber.Length > secondNumber.Length)
                {
                    secondNumber = AddEightBitsToThisArray(secondNumber);
                }
                else
                {
                    FirstNumber = AddEightBitsToThisArray(FirstNumber);
                }
            }
        }
    }
}
