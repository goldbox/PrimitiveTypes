using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class SortingLotto
    {
        [TestMethod]
        public void TestLottoRandomInsertion()
        {
            int[] lottoExtraction = new int[] { 9, 4, 15, 48, 35, 16 };
            int[] test = new int[] { 4, 9, 15, 16, 35, 48 };
            Array.Sort(test);

            int[] sortedLotto = SortUsingInsertion(lottoExtraction);
            
            CollectionAssert.AreEqual(test, sortedLotto);
        }

        [TestMethod]
        public void TestLottoWorstCaseInsertion()
        {
            int[] lottoExtraction = new int[] { 48, 35, 16, 15, 9, 4 };
            int[] test = new int[] { 48, 35, 16, 15, 9, 4 };
            Array.Sort(test);
            
            int[] sortedLotto = SortUsingInsertion(lottoExtraction);

            CollectionAssert.AreEqual(test, sortedLotto);
        }

        [TestMethod]
        public void TestLottoRandomMerge()
        {
            int[] lottoExtraction = new int[] { 9, 4, 15, 48, 35, 16 };
            int[] test = new int[] { 4, 9, 15, 16, 35, 48 };
            Array.Sort(test);

            int[] sortedLotto = SortUsingMerge(lottoExtraction);

            CollectionAssert.AreEqual(test, sortedLotto);
        }

        [TestMethod]
        public void TestLottoWorstCaseMerge()
        {
            int[] lottoExtraction = new int[] { 48, 35, 16, 15, 9, 4 };
            int[] test = new int[] { 48, 35, 16, 15, 9, 4 };
            Array.Sort(test);

            int[] sortedLotto = SortUsingMerge(lottoExtraction);

            CollectionAssert.AreEqual(test, sortedLotto);
        }

        private int[] SortUsingInsertion(int[] lottoNumbers)
        {
            for (int i = 1; i < lottoNumbers.Length; i++)
                for (int k = i; k > 0 && (lottoNumbers[k] < lottoNumbers[k - 1]); k--)
                    Swap(ref lottoNumbers, k);
            return lottoNumbers;

        }

        private void Swap(ref int[] lottoNumbers, int k)
        {
            var temp = lottoNumbers[k];
            lottoNumbers[k] = lottoNumbers[k - 1];
            lottoNumbers[k - 1] = temp;
        }

        private int[] SortUsingMerge(int[] lottoExtraction)
        {
            if (lottoExtraction.Length <= 1)
                return lottoExtraction;

            int half = lottoExtraction.Length / 2 - 1;

            int[] firstHalf = GiveMeHalf(lottoExtraction, 0, half);
            int[] secondHalf = GiveMeHalf(lottoExtraction, half + 1, lottoExtraction.Length - 1);

            firstHalf = SortUsingMerge(firstHalf);
            secondHalf = SortUsingMerge(secondHalf);

            lottoExtraction = MergeArray(firstHalf, secondHalf);

            return lottoExtraction;
        }

        private int[] GiveMeHalf(int[] initial, int iMin, int iMax)
        {
            Array.Copy(initial, iMin, initial, 0, iMax - iMin + 1);
            Array.Resize(ref initial, iMax - iMin + 1);
            return initial;
        }

        private int[] MergeArray(int[] firstHalf, int[] secondhalf)
        {
            int[] result = new int[firstHalf.Length + secondhalf.Length];
            int x = 0, y = 0, z = 0;
            while (x < firstHalf.Length || y < secondhalf.Length)
            {
                if (IsLessThen(firstHalf, x, secondhalf, y))
                {
                    result[z++] = firstHalf[x++];
                }
                else
                {
                    result[z++] = secondhalf[y++];
                }
            }
            return result;
        }

        private static bool IsLessThen(int[] firstHalf, int x, int[] secondHalf, int y)
        {
            var isFirstHalfDone = IsDone(firstHalf, x);
            var isSecondHalfDone = IsDone(secondHalf, y);
            if (isFirstHalfDone) return false;
            if (isSecondHalfDone) return true;
            return firstHalf[x] <= secondHalf[y];
        }

        private static bool IsDone(int[] firstHalf, int index)
        {
            return index >= firstHalf.Length;
        }
    }
}
