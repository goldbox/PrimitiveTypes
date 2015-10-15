using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class ReverseStringAndReplaceOneChar
    {
        [TestMethod]
        public void ReverseAStringAndReplaceOneChar()
        {
            string initialString = "Nicaieri nu e ca acasa";
            char initialChar = 'r';
            char replacedChar = 'x';

            string reversedString = ReverseInitialString(initialString, initialChar, replacedChar);
            Assert.AreEqual("asaca ac e un ixeiaciN", reversedString);
        }

        [TestMethod]
        public void TestEmptyString()
        {
            string initialString = "";
            char initialChar = 't';
            char replacedChar = 'x';

            string reversedString = ReverseInitialString(initialString, initialChar, replacedChar);
            Assert.AreEqual("", reversedString);
        }

        private string ReverseInitialString(string initialString, char initialChar, char replacedChar)
        {
            if (initialString == "")
                return "";
            var x = initialString.Length - 1;
            var substring = initialString.Substring(0, x);
            char lastChar = GiveMeLastChar(initialString, initialChar, replacedChar, x);
            return lastChar + ReverseInitialString(substring, initialChar, replacedChar);
        }

        private static char GiveMeLastChar(string initialString, char initialChar, char replacedChar, int x)
        {
            return (initialString[x] == initialChar) ? replacedChar : initialString[x];
        }
    }
}
