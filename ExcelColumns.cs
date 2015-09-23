using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class ExcelColumns
    {
        [TestMethod]
        public void Test1()
        {
            int columnX = 13767;

            string columnActual = "TIM";
            string columnExpected = ChangeColumnXToLetters(columnX);
            Assert.AreEqual(columnExpected, columnActual);
        }

        [TestMethod]
        //Column 0
        public void Test2()
        {
            int columnX = 0;

            string columnActual = "No Excel Column";
            string columnExpected = ChangeColumnXToLetters(columnX);
            Assert.AreEqual(columnExpected, columnActual);
        }

        [TestMethod]
        //Excel Column limit is 16384 or XFD
        public void Test3()
        {
            int columnX = 16385;

            string columnActual = "No Excel Column";
            string columnExpected = ChangeColumnXToLetters(columnX);
            Assert.AreEqual(columnExpected, columnActual);
        }

        private string ChangeColumnXToLetters (int columnX)
        {
            if (columnX <= 0 || columnX > 16384)
            {
                return "No Excel Column";
            } else
            {
                string column = string.Empty;
                int deimpartit = columnX;
                do
                 {
                     int remainder = deimpartit % 26;
                     remainder--;
                     column = (char)('A' + remainder) + column;
                     deimpartit = deimpartit / 26;
                 } while (deimpartit != 0);
           
                return column;
            }
        }
    }
}
