using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    public struct ServiceContracts
    {
        public uint fileNumber;
        public string priority;
        public int priorityNumber;

        public ServiceContracts (uint fileNumber, string priority)
        {
            this.fileNumber = fileNumber;
            this.priority = priority;
            switch (priority)
            {
                case "high":
                    this.priorityNumber = 3;
                    break;
                case "med":
                    this.priorityNumber = 2;
                    break;
                case "low":
                    this.priorityNumber = 1;
                    break;
                default:
                    this.priorityNumber = 0;
                    break; 
            }
        }
    }
    [TestClass]
    public class SortingPriorityInService
    {
        [TestMethod]
        public void TestMethod1()
        {
            ServiceContracts[] serviceFile = {
                                                new ServiceContracts(157, "low"),
                                                new ServiceContracts(648, "med"),
                                                new ServiceContracts(1420, "high"),
                                                new ServiceContracts(496, "med"),
                                                new ServiceContracts(618, "low"),
                                                new ServiceContracts(987, "high")
                                                };
            ServiceContracts[] test = {
                                                new ServiceContracts(1420, "high"),
                                                new ServiceContracts(987, "high"),
                                                new ServiceContracts(648, "med"),
                                                new ServiceContracts(496, "med"),
                                                new ServiceContracts(157, "low"),
                                                new ServiceContracts(618, "low"),
                                                };
            ServiceContracts[] sortedByHighestPriority = SortByPriority(serviceFile);

            CollectionAssert.AreEqual(test, sortedByHighestPriority);
        }

        private ServiceContracts[] SortByPriority(ServiceContracts[] serviceFile)
        {
            for (int i = 1; i < serviceFile.Length; i++)
                for (int j = i; j > 0 && (serviceFile[j].priorityNumber > serviceFile[j - 1].priorityNumber); j--)
                    Swap(ref serviceFile, j);
            return serviceFile;
        }

        private void Swap(ref ServiceContracts[] serviceFile, int j)
        {
            var temp = serviceFile[j];
            serviceFile[j] = serviceFile[j - 1];
            serviceFile[j - 1] = temp;
        }

    }
}
