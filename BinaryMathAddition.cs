using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class BinaryMathAddition
    {
        [TestMethod]
        public void TestWithIdenticalNumbers()
        {
            int firstNumber = 7;
            int secondNumber = 7;
            int baseX = 2;
            string firstNumberBinar = ConvertFromDecimalToAnyBase(firstNumber, baseX);
            string secondNumberBinar = ConvertFromDecimalToAnyBase(secondNumber, baseX);
            string sumBinar = AddTwoBinars(firstNumberBinar, secondNumberBinar);

            Assert.AreEqual(ConvertFromDecimalToAnyBase(14, baseX), sumBinar);
        }

        [TestMethod]
        public void TestWithSmallNumbers()
        {
            int firstNumber = 2;
            int secondNumber = 3;
            int baseX = 2;
            string firstNumberBinar = ConvertFromDecimalToAnyBase(firstNumber, baseX);
            string secondNumberBinar = ConvertFromDecimalToAnyBase(secondNumber, baseX);
            string sumBinar = AddTwoBinars(firstNumberBinar, secondNumberBinar);

            Assert.AreEqual("101", sumBinar);
        }

        [TestMethod]
        public void TestWithFirstHigherThanSecondNumber()
        {
            int firstNumber = 1024;
            int secondNumber = 512;
            int baseX = 2;
            string firstNumberBinar = ConvertFromDecimalToAnyBase(firstNumber, baseX);
            string secondNumberBinar = ConvertFromDecimalToAnyBase(secondNumber, baseX);
            string sumBinar = AddTwoBinars(firstNumberBinar, secondNumberBinar);

            Assert.AreEqual(ConvertFromDecimalToAnyBase(1536, baseX), sumBinar);
        }

        [TestMethod]
        public void TestWithSecondNumberHigherThanFirstNumber()
        {
            int firstNumber = 75;
            int secondNumber = 400;
            int baseX = 2;
            string firstNumberBinar = ConvertFromDecimalToAnyBase(firstNumber, baseX);
            string secondNumberBinar = ConvertFromDecimalToAnyBase(secondNumber, baseX);
            string sumBinar = AddTwoBinars(firstNumberBinar, secondNumberBinar);

            Assert.AreEqual(ConvertFromDecimalToAnyBase(475, baseX), sumBinar);
        }

        public string ConvertFromDecimalToAnyBase(int numberBase10, int baseX)
        {
            string numberBaseX = string.Empty;
            while (numberBase10 != 0)
            {
                if (numberBase10 % baseX == 0)
                {
                    numberBaseX = '0' + numberBaseX;
                }
                else
                {
                    int remainder = numberBase10 % baseX;
                    numberBaseX = remainder + numberBaseX;
                }
                numberBase10 /= baseX;
            }
            return numberBaseX;

        }

        public int ConvertFromAnyBaseToDecimal(string stringBaseX, int baseX)
        {
            int x = stringBaseX.Length;
            int result = 0;
            for (int i = 1; i <= x; i++)
            {
                double baseXDouble = baseX;
                double iDouble = i - 1;
                double baseXAtPowerI = Math.Pow(baseXDouble, iDouble);

                result += ReturnBitX(stringBaseX, i) * Convert.ToInt32(baseXAtPowerI);
            }

            return result;
        }

        private string AddTwoBinars (string a, string b)
        {
            int x = CalculateHigherByteLenght(a, b);
            
            string tempBinaryString = string.Empty;
            string finalBinaryString = string.Empty;

            for (int i = 1; i <= x; i++)
            {
                int sumaX = AddOneBit(a, b, tempBinaryString, i);
                if (sumaX < 2)
                {
                    tempBinaryString = sumaX + finalBinaryString;
                    finalBinaryString = sumaX + finalBinaryString;
                } else if (sumaX == 2)
                {
                    tempBinaryString = "10" + finalBinaryString;
                    finalBinaryString = "0" + finalBinaryString;
                } else if (sumaX == 3)
                {
                    tempBinaryString = "11" + finalBinaryString;
                    finalBinaryString = "1" + finalBinaryString;
                }

            }
            if (tempBinaryString.Length > finalBinaryString.Length)
            {
                finalBinaryString = tempBinaryString[0] + finalBinaryString;
            }

            return finalBinaryString;

        }

        private int AddOneBit(string a, string b, string tempBinaryString, int i)
        {
            int aX = ReturnBitX(a, i);
            int bX = ReturnBitX(b, i);
            int tempX = ReturnBitX(tempBinaryString, i);

            int sumaX = aX + bX + tempX;
            return sumaX;

        }

        private int ReturnBitX(string a, int i)
        {
            int aLenght = a.Length;
            int x = aLenght - i;
            if (x < 0)
            {
                return 0;
            }
            else
            {
                int bitX = a[x];
                bitX -= 48;
                return bitX;
            }
        }

        private int CalculateHigherByteLenght (string a, string b)
        {
            return a.Length >= b.Length ? a.Length : b.Length; 
            
        }

    }
}
