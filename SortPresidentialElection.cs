using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    public struct PollingStation
    {
        public string name;
        public int numberOfVotes;
        public PollingStation(string name, int numberOfVotes)
        {
            this.name = name;
            this.numberOfVotes = numberOfVotes;
        }
    }
    [TestClass]
    public class SortPresidentialElection
    {
        [TestMethod]
        public void TestMethod1()
        {
            PollingStation[] clujGheorgheni = {
                                                new PollingStation("Mihai Eminescu", 479),
                                                new PollingStation("Lucian Blaga", 413),
                                                new PollingStation("Ion Creanga", 348),
                                                new PollingStation("Mircea Eliade", 245)
                                                };
            PollingStation[] clujMarasti = {
                                                new PollingStation("Lucian Blaga", 894),
                                                new PollingStation("Mihai Eminescu", 786),
                                                new PollingStation("Mircea Eliade", 461),
                                                new PollingStation("Ion Creanga", 289)
                                                };
            PollingStation[] clujManastur = {
                                                new PollingStation("Ion Creanga", 764),
                                                new PollingStation("Mircea Eliade", 582),
                                                new PollingStation("Mihai Eminescu", 497),
                                                new PollingStation("Lucian Blaga", 346)
                                                };
            PollingStation[] test = {
                                                new PollingStation("Mihai Eminescu", 1762),
                                                new PollingStation("Lucian Blaga", 1653),
                                                new PollingStation("Ion Creanga", 1401),
                                                new PollingStation("Mircea Eliade", 1288),
                                                };
            PollingStation[] finalResult = new PollingStation[0];
            finalResult = AddThisPollingStation(clujGheorgheni, finalResult);
            finalResult = AddThisPollingStation(clujManastur, finalResult);
            finalResult = AddThisPollingStation(clujMarasti, finalResult);
            CollectionAssert.AreEqual(test, finalResult);
        }

        public PollingStation[] AddThisPollingStation(PollingStation[] newArrivedPolling, PollingStation[] finalResult)
        {
            finalResult = AddNewVotesToFinal(newArrivedPolling, finalResult);
            finalResult = SortUsingNumberOfVotes(finalResult);
            return finalResult;
        }

        public PollingStation[] AddNewVotesToFinal (PollingStation[] newPolling, PollingStation[] finalResult)
        {
            foreach(var candidate in newPolling)
                AddVotesForThisCandidate(candidate, ref finalResult);
            return finalResult;
        }

        public void AddVotesForThisCandidate(PollingStation candidate, ref PollingStation[] finalResult)
        {
            bool nameMissing = true;
            var lastIndex = finalResult.Length;
            for (int i = 0; i < lastIndex; i++)
                if (string.Equals(finalResult[i].name, candidate.name))
                {
                    nameMissing = false;
                    finalResult[i].numberOfVotes += candidate.numberOfVotes;
                }
            if (nameMissing)
            {
                Array.Resize(ref finalResult, lastIndex + 1);
                finalResult[lastIndex].name = candidate.name;
                finalResult[lastIndex].numberOfVotes = candidate.numberOfVotes; 
            }
        }

        public PollingStation[] SortUsingNumberOfVotes(PollingStation[] finalResult)
        {
            for (int i = 1; i < finalResult.Length; i++)
                for (int j = i; j > 0 && (finalResult[j].numberOfVotes > finalResult[j - 1].numberOfVotes); j--)
                    Swap(ref finalResult, j);
            return finalResult;
        }

        private void Swap(ref PollingStation[] finalResult, int j)
        {
            var temp = finalResult[j];
            finalResult[j] = finalResult[j - 1];
            finalResult[j - 1] = temp;
        }


    }
}
