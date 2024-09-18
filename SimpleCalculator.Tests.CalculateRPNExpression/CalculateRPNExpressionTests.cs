using SimpleCalculator.ViewModel;

namespace SimpleCalculator.Tests.CalculateRPNExpression
{
    [TestClass]
    public class CalculateRPNExpressionTests
    {
        [TestMethod]
        public void Calculate_CorrentRpnExpression1_Returns4()
        {
            double exptected = 4;
            double actual = CalculatorViewModel.Counting("2 2 +");

            Assert.AreEqual(exptected, actual);
        }

        [TestMethod]
        public void Calculate_CorrentRpnExpression2_Returns22790803()
        {
            double exptected = 22790803;
            double actual = CalculatorViewModel.Counting("65 5 * 51 * 25 * 55 * -35 5 * - -3 - ");

            Assert.AreEqual(exptected, actual);
        }

        [TestMethod]
        public void Calculate_UncorrectRpnExpression1_ReturnsNan()
        {
            double exptected = double.NaN;
            double actual = CalculatorViewModel.Counting("2 2 + +");

            Assert.AreEqual(exptected, actual);
        }

        [TestMethod]
        public void Calculate_UncorrectRpnExpression2_ReturnsNan()
        {
            double exptected = double.NaN;
            double actual = CalculatorViewModel.Counting("0 0 /");

            Assert.AreEqual(exptected, actual);
        }
    }
}