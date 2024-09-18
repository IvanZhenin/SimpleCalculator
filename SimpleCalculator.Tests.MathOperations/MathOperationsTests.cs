using SimpleCalculator.Model;

namespace SimpleCalculator.Tests.MathOperations
{
    [TestClass]
    public class MathOperationsTests
    {
        [TestMethod]
        public void Addition_MaxValueAnd1_ReturnsMaxValue()
        {
            double a = double.MaxValue;
            double b = 1;
            double expected = double.MaxValue;

            double actual = MathFuncs.Addition(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Divide_0by0_ReturnsNaN()
        {
            double a = 0;
            double b = 0;
            double expected = double.NaN;

            double actual = MathFuncs.Divide(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Subtract_MaxValueFrom1_ReturnsMaxValue()
        {
            double a = double.MinValue;
            double b = 1;
            double expected = double.MinValue;

            double actual = MathFuncs.Subtract(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Multiply_MaxValueByMaxValue_ReturnsInfinity()
        {
            double a = double.MaxValue;
            double b = double.MaxValue;
            double expected = double.PositiveInfinity;

            double actual = MathFuncs.Multiply(a, b);

            Assert.AreEqual(expected, actual);
        }
    }
}