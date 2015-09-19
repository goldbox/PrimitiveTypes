using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    // vrei să iei un credit de 40k euro de la bancă
    // dobânda anuală cerută de bancă e de 7.57%
    // creditul e pentru o perioadă de 20 ani
    // contractul prevede restituirea în rate descrescătoare

    // calculează ce rată trebuie plătită în luna martie din al celui de al 4-lea an?
    // generalizează pentru orice sumă, perioadă și dobândă<summary>
    
    [TestClass]
    public class BankInterest
    {
        [TestMethod]
        //Test with initial values
        public void Test1()
        {
            double creditTotalAmmount = 40000;
            int creditPeriodYears = 20;
            double creditAnualInterest = 7.57;
            int monthNumberX = 5;
            double bankRateMonthX_Expected = 414.79;
            double bankRateMonthX_Actual = BankRate(creditTotalAmmount, creditPeriodYears, creditAnualInterest, monthNumberX);

            Assert.AreEqual(bankRateMonthX_Expected, bankRateMonthX_Actual);
        }

        [TestMethod]
        //Credit ammount is 0 or less than 0
        public void Test2()
        {
            double creditTotalAmmount = 0;
            int creditPeriodYears = 20;
            double creditAnualInterest = 7.57;
            int monthNumberX = 5;
            double bankRateMonthX_Expected = 0;
            double bankRateMonthX_Actual = BankRate(creditTotalAmmount, creditPeriodYears, creditAnualInterest, monthNumberX);

            Assert.AreEqual(bankRateMonthX_Expected, bankRateMonthX_Actual);
        }

        [TestMethod]
        //Credit period have to be at least one year
        public void Test3()
        {
            double creditTotalAmmount = 40000;
            int creditPeriodYears = 0;
            double creditAnualInterest = 7.57;
            int monthNumberX = 5;
            double bankRateMonthX_Expected = 0;
            double bankRateMonthX_Actual = BankRate(creditTotalAmmount, creditPeriodYears, creditAnualInterest, monthNumberX);

            Assert.AreEqual(bankRateMonthX_Expected, bankRateMonthX_Actual);
        }

        [TestMethod]
        //Credit maximum period is 35 years
        public void Test4()
        {
            double creditTotalAmmount = 40000;
            int creditPeriodYears = 150;
            double creditAnualInterest = 7.57;
            int monthNumberX = 5;
            double bankRateMonthX_Expected = 0;
            double bankRateMonthX_Actual = BankRate(creditTotalAmmount, creditPeriodYears, creditAnualInterest, monthNumberX);

            Assert.AreEqual(bankRateMonthX_Expected, bankRateMonthX_Actual);
        }

        [TestMethod]
        //Bank interest have to be more than 0 %
        public void Test5()
        {
            double creditTotalAmmount = 40000;
            int creditPeriodYears = 20;
            double creditAnualInterest = 0;
            int monthNumberX = 5;
            double bankRateMonthX_Expected = 0;
            double bankRateMonthX_Actual = BankRate(creditTotalAmmount, creditPeriodYears, creditAnualInterest, monthNumberX);

            Assert.AreEqual(bankRateMonthX_Expected, bankRateMonthX_Actual);
        }

        [TestMethod]
        //Bank interest is up to 100 %
        public void Test6()
        {
            double creditTotalAmmount = 40000;
            int creditPeriodYears = 20;
            double creditAnualInterest = 101;
            int monthNumberX = 5;
            double bankRateMonthX_Expected = 0;
            double bankRateMonthX_Actual = BankRate(creditTotalAmmount, creditPeriodYears, creditAnualInterest, monthNumberX);

            Assert.AreEqual(bankRateMonthX_Expected, bankRateMonthX_Actual);
        }

        [TestMethod]
        //The monthly payment have to be only in the credit period.  
        public void Test7()
        {
            double creditTotalAmmount = 40000;
            int creditPeriodYears = 20;
            double creditAnualInterest = 7.57;
            int monthNumberX = 241;
            double bankRateMonthX_Expected = 0;
            double bankRateMonthX_Actual = BankRate(creditTotalAmmount, creditPeriodYears, creditAnualInterest, monthNumberX);

            Assert.AreEqual(bankRateMonthX_Expected, bankRateMonthX_Actual);
        }

        [TestMethod]
        //The monthly payment have to start with month 1
        public void Test8()
        {
            double creditTotalAmmount = 40000;
            int creditPeriodYears = 20;
            double creditAnualInterest = 7.57;
            int monthNumberX = 0;
            double bankRateMonthX_Expected = 0;
            double bankRateMonthX_Actual = BankRate(creditTotalAmmount, creditPeriodYears, creditAnualInterest, monthNumberX);

            Assert.AreEqual(bankRateMonthX_Expected, bankRateMonthX_Actual);
        }


        private double BankRate(double creditTotalAmmount, int creditPeriodYears, double creditAnualInterest, int monthNumberX)
        {
            int creditPeriodMonths = creditPeriodYears * 12;
            //Check if the Credit makes any sense. 
            if(creditTotalAmmount <= 0 || creditPeriodYears <= 0 || creditPeriodYears > 35 || creditAnualInterest <= 0 || creditAnualInterest > 100 || monthNumberX <= 0 || monthNumberX > creditPeriodMonths)
            {
                return 0;
            } else
            {
                double creditMonthlyPaymentWithoutInterest = creditTotalAmmount / creditPeriodMonths;
                int monthsAlreadyPayed = monthNumberX - 1;
                double creditSoldInMonthX = creditTotalAmmount - creditMonthlyPaymentWithoutInterest * monthsAlreadyPayed;

                //Interest for a particular month is the remaining sold * anual interest / divided by 12.
                double creditInterestInMonthX = creditSoldInMonthX * creditAnualInterest / 100 / 12;
                //We have to add the monthly payment from sold to the computed monthly interest
                double bankRate = creditMonthlyPaymentWithoutInterest + creditInterestInMonthX;

                return Math.Round(bankRate, 2);
            }
        }
    }
}
