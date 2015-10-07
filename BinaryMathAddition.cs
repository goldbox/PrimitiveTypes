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
            string firstNumberBinar = ChangeFromBase10ToBase2(firstNumber);
            string secondNumberBinar = ChangeFromBase10ToBase2(secondNumber);
            string sumBinar = AddTwoBinars(firstNumberBinar, secondNumberBinar);

            Assert.AreEqual(ChangeFromBase10ToBase2(14), sumBinar);
        }

        [TestMethod]
        public void TestWithSmallNumbers()
        {
            int firstNumber = 2;
            int secondNumber = 3;
            string firstNumberBinar = ChangeFromBase10ToBase2(firstNumber);
            string secondNumberBinar = ChangeFromBase10ToBase2(secondNumber);
            string sumBinar = AddTwoBinars(firstNumberBinar, secondNumberBinar);

            Assert.AreEqual("101", sumBinar);
        }

        [TestMethod]
        public void TestWithFirstHigherThanSecondNumber()
        {
            int firstNumber = 1024;
            int secondNumber = 512;
            string firstNumberBinar = ChangeFromBase10ToBase2(firstNumber);
            string secondNumberBinar = ChangeFromBase10ToBase2(secondNumber);
            string sumBinar = AddTwoBinars(firstNumberBinar, secondNumberBinar);

            Assert.AreEqual(ChangeFromBase10ToBase2(1536), sumBinar);
        }

        [TestMethod]
        public void TestWithSecondNumberHigherThanFirstNumber()
        {
            int firstNumber = 75;
            int secondNumber = 400;
            string firstNumberBinar = ChangeFromBase10ToBase2(firstNumber);
            string secondNumberBinar = ChangeFromBase10ToBase2(secondNumber);
            string sumBinar = AddTwoBinars(firstNumberBinar, secondNumberBinar);

            Assert.AreEqual(ChangeFromBase10ToBase2(475), sumBinar);
        }


        public string ChangeFromBase10ToBase2(int numberBase10)
        {
            string numberBinar = string.Empty;
            while (numberBase10 != 0)
            {
                if (numberBase10 % 2 == 0)
                {
                    numberBinar = '0' + numberBinar;
                } else
                {
                    numberBinar = '1' + numberBinar;
                }
                numberBase10 /= 2;
            }
            return numberBinar;

        }

       
        private string AddTwoBinars (string a, string b)
        {
            int x = CalculateHigherBiteLenght(a, b);
            
            string tempBinaryString = string.Empty;
            string finalBinaryString = string.Empty;

            for (int i = 1; i <= x; i++)
            {
                int sumaX = AddOneBite(a, b, tempBinaryString, i);
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

        private int AddOneBite(string a, string b, string tempBinaryString, int i)
        {
            int aX = GiveBiteX(a, i);
            int bX = GiveBiteX(b, i);
            int tempX = GiveBiteX(tempBinaryString, i);

            int sumaX = aX + bX + tempX;
            return sumaX;

        }

        private int GiveBiteX(string a, int i)
        {
            int aLenght = a.Length;
            int x = aLenght - i;
            if (x < 0)
            {
                return 0;
            }
            else
            {
                int biteX = a[x];
                biteX -= 48;
                return biteX;
            }
        }

        private int CalculateHigherBiteLenght (string a, string b)
        {
            if (a.Length >= b.Length)
            {
                return a.Length;
            }
            else
            {
                return b.Length;
            }
        }

    }
}
