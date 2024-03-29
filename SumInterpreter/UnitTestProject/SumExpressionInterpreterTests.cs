﻿using SumInterpreter;
using SumInterpreter.Term;
using Xunit;

namespace UnitTestProject
{
    public class SumExpressionInterpreterTests
    {
        /// <summary>
        /// Проверка интерпретации корректной строки выражения.
        /// </summary>
        /// <param name="expressionText">Текст выражения.</param>
        /// <param name="leftTermCount">Ожидаемое количетво слагаемых слева.</param>
        /// <param name="rightTermCount">Ожидаемое количетво слагаемых справа.</param>
        [Theory]
        [InlineData("1=1 ", 1, 1)]
        [InlineData("x +1= 0", 2, 1)]
        [InlineData(" x+ y+z = 12 ", 3, 1)]
        [InlineData("  1 = 12+x +  y", 1, 3)]
        [InlineData("b - c = a-b", 2, 2)]
        public void Interpret(string expressionText, byte leftTermCount, byte rightTermCount)
        {
            var sumExpressionInterpreter = new SumExpressionInterpreter(new TestTermInterpreter());
            var result = sumExpressionInterpreter.Interpret(expressionText);

            Assert.Equal(leftTermCount, result.LeftPart.Length);
            Assert.Equal(rightTermCount, result.RightPart.Length);
        }

        /// <summary>
        /// Проверка, что при попытке интерпретации некорректной строки выражения, будет выдано соответствующее исключение.
        /// </summary>
        /// <param name="expressionText">Текст выражения.</param>
        [Theory]
        [InlineData("1")]
        [InlineData("x +1")]
        [InlineData("x+y")]
        [InlineData(" = ")]
        [InlineData(" = 1")]
        [InlineData("3=")]
        public void Interpret_IncorrectExpression(string expressionText)
        {
            var sumExpressionInterpreter = new SumExpressionInterpreter(new TestTermInterpreter());

            Assert.Throws<IncorrectExpressionException>(() => sumExpressionInterpreter.Interpret(expressionText));
        }

        private class TestTermInterpreter : ITermInterpreter
        {
            public TermStruct Interpret(string termText)
            {
                return new TermStruct();
            }
        }
    }
}