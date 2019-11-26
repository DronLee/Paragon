using SumInterpreter.Term;
using Xunit;

namespace UnitTestProject
{
    /// <summary>
    /// ����� ��� �������������� ���������.
    /// </summary>
    public class TermInterpreterTests
    {
        /// <summary>
        /// �������� ������������� ���������� ���������.
        /// </summary>
        /// <param name="termText">����� ����������.</param>
        /// <param name="expectedMultiplier">�������� ���������.</param>
        /// <param name="expectedVariable">��������� ����������.</param>
        /// <param name="expectedPower">��������� �������.</param>
        [Theory]
        [InlineData("1", 1, null, 1)]
        [InlineData("x", 1, "x", 1)]
        [InlineData("xy", 1, "xy", 1)]
        [InlineData("2xy", 2, "xy", 1)]
        [InlineData("xy^4", 1, "xy", 4)]
        [InlineData("3y^2", 3, "y", 2)]
        public void Interpret(string termText, decimal expectedMultiplier, string expectedVariable, int expectedPower)
        {
            var termInterpreter = new TermInterpreter();
            var result = termInterpreter.Interpret(termText);

            Assert.Equal(expectedMultiplier, result.Multiplier);
            Assert.Equal(expectedVariable, result.Variable);
            Assert.Equal(expectedPower, result.Power);
        }

        /// <summary>
        /// ��������, ��� ��� ������� ������������� ������������ ��������� ������� �������������� ����������.
        /// </summary>
        /// <param name="termText">����� ����������.</param>
        [Theory]
        [InlineData("xy4")]
        [InlineData("6^4")]
        [InlineData("^4")]
        public void Interpret_IncorrectTerm(string termText)
        {
            var termInterpreter = new TermInterpreter();

            Assert.Throws<IncorrectTermException>(() => termInterpreter.Interpret(termText));
        }
    }
}