﻿using SumInterpreter.Term;
using Xunit;

namespace UnitTestProject
{
    public class TermStructTests
    {
        /// <summary>
        /// Проверка, что метод Minus возвращает аналогичную структуру с противоположным знаком.
        /// </summary>
        [Theory]
        [InlineData(1, "x", 1, -1, "x", 1)]
        [InlineData(-2, "xy", 2, 2, "xy", 2)]
        public void Minus(decimal multiplier, string variable, int power,
            decimal expectedMultiplier, string expectedVariable, int expectedPower)
        {
            var term = new TermStruct { Multiplier = multiplier, Power = power, Variable = variable };
            var result = term.Minus();

            Assert.Equal(expectedMultiplier, result.Multiplier);
            Assert.Equal(expectedVariable, result.Variable);
            Assert.Equal(expectedPower, result.Power);
        }

        [Theory]
        [InlineData(1, "x", 1, "+ x")]
        [InlineData(-1, "x", 1, "- x")]
        [InlineData(1, "xy", 2, "+ xy^2")]
        [InlineData(-3, null, 1, "- 3")]
        public void ToStringTest(decimal multiplier, string variable, int power, string expected)
        {
            var term = new TermStruct { Multiplier = multiplier, Power = power, Variable = variable };
            var result = term.ToString();

            Assert.Equal(expected, result);
        }
    }
}