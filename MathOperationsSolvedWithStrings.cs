﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class MathOperationsSolvedWithStrings
    {
        [TestMethod]
        public void TestWithBase2()
        {
            int firstNumber = 1468;
            int secondNumber = 1234;
            int baseX = 5;
            string firstNumberInBaseX = ConvertFromDecimalToAnyBase(firstNumber, baseX);
            string secondNumberInBaseX = ConvertFromDecimalToAnyBase(secondNumber, baseX);
            string sumOfTwoNumbersInBaseX = AddTwoNumbersFromAnyBase(firstNumberInBaseX, secondNumberInBaseX, baseX);
            string substractionOfTwoNumbers = SubtractTwoNumbersInAnyBase(firstNumberInBaseX, secondNumberInBaseX, baseX);
            Assert.AreEqual(firstNumber + secondNumber, ConvertFromAnyBaseToDecimal(sumOfTwoNumbersInBaseX, baseX));
            Assert.AreEqual(firstNumber - secondNumber, ConvertFromAnyBaseToDecimal(substractionOfTwoNumbers, baseX));
        }

        [TestMethod]
        public void TestWithBase5()
        {
            int firstNumber = 37;
            int secondNumber = 2794158;
            int baseX = 5;
            string firstNumberInBaseX = ConvertFromDecimalToAnyBase(firstNumber, baseX);
            string secondNumberInBaseX = ConvertFromDecimalToAnyBase(secondNumber, baseX);
            string sumOfTwoNumbersInBaseX = AddTwoNumbersFromAnyBase(firstNumberInBaseX, secondNumberInBaseX, baseX);

            Assert.AreEqual(firstNumber + secondNumber, ConvertFromAnyBaseToDecimal(sumOfTwoNumbersInBaseX, baseX));
        }

        [TestMethod]
        public void TestWithIdenticalNumbersAndBase7()
        {
            int firstNumber = 20151008;
            int secondNumber = 20151008;
            int baseX = 7;
            string firstNumberInBaseX = ConvertFromDecimalToAnyBase(firstNumber, baseX);
            string secondNumberInBaseX = ConvertFromDecimalToAnyBase(secondNumber, baseX);
            string sumOfTwoNumbersInBaseX = AddTwoNumbersFromAnyBase(firstNumberInBaseX, secondNumberInBaseX, baseX);

            Assert.AreEqual(firstNumber + secondNumber, ConvertFromAnyBaseToDecimal(sumOfTwoNumbersInBaseX, baseX));
        }

        [TestMethod]
        public void TestIfOneOfTheNumbersIsZero()
        {
            int firstNumber = 0;
            int secondNumber = 20151008;
            int baseX = 3;
            string firstNumberInBaseX = ConvertFromDecimalToAnyBase(firstNumber, baseX);
            string secondNumberInBaseX = ConvertFromDecimalToAnyBase(secondNumber, baseX);
            string sumOfTwoNumbersInBaseX = AddTwoNumbersFromAnyBase(firstNumberInBaseX, secondNumberInBaseX, baseX);

            Assert.AreEqual(firstNumber + secondNumber, ConvertFromAnyBaseToDecimal(sumOfTwoNumbersInBaseX, baseX));
        }

        [TestMethod]
        public void TestMultiply()
        {
            int firstNumber = 1489;
            int secondNumber = 1548;
            int baseX = 5;
            string firstNumberInBaseX = ConvertFromDecimalToAnyBase(firstNumber, baseX);
            string secondNumberInBaseX = ConvertFromDecimalToAnyBase(secondNumber, baseX);
            string multiplyOfTwoNumbers = MultiplyTwoNumbersInAnyBase(firstNumberInBaseX, secondNumberInBaseX, baseX);
            Assert.AreEqual(firstNumber * secondNumber, ConvertFromAnyBaseToDecimal(multiplyOfTwoNumbers, baseX));
        }

        public string ConvertFromDecimalToAnyBase(int decimalNumber, int baseX)
        {
            string numberBaseX = string.Empty;
            if (decimalNumber == 0)
            {
                return "0";
            }
            else
            {
                while (decimalNumber != 0)
                {
                    if (decimalNumber % baseX == 0)
                    {
                        numberBaseX = '0' + numberBaseX;
                    }
                    else
                    {
                        int remainder = decimalNumber % baseX;
                        numberBaseX = remainder + numberBaseX;
                    }
                    decimalNumber /= baseX;
                }
            }
            return numberBaseX;
        }

        public int ConvertFromAnyBaseToDecimal(string stringBaseX, int baseX)
        {
            int stringBaseXLenght = stringBaseX.Length;
            int decimalNumber = 0;
            for (int i = 1; i <= stringBaseXLenght; i++)
            {
                double baseXDouble = baseX;
                double iDouble = i - 1;
                double baseXAtPowerI = Math.Pow(baseXDouble, iDouble);

                decimalNumber += ReturnBitN(stringBaseX, i) * Convert.ToInt32(baseXAtPowerI);
            }

            return decimalNumber;
        }

        private string AddTwoNumbersFromAnyBase(string firstNumberInBaseX, string SecondNumberBaseX, int baseX)
        {
            int higherBitLenght = CalculateHigherBitLenght(firstNumberInBaseX, SecondNumberBaseX);

            string tempString = string.Empty;
            string finalString = string.Empty;

            for (int i = 1; i <= higherBitLenght; i++)
            {
                tempString = AddBitByBit(firstNumberInBaseX, SecondNumberBaseX, tempString, i, baseX);
                int tempStringLenght = tempString.Length;
                if (tempStringLenght == 1)
                {
                    finalString = tempString + finalString;
                    tempString = "";
                }
                else if (tempStringLenght == 2)
                {
                    finalString = tempString.Substring(1, 1) + finalString;
                    tempString = tempString.Substring(0, 1);
                }

            }

            if (tempString.Length == 1)
            {
                finalString = tempString[0] + finalString;

            }
            return finalString;

        }

        private string SubtractTwoNumbersInAnyBase(string firstNumberInBaseX, string secondNumberInBaseX, int baseX)
        {
            if (firstNumberInBaseX == secondNumberInBaseX)
            {
                return "0";
            }
            bool firstNumberIsHigherThanSecond = CompareTwoNumbers(firstNumberInBaseX, secondNumberInBaseX);
            if (!firstNumberIsHigherThanSecond)
            {
                return "Error";
            }

            int higherBitLenght = CalculateHigherBitLenght(firstNumberInBaseX, secondNumberInBaseX);

            int tempBorrow = 0;
            string finalString = string.Empty;

            for (int i = 1; i <= higherBitLenght; i++)
            {
                finalString = SubtractBitByBit(firstNumberInBaseX, secondNumberInBaseX, ref tempBorrow, i, baseX) + finalString;
            }
            return finalString;
        }

        private string MultiplyTwoNumbersInAnyBase(string firstNumberInBaseX, string secondNumberInBaseX, int baseX)
        {
            int x = ConvertFromAnyBaseToDecimal(secondNumberInBaseX, baseX);
            string result = string.Empty;
            for (int i = 0; i < x; i++)
            {
                result = AddTwoNumbersFromAnyBase(result, firstNumberInBaseX, baseX);
            }
            return result;
        }


        private bool CompareTwoNumbers(string firstNumber, string secondNumber)
        {
            if (firstNumber.Length == secondNumber.Length)
            {
                return IsFirstNumberHigher(firstNumber, secondNumber) ? true : false;
            }
            return (firstNumber.Length > secondNumber.Length) ? true : false;
        }

        private bool IsFirstNumberHigher(string firstNumber, string secondNumber)
        {
            int x = firstNumber.Length;
            for (int i = 0; i < x; i++)
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

        private string AddBitByBit(string firstNumberInBaseX, string secondNumberinBaseX, string tempString, int x, int baseX)
        {
            int bitXNumber1 = ReturnBitN(firstNumberInBaseX, x);
            int bitXNumber2 = ReturnBitN(secondNumberinBaseX, x);
            int bitXFromTemp;
            Int32.TryParse(tempString, out bitXFromTemp);

            int sumX = bitXNumber1 + bitXNumber2 + bitXFromTemp;

            return ConvertFromDecimalToAnyBase(sumX, baseX);

        }

        private int SubtractBitByBit(string firstNumberInBaseX, string secondNumberinBaseX, ref int tempBorrow, int x, int baseX)
        {
            int bitXNumber1 = ReturnBitN(firstNumberInBaseX, x);
            int bitXNumber2 = ReturnBitN(secondNumberinBaseX, x);
            int resultSubtraction;
            if (bitXNumber1 < (tempBorrow + bitXNumber2))
            {
                bitXNumber1 += baseX;
                resultSubtraction = bitXNumber1 - tempBorrow - bitXNumber2;
                tempBorrow = 1;
                return resultSubtraction;
            }
            resultSubtraction = bitXNumber1 - tempBorrow - bitXNumber2;
            tempBorrow = 0;
            return resultSubtraction;

        }

        private int ReturnBitN(string numberInBaseX, int i)
        {
            int aLenght = numberInBaseX.Length;
            int n = aLenght - i;
            if (n < 0)
            {
                return 0;
            }
            else
            {
                string tempString = numberInBaseX.Substring(n, 1);
                int bitN;
                Int32.TryParse(tempString, out bitN);

                return bitN;
            }
        }

        private int CalculateHigherBitLenght(string a, string b)
        {
            return a.Length >= b.Length ? a.Length : b.Length;
        }
    }
}
