using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    //Crypt And Decrypt a text. Number Of columns accepted must be between 2 - 9. 
    //Text lenght have to be at least double than number of columns
    [TestClass]
    public class CryptDecryptText
    {
        [TestMethod]
        public void TestWithInitialData()
        {
            string initialText = "nicaieri nu e ca acasa";
            int numberOfColumns = 4;

            string cryptedText = CryptText(initialText, ref numberOfColumns);
            string decryptedText = DecryptText(cryptedText, numberOfColumns);
            Assert.AreEqual(initialText, decryptedText);
        }

        [TestMethod]
        public void TestWithOnlyOneColumn()
        {
            string initialText = "nicaieri nu e ca acasa";
            int numberOfColumns = 1;

            string cryptedText = CryptText(initialText, ref numberOfColumns);
            string decryptedText = DecryptText(cryptedText, numberOfColumns);
            Assert.AreEqual("Error", decryptedText);
        }

        [TestMethod]
        public void TestIfNumberOfColumnsAreMoreThanNine()
        {
            string initialText = "nicaieri nu e ca acasa";
            int numberOfColumns = 10;

            string cryptedText = CryptText(initialText, ref numberOfColumns);
            string decryptedText = DecryptText(cryptedText, numberOfColumns);
            Assert.AreEqual("Error", decryptedText);
        }

        [TestMethod]
        public void TestIfLenghtOfInitialTextIsNotDoubleThanNumberOfColumns()
        {
            string initialText = "123456";
            int numberOfColumns = 4;

            string cryptedText = CryptText(initialText, ref numberOfColumns);
            string decryptedText = DecryptText(cryptedText, numberOfColumns);
            Assert.AreEqual("Error", decryptedText);
        }


        private string CryptText(string initialText, ref int numberOfColumns)
        {
            CheckInitialValues(ref initialText, ref numberOfColumns);
            string space = "replace spaces";
            PlaceOrReplaceSpacesInText(ref initialText, space);
            AddRandomCharactersIfNeeded(ref initialText, numberOfColumns);
            var cryptOrDecrypt = "Crypt Text";
            var cryptedText = CryptDecryptTextUsingNumberOfColumns(initialText, numberOfColumns, cryptOrDecrypt);

            return cryptedText;
        }

        private void CheckInitialValues(ref string initialText, ref int numberOfColumns)
        {
            if (numberOfColumns < 2 || 
                numberOfColumns > 9 ||
                initialText.Length / 2 < numberOfColumns)
            {
                initialText = "Error";
                numberOfColumns = 2;
            } 

        }

        private string DecryptText(string cryptedText, int numberOfColumns)
        {
            //int textLenght = cryptedText.Length;
            //int numberOfRows = textLenght / numberOfColumns;
            var cryptOrDecrypt = "Decrypt Text";
            var decryptedText = CryptDecryptTextUsingNumberOfColumns(cryptedText, numberOfColumns, cryptOrDecrypt);
            RemoveRandomCharacters(ref decryptedText);
            string space = "place spaces";
            PlaceOrReplaceSpacesInText(ref decryptedText, space);
            return decryptedText;
        }

        private void PlaceOrReplaceSpacesInText(ref string text, string space)
        {
            if(space == "replace spaces")
            {
                text = text.Replace(" ", "qz");
            } else if (space == "place spaces")
            {
                text = text.Replace("qz", " ");
            }
        }

        private void AddRandomCharactersIfNeeded (ref string initialText, int numberofColumns)
        {
            int textLenght = initialText.Length;
            if (textLenght % numberofColumns != 0)
            {
                int numberOfNeededRandomChars = ((textLenght / numberofColumns + 1) * numberofColumns) - textLenght;
                initialText = numberOfNeededRandomChars + initialText + AddRandomCharsAtTheEnd(numberOfNeededRandomChars);
            }
        }

        private void RemoveRandomCharacters(ref string decryptedText)
        {
            string s = decryptedText.Substring(0, 1);
            int firstCharInDecryptedText;
            Int32.TryParse(s, out firstCharInDecryptedText);
            if (firstCharInDecryptedText == 1)
            {
                decryptedText = decryptedText.Substring(1);
            } else if (firstCharInDecryptedText > 1 && 
                        firstCharInDecryptedText <= 9)
            {
              int initialTextLenght = decryptedText.Length - firstCharInDecryptedText;                           
              decryptedText = decryptedText.Substring(1, initialTextLenght);
            }
        }

        private string AddRandomCharsAtTheEnd(int numberOfNeededRandomChars)
        {
            char[] letters = "qwertyuiopasdfghjklzxcvbnm0123456789".ToCharArray();
            Random r = new Random();
            string randomString = string.Empty;
            numberOfNeededRandomChars--;
            for (int i = 0; i < numberOfNeededRandomChars; i++)
            {
                randomString += letters[r.Next(0, 35)].ToString();
            }
            return randomString;
        }

        private string CryptDecryptTextUsingNumberOfColumns (string initialText, int numberOfColumns, string cryptOrDecrypt)
        {
            string resultedText = string.Empty;
            int textLenght = initialText.Length;
            int numberOfRows = 0;
            AssignRightValuesForCryptOrDecrypt(ref numberOfColumns, ref numberOfRows, cryptOrDecrypt, textLenght);

            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    int a = i + j * numberOfRows;
                    resultedText = resultedText + initialText[a];
                }

            }
            return resultedText;
        }

        private static void AssignRightValuesForCryptOrDecrypt(ref int numberOfColumns, ref int numberOfRows, string cryptOrDecrypt, int textLenght)
        {
            if (cryptOrDecrypt == "Crypt Text")
            {
                numberOfRows = textLenght / numberOfColumns;
            }
            else
            {
                numberOfRows = numberOfColumns;
                numberOfColumns = textLenght / numberOfRows;
            }
        }
    }
}
