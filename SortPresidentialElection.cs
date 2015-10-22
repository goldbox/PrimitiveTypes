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
            PollingStation[] finalResult = new PollingStation[4];
            finalResult = AddThisPollingStation(clujGheorgheni, finalResult);
        }

        public PollingStation[] AddThisPollingStation(PollingStation[] newArrivedPolling, PollingStation[] finalResult)
        {
            finalResult = AddNewVotesToFinal(newArrivedPolling, finalResult);
            //finalResult = SortUsingNumberOfVotes(finalResult);
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

        }

    }
}
