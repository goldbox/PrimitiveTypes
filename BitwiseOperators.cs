using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class BitwiseOperators
    {

        [TestMethod]
        public void TestBitwiseOperatorAnd()
        {
            int firstNumber = 897;
            int secondNumber = 79;
            int baseX = 2;
            string firstNumberInBaseX = ConvertFromDecimalToAnyBase(firstNumber, baseX);
            string secondNumberInBaseX = ConvertFromDecimalToAnyBase(secondNumber, baseX);
           
            string aAndB = CalculateBitwiseAnd(firstNumberInBaseX, secondNumberInBaseX);
            
            Assert.AreEqual((firstNumber & secondNumber), ConvertFromAnyBaseToDecimal(aAndB, baseX));
        }

        [TestMethod]
        public void TestBitwiseOperatorOr()
        {
            int firstNumber = 10;
            int secondNumber = 15;
            int baseX = 2;
            string firstNumberInBaseX = ConvertFromDecimalToAnyBase(firstNumber, baseX);
            string secondNumberInBaseX = ConvertFromDecimalToAnyBase(secondNumber, baseX);

            string aOrB = CalculateBitwiseOr(firstNumberInBaseX, secondNumberInBaseX);
            
            Assert.AreEqual((firstNumber | secondNumber), ConvertFromAnyBaseToDecimal(aOrB, baseX));
        }

        [TestMethod]
        public void TestBitwiseOperatorXor()
        {
            int firstNumber = 55;
            int secondNumber = 647;
            int baseX = 2;
            string firstNumberInBaseX = ConvertFromDecimalToAnyBase(firstNumber, baseX);
            string secondNumberInBaseX = ConvertFromDecimalToAnyBase(secondNumber, baseX);

            string aXorB = CalculateBitwiseXor(firstNumberInBaseX, secondNumberInBaseX);

            Assert.AreEqual((firstNumber ^ secondNumber), ConvertFromAnyBaseToDecimal(aXorB, baseX));
        }

        [TestMethod]
        public void TestBitwiseOperatorLeftShift()
        {
            int firstNumber = 1579;
            int baseX = 2;
            string firstNumberInBaseX = ConvertFromDecimalToAnyBase(firstNumber, baseX);
            
            string aLHS = CalculateBitwiseLeftShift(firstNumberInBaseX);

            Assert.AreEqual((firstNumber << 1), ConvertFromAnyBaseToDecimal(aLHS, baseX));
        }

        [TestMethod]
        public void TestBitwiseOperatorRightShift()
        {
            int firstNumber = 129;
            int baseX = 2;
            string firstNumberInBaseX = ConvertFromDecimalToAnyBase(firstNumber, baseX);

            string aRHS = CalculateBitwiseLeftShift(firstNumberInBaseX);

            Assert.AreEqual((firstNumber << 1), ConvertFromAnyBaseToDecimal(aRHS, baseX));
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

        public int ConvertFromAnyBaseToDecimal (string stringBaseX, int baseX)
        {
            int x = stringBaseX.Length;
            int result=0;
            for(int i=1; i<=x; i++)
            {
                double baseXDouble = baseX;
                double iDouble = i - 1;
                double baseXAtPowerI = Math.Pow(baseXDouble, iDouble);
                
                result += ReturnBitX(stringBaseX, i) * Convert.ToInt32(baseXAtPowerI);
            }

            return result;
        }

        private string CalculateBitwiseAnd (string a, string b)
        {
            int x = CalculateHigherByteLenght(a, b);
            string result = string.Empty;
            for(int i=1; i<=x; i++)
            {
                int bitXAAndB = ReturnBitX(a, i) & ReturnBitX(b, i);
                result = bitXAAndB + result;
            }
            return result;
        }

        private string CalculateBitwiseOr(string a, string b)
        {
            int x = CalculateHigherByteLenght(a, b);
            string result = string.Empty;
            for (int i = 1; i <= x; i++)
            {
                int bitXAOrB = ReturnBitX(a, i) | ReturnBitX(b, i);
                result = bitXAOrB + result;
            }
            return result;
        }

        private string CalculateBitwiseXor(string a, string b)
        {
            int x = CalculateHigherByteLenght(a, b);
            string result = string.Empty;
            for (int i = 1; i <= x; i++)
            {
                int bitXAXorB = ReturnBitX(a, i) ^ ReturnBitX(b, i);
                result = bitXAXorB + result;
            }
            return result;
        }

        private string CalculateBitwiseLeftShift (string a)
        {
            return a + "0";
        }

        private string CalculateBitwiseRightShift(string a)
        {
            int aLenght = a.Length;
            return a.Substring(0, aLenght - 1);
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
                string tempString = a.Substring(x, 1);
                int bitX;
                Int32.TryParse(tempString, out bitX);
                
                return bitX;
            }
        }

        private int CalculateHigherByteLenght(string a, string b)
        {
            return a.Length >= b.Length ? a.Length : b.Length;

        }

    }
}
