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
            char forbiddenChar = 'r';
            char replacedChar = 'x';

            string reversedString = ReverseInitialString(initialString, forbiddenChar, replacedChar);
            Assert.AreEqual("asaca ac e un ixeiaciN", reversedString);
        }

        [TestMethod]
        public void TestEmptyString()
        {
            string initialString = "";
            char forbiddenChar = 't';
            char replacedChar = 'x';

            string reversedString = ReverseInitialString(initialString, forbiddenChar, replacedChar);
            Assert.AreEqual("", reversedString);
        }

        private string ReverseInitialString(string initialString, char forbiddenChar, char replacedChar)
        {
            if (initialString == "")
                return "";
            var lastPosition = initialString.Length - 1;
            var substring = initialString.Substring(0, lastPosition);
            char lastChar = initialString[lastPosition];
            ReplaceForbiddenChar(ref lastChar, forbiddenChar, replacedChar);

            return lastChar + ReverseInitialString(substring, forbiddenChar, replacedChar);
        }

        private static void ReplaceForbiddenChar(ref char lastChar, char forbiddenChar, char replacedChar)
        {
            if (lastChar == forbiddenChar)
                lastChar = replacedChar;
        }
    }
}
