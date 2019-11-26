using SumInterpreter;
using SumInterpreter.Term;
using Xunit;

namespace UnitTestProject
{
    public class ExpressionTests
    {
        /// <summary>
        /// Проверка норрмализации выражения.
        /// </summary>
        [Fact]
        public void Normalization()
        {
            // Составляем выражение: x^2 + 3.5xy + y = y^2 - xy + y
            var expression = new Expression
            {
                LeftPart = new[]
                {
                    new TermStruct { Multiplier = 1, Power = 2, Variable = "x"  },
                    new TermStruct{  Multiplier = (decimal)3.5, Power = 1,  Variable = "xy" },
                    new TermStruct{ Multiplier = 1, Power = 1, Variable = "y" }
                },
                RightPart = new[]
                {
                    new TermStruct { Multiplier = 1, Power = 2, Variable = "y" },
                    new TermStruct{ Multiplier = -1, Power = 1, Variable ="xy" },
                    new TermStruct{ Multiplier = 1, Power = 1, Variable = "y" }
                }
            };

            var result = expression.Normalization();

            Assert.Equal("x^2 - y^2 + 4.5xy = 0", result);
        }
    }
}