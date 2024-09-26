using SimpleCalculator.RPNCalculator;

namespace SimpleCalculator.Tests.StringRPNConvertation
{
    [TestClass]
    public class StringRPNConvertsTests
    {
        /// <summary>
        /// ���� ����������� ������ "2+2*2" � "2 2 2 * +"
        /// </summary>
        [TestMethod]
        public void Convert_Expression1_ToRpn_ReturnsCorrectRpn()
        {
            string input = "2+2*2";
            string expected = "2 2 2 * + ";

            string actual = RPNConverter.Convert(input);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// ���� ����������� ������ "(2+2)*2" � "2 2 + 2 *"
        /// </summary>
        [TestMethod]
        public void Convert_Expression2_ToRpn_ReturnsCorrectRpn()
        {
            string input = "(2+2)*2";
            string expected = "2 2 + 2 * ";

            string actual = RPNConverter.Convert(input);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// ���� ����������� ������ "(-4)*(-2)" � "-4 -2 *"
        /// </summary>
        [TestMethod]
        public void Convert_Expression3_ToRpn_ReturnsCorrectRpn()
        {
            string input = "(-4)*(-2)";
            string expected = "-4 -2 * ";

            string actual = RPNConverter.Convert(input);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// ���� ����������� ������ "65*5*51*25*55-(-35)*5-(-3)"
        /// </summary>
        [TestMethod]
        public void Convert_Expression4_ToRpn_ReturnsCorrectRpn()
        {
            string input = "65*5*51*25*55-(-35)*5-(-3)";
            string expected = "65 5 * 51 * 25 * 55 * -35 5 * - -3 - ";

            string actual = RPNConverter.Convert(input);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// ���� ������������� ����� � ������
        /// </summary>
        [TestMethod]
        public void Convert_UncorrectText_ToRpn_ReturnsEmpty()
        {
            string input = "fkdsoafo333fd--!11";
            string expected = string.Empty;

            string actual = RPNConverter.Convert(input);

            Assert.AreEqual(expected, actual);
        }
    }
}