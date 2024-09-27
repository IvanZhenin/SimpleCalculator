using SimpleCalculator.Helpers;

namespace SimpleCalculator.Tests.StringExpressionsChecker
{
    [TestClass]
    public class StringExpressionsChecker
    {
        [TestMethod]
        public void Input_CorrectExpression_ToCheckBracketsBalance_ReturnTrue()
        {
            bool actual = ExpressionChecker.IsBalancedBrackets("(-4)*(-2)");
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Input_UncorrectExpression_ToCheckBracketsBalance_ReturnFalse()
        {
            bool actual = ExpressionChecker.IsBalancedBrackets("((42+2)");
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Input_CorrectExpression_ToCheckOperationsBalance_ReturnTrue()
        {
            bool actual = ExpressionChecker.IsBalancedOperations("(-4)*(-2)");
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Input_UncorrectExpression_ToCheckOperationsBalance_ReturnFalse()
        {
            bool actual = ExpressionChecker.IsBalancedOperations("-2+4*");
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Input_UncorrectExpression_ToCheckInvalidText_ReturnTrue()
        {
            bool actual = ExpressionChecker.IsInvalidText("4f+b2");
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Input_CorrectExpression_ToCheckInvalidText_ReturnFalse()
        {
            bool actual = ExpressionChecker.IsInvalidText("4,78+(-4,2)");
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Input_CorrectExpression_ToCheckCommasBalance_ReturnTrue()
        {
            bool actual = ExpressionChecker.IsBalancedCommas("4,09+9,42-(-9)"); 
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Input_UncorrectExpression_ToCheckCommasBalance_ReturnFalse()
        {
            bool actual = ExpressionChecker.IsBalancedCommas("8,,9+3,,,5");
            Assert.IsFalse(actual);
        }
    }
}