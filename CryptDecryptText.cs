using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    
    [TestClass]
    public class CryptDecryptText
    {
        [TestMethod]
        public void TestMethod1()
        {
            string initialText = "nicaieri nu e ca acasa";
            int numberOfColumns = 2;

            string cryptedText = CryptText(initialText, numberOfColumns);
            string decryptedText = DecryptText(cryptedText, numberOfColumns);
            Assert.AreEqual(initialText, decryptedText);
        }

        private string CryptText(string initialText, int numberOfColumns)
        {
            string space = "replace spaces";
            PlaceOrReplaceSpacesInText(ref initialText, space);
            AddRandomCharactersIfNeeded(ref initialText, numberOfColumns);
            var cryptedText = CryptDecryptTextUsingNumberOfColumns(initialText, numberOfColumns);

            return cryptedText;
        }

        private string DecryptText(string cryptedText, int numberOfColumns)
        {
            int textLenght = cryptedText.Length;
            int numberOfRows = textLenght / numberOfColumns;
            var decryptedText = CryptDecryptTextUsingNumberOfColumns(cryptedText, numberOfRows);
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
                initialText = numberOfNeededRandomChars + initialText + GiveRandomChars(numberOfNeededRandomChars);
            }
        }

        private void RemoveRandomCharacters(ref string decryptedText)
        {

            int first = Convert.ToInt32(decryptedText[0]);
            first -= 48;
            if (first == 1)
            {
                decryptedText = decryptedText.Substring(1);
            } else if (first <= 9)
            {
              int initialTextLenght = decryptedText.Length - first;                           
              decryptedText = decryptedText.Substring(1, initialTextLenght);
            }
        }

        private string GiveRandomChars(int numberOfNeededRandomChars)
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


        private string CryptDecryptTextUsingNumberOfColumns (string initialText, int numberOfColumns)
        {
            string resultedText = string.Empty;
            int textLenght = initialText.Length;
            int numberOfRows = textLenght / numberOfColumns;
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
    }
}
