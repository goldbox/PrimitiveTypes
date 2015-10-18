using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class PocketCalculator
    {
        [TestMethod]
        public void SimpleTest()
        {
            string[] initialExpression = new string[] { "/", "7", "2"};
            double mathResult = CalculateExpression(0, ref initialExpression);
            Assert.AreEqual(3.5, mathResult, 0.01);
        }

        [TestMethod]
        public void TestComplexExpression()
        {
            string[] initialExpression = new string[] { "-", "*", "4", "+", "2", "1", "*", "2", "-", "/", "6", "2", "+", "1", "1" };
            double mathResult = CheckErrorsAndDoTheMath(0, initialExpression);
            Assert.AreEqual(10, mathResult, 0.01);
        }

        [TestMethod]
        public void WrongExpression()
        {
            string[] initialExpression = new string[] { "1", "*", "4", "+", "2", "1", "*", "2", "-", "/", "6", "2", "+", "1", "1" };
            double mathResult = CheckErrorsAndDoTheMath(0, initialExpression);
            Assert.AreEqual(0, mathResult, 0.01);
        }

        [TestMethod]
        public void WrongOperators()
        {
            string[] initialExpression = new string[] { "-", "$", "4", "+", "2", "1", "*", "2", "-", "/", "6", "2", "+", "1", "1" };
            double mathResult = CheckErrorsAndDoTheMath(0, initialExpression);
            Assert.AreEqual(0, mathResult, 0.01);
        }

        private double CheckErrorsAndDoTheMath (int startingPoint, string[] initialExpression)
        {
            if (!IsOperator(initialExpression[startingPoint]))
                return 0;
            double result = CalculateExpression(startingPoint, ref initialExpression);
            return (initialExpression.Length == 1) ? result : 0 ;
        }

        private double CalculateExpression(int startingPoint, ref string[] initialExpression)
        {
            double firstOperand = 0 , secondOperand = 0;
            
            var first = initialExpression[startingPoint + 1];
            if (IsOperator(first))
                firstOperand = CalculateExpression(startingPoint + 1, ref initialExpression);
            else if (IsNumber(first))
                double.TryParse(first, out firstOperand);

            var mathOperator = initialExpression[startingPoint];

            var second = initialExpression[startingPoint + 2];
            if (IsOperator(second))
                secondOperand = CalculateExpression(startingPoint + 2, ref initialExpression);
            else if (IsNumber(second))
                double.TryParse(second, out secondOperand);

            double result = CalculateExpression(firstOperand, mathOperator, secondOperand);
            ReplaceAlreadyCalculatedWithResult(ref initialExpression, startingPoint, result);
            return result;
        }

        private double CalculateExpression(double first, string mathOperator, double second)
        {
            double result = 0;
            switch (mathOperator)
            {
                case "+":
                    result = first + second;
                    break;
                case "-":
                    result = first - second;
                    break;
                case "*":
                    result = first * second;
                    break;
                case "/":
                    result = first / second;
                    break;
                default:
                    break;
            }
            return result;

        }

        private bool IsOperator (string x)
        {
            if (x == "+" || x == "-" || x == "*" || x == "/")
                return true;
            return false;
        }

        private bool IsNumber(string x)
        {
            double d;
            bool result = double.TryParse(x, out d);
            return result;
        }

        private void ReplaceAlreadyCalculatedWithResult(ref string[] initialExpression, int startingPoint, double result)
        {
            string temp = string.Empty;
            temp += result;
            initialExpression[startingPoint] = temp;
            Array.Copy(initialExpression, startingPoint + 3, initialExpression, startingPoint + 1, initialExpression.Length - startingPoint - 3);
            
            Array.Resize(ref initialExpression, initialExpression.Length - 2);

        }
    }
}
