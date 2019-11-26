using System;

namespace SumInterpreter
{
    /// <summary>
    /// Интерпретатор выражения сумм.
    /// </summary>
    public class SumExpressionInterpreter : IExpressionInterpreter
    {
        /// <summary>
        /// Интерпретация строки в модель выражения.
        /// </summary>
        /// <param name="expressionText">Строка выражения.</param>
        /// <returns>Полученная модель выражения.</returns>
        public IExpression Interpret(string expressionText)
        {
            throw new NotImplementedException();
        }
    }
}