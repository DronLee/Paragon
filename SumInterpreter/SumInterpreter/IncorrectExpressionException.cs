using System;

namespace SumInterpreter
{
    /// <summary>
    /// Исключение, возникающее при попытке интерпретировать некорректую строку выражения.
    /// </summary>
    public class IncorrectExpressionException : Exception
    {
        public IncorrectExpressionException(string message) : base(message) { }
    }
}