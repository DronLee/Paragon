using SumInterpreter;
using SumInterpreter.Term;
using Xunit;

namespace UnitTestProject
{
    public class ExpressionTests
    {
        /// <summary>
        /// Проверка нормализации выражения.
        /// </summary>
        /// <param name="firstTermMultiplier">Множитель первого слагаемого.</param>
        /// <param name="expected">Ожидаемое нормализованное выражение.</param>
        [Theory]
        [InlineData(1, "-y^2 + 4.5xy - 2 = 0")]
        [InlineData(2, "x^2 - y^2 + 4.5xy - 2 = 0")]
        [InlineData(3, "2x^2 - y^2 + 4.5xy - 2 = 0")]
        [InlineData(-1, "-2x^2 - y^2 + 4.5xy - 2 = 0")]
        public void Normalization(decimal firstTermMultiplier, string expected)
        {
            // Составляем выражение: [firstTermMultiplier]x^2 + 3.5xy + y - x^2 = y^2 + 2 - xy + y
            var expression = new Expression
            {
                LeftPart = new[]
                {
                    new TermStruct { Multiplier = firstTermMultiplier, Power = 2, Variable = "x" },
                    new TermStruct { Multiplier = (decimal)3.5, Power = 1,  Variable = "xy" },
                    new TermStruct { Multiplier = 1, Power = 1, Variable = "y" },
                    new TermStruct { Multiplier = -1, Power = 2, Variable = "x" },
                },
                RightPart = new[]
                {
                    new TermStruct { Multiplier = 1, Power = 2, Variable = "y" },
                    new TermStruct { Multiplier = 2, Power = 1 },
                    new TermStruct { Multiplier = -1, Power = 1, Variable ="xy" },
                    new TermStruct { Multiplier = 1, Power = 1, Variable = "y" }
                }
            };

            var result = expression.Normalization();

            Assert.Equal(expected, result);
        }
    }
}