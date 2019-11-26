namespace SumInterpreter
{
    /// <summary>
    /// Интерфейс интерпретатора выражения.
    /// </summary>
    interface IExpressionInterpreter
    {
        /// <summary>
        /// Интерпретация строки в модель выражения.
        /// </summary>
        /// <param name="expressionText">Строка выражения.</param>
        /// <returns>Полученная модель выражения.</returns>
        IExpression Interpret(string expressionText);
    }
}