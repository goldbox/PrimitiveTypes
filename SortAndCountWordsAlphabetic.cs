using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{ 
    [TestClass]
    public class SortAndCountWordsAlphabetic
    {
        [TestMethod]
        public void SimpleTest()
        {
            string inputString = "zebra, horse, dog, cat, zebra, horse, dog, zebra, horse, zebra";
            TimDictionary[] testExpected = {
                                            new TimDictionary("zebra", 4),
                                            new TimDictionary("horse", 3),
                                            new TimDictionary("dog", 2),
                                            new TimDictionary("cat", 1),
                                                };

            TimDictionary[] animalsActual = CountAndSort(inputString);
            CollectionAssert.AreEqual(testExpected, animalsActual);
        }

        [TestMethod]
        public void TestPinkTryLyrics()
        {
            string inputString = "Ever ever wonder Wonder ever about what he's doing How it all turned to lies sometimes I think that it's better to never ask why where there is desire there is gonna be a flame where there is a flame someone's bound to get burned but just because it burns doesn't mean you're gonna die you've gotta get up and try, and try, and try gotta get up and try, and try, and try you gotta get up and try, and try, and try eh, eh, eh funny how the heart can be deceiving more than just a couple times why do we fall in love so easy? even when it's not right Where there is desire there is gonna be a flame Where there is a flame Someone's bound to get burned But just because it burns Doesn't mean you're gonna die You've gotta get up and try, and try, and try Gotta get up and try, and try, and try You gotta get up and try, and try, and try Ever worry that it might be ruined And does it make you wanna cry? When you're out there doing what you're doing Are you just getting by? Tell me are you just getting by, by, by? Where there is desire There is gonna be a flame Where there is a flame Someone's bound to get burned But just because it burns Doesn't mean you're gonna die You've gotta get up and try, and try, and try Gotta get up and try, and try, and try You gotta get up and try, and try, and try Gotta get up and try, and try, and try Gotta get up and try, and try, and try You gotta get up and try, and try, and try Gotta get up and try, and try, and try You gotta get up and try, and try, and try Gotta get up and try, and try, and try";

            TimDictionary[] pinkTry = CountAndSort(inputString);
        }

        private TimDictionary[] CountAndSort(string inputString)
        {
            string[] arrayInputString = ConvertStringToStringArray(inputString);
            TimDictionary[] countedWords = AddAndCountInDictionary(arrayInputString);
            TimDictionary[] sortedWords = SortByOccurency(countedWords);
            return sortedWords;
        }

        private TimDictionary[] AddAndCountInDictionary(string[] arrayInputString)
        {
            TimDictionary[] dictionary = { new TimDictionary(arrayInputString[0], 0) };
            foreach (string word in arrayInputString)
            {
                if (WordExist(word, dictionary))
                    dictionary[GiveMeIndex(word, dictionary)].occurency += 1;
                else
                    dictionary = AddWordInAlphabeticalOrder(dictionary, word);
            }
            return dictionary;
        }

        private TimDictionary[] AddWordInAlphabeticalOrder(TimDictionary[] dictionary, string word)
        {
            for (int i = 0; i < dictionary.Length; i++)
                if (ThisWordIsBeforeTheOneFromDictionary(word, dictionary[i].word))
                {
                    AddWordInDictionary(ref dictionary, word, i);
                    return dictionary;
                }
            AddWordInDictionary(ref dictionary, word, dictionary.Length - 1);
            return dictionary;
        }

        private bool ThisWordIsBeforeTheOneFromDictionary(string word, string iWordDictionary)
        {
            int index = 0;
            while (index < word.Length && index < iWordDictionary.Length)
            {
                if (word[index] > iWordDictionary[index])
                    return false;
                else if (word[index] < iWordDictionary[index])
                    return true;
                index++;
            }
            return true;
        }

        private void AddWordInDictionary(ref TimDictionary[] dictionary, string word, int i)
        {
            Array.Resize(ref dictionary, dictionary.Length + 1);
            IncrementWithOneAtPositionI(dictionary, i);
            dictionary[i].word = word;
            dictionary[i].occurency = 1;
        }

        private static void IncrementWithOneAtPositionI(TimDictionary[] dictionary, int i)
        {
            if (i < (dictionary.Length - 1))
                Array.Copy(dictionary, i, dictionary, i + 1, dictionary.Length - i - 1);
        }

        private void Swap(ref TimDictionary[] dictionary, int j)
        {
            var temp = dictionary[j];
            dictionary[j] = dictionary[j - 1];
            dictionary[j - 1] = temp;
        }

        private bool WordExist(string word, TimDictionary[] dictionary)
        {
            if (WordIsFirstOrLast(word, dictionary))
                return true;

            int lastIndex = dictionary.Length - 1;
            int firstIndex = 0;
            while (lastIndex - firstIndex > 1)
            {
                int halfIndex = (lastIndex + firstIndex) / 2;

                if (string.Equals(dictionary[halfIndex].word, word))
                    return true;
                if (ThisWordIsBeforeTheOneFromDictionary(word, dictionary[halfIndex].word))
                    lastIndex = halfIndex;
                else
                    firstIndex = halfIndex;
            }
            return false;
        }

        private static bool WordIsFirstOrLast(string word, TimDictionary[] dictionary)
        {
            int lastIndex = dictionary.Length - 1;
            int firstIndex = 0;
            return string.Equals(dictionary[lastIndex].word, word) ||
                            string.Equals(dictionary[firstIndex].word, word);
        }

        private int GiveMeIndex(string word, TimDictionary[] dictionary)
        {
            for (int i = 0; i < dictionary.Length; i++)
            {
                if (string.Equals(dictionary[i].word, word, StringComparison.CurrentCultureIgnoreCase))
                    return i;
            }
            return 0;
        }

        private string[] ConvertStringToStringArray(string inputString)
        {
            inputString = inputString.Replace("?", "").Replace(",", "").Replace("!", "");
            inputString = inputString.ToLower();
            return inputString.Split(' ');
        }

        private TimDictionary[] SortByOccurency(TimDictionary[] dictionary)
        {
            for (int i = 1; i < dictionary.Length; i++)
                for (int j = i; j > 0 && (dictionary[j].occurency > dictionary[j - 1].occurency); j--)
                    Swap(ref dictionary, j);
            return dictionary;
        }
    }
}
