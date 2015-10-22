using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    public enum priority { low, med, high }
    
    public struct ServiceContracts
    {
        public uint fileNumber;
        public priority priority;
        
       public ServiceContracts (uint fileNumber, priority priority)
        {
            this.fileNumber = fileNumber;
            this.priority = priority;
        }
    }

    [TestClass]
    public class SortingPriorityInService
    {
        [TestMethod]
        public void TestMethod1()
        {
            ServiceContracts[] serviceFile = {
                                                new ServiceContracts(157, priority.low),
                                                new ServiceContracts(648, priority.med),
                                                new ServiceContracts(1420, priority.high),
                                                new ServiceContracts(496, priority.med),
                                                new ServiceContracts(618, priority.low),
                                                new ServiceContracts(987, priority.high)
                                                };
            ServiceContracts[] test = {
                                                new ServiceContracts(1420, priority.high),
                                                new ServiceContracts(987, priority.high),
                                                new ServiceContracts(648, priority.med),
                                                new ServiceContracts(496, priority.med),
                                                new ServiceContracts(157, priority.low),
                                                new ServiceContracts(618, priority.low)
                                                };
            ServiceContracts[] sortedByHighestPriority = SortByPriority(serviceFile);

            CollectionAssert.AreEqual(test, sortedByHighestPriority);
        }

        private ServiceContracts[] SortByPriority(ServiceContracts[] serviceFile)
        {
            for (int i = 1; i < serviceFile.Length; i++)
                for (int j = i; j > 0 && ((int)serviceFile[j].priority > (int)serviceFile[j - 1].priority); j--)
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
