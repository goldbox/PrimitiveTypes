using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class SortingLotto
    {
        [TestMethod]
        public void TestLottoRandom()
        {
            int[] lottoExtraction = new int[] { 9, 4, 15, 48, 35, 16 };
            int[] sortedLotto = SortUsingInsertion(lottoExtraction);
            Array.Sort(lottoExtraction);
            CollectionAssert.AreEqual(lottoExtraction, sortedLotto);
        }

        [TestMethod]
        public void TestLottoWorstCase()
        {
            int[] lottoExtraction = new int[] { 48, 35, 16, 15, 9, 4 };
            int[] sortedLotto = SortUsingInsertion(lottoExtraction);
            Array.Sort(lottoExtraction);
            CollectionAssert.AreEqual(lottoExtraction, sortedLotto);
        }

        private int[] SortUsingInsertion(int[] lottoNumbers)
        {
            for (int i = 1; i < lottoNumbers.Length; i++)
                for (int k = i; k > 0 && (lottoNumbers[k] < lottoNumbers[k - 1]); k--)
                    Swap(ref lottoNumbers, k);
            return lottoNumbers;

        }

        private void Swap (ref int[] lottoNumbers, int k)
        {
            var temp = lottoNumbers[k];
            lottoNumbers[k] = lottoNumbers[k - 1];
            lottoNumbers[k - 1] = temp;
        }
    }
}
