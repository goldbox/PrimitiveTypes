using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class CryptDecryptText
    {
        public CryptDecryptText()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        [TestMethod]
        public void TestMethod1()
        {
            string initialText = "nicaieri nu e ca acasa";
            int numberOfColumns = 4;

            string cryptedText = CryptInitialText(initialText, numberOfColumns);
            Assert.AreEqual("abc", cryptedText);
        }

        public string CryptInitialText (string initialText, int numberOfColumns)
        {
            string cryptedText = CryptText(initialText, numberOfColumns);
            return cryptedText;
        }

        private string CryptText(string initialText, int numberOfColumns)
        {
            EliminateSpacesFromText(ref initialText);
            AddRandomCharactersIfNeeded(ref initialText, numberOfColumns);
            var cryptedText = CryptTextUsingNumberOfColumns(initialText, numberOfColumns);

            return cryptedText;
        }

        private void EliminateSpacesFromText(ref string initialText)
        {
            initialText = initialText.Replace(" ", "");
        }

        private string GiveRandomChars(int numberOfNeededRandomChars)
        {
            char[] letters = "qwertyuiopasdfghjklzxcvbnm".ToCharArray();
            Random r = new Random();
            string randomString = string.Empty;
            for (int i = 0; i < numberOfNeededRandomChars; i++)
            {
                randomString += letters[r.Next(0, 25)].ToString();
            }
            return randomString;
        }

        private void AddRandomCharactersIfNeeded (ref string initialText, int numberofColumns)
        {
            int textLenght = initialText.Length;
            if (textLenght % numberofColumns != 0)
            {
                int numberOfNeededRandomChars = ((textLenght / numberofColumns + 1) * numberofColumns) - textLenght;
                initialText = initialText + GiveRandomChars(numberOfNeededRandomChars);
            }
        }

        private string CryptTextUsingNumberOfColumns (string initialText, int numberOfColumns)
        {
            string cryptedText = string.Empty;
            int textLenght = initialText.Length;
            int numberOfRows = textLenght / numberOfColumns;
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    int a = i + j * numberOfRows;
                    cryptedText = cryptedText + initialText[a];
                }

            }
            return cryptedText;
        }
    }
}
