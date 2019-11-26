using System;

namespace SumInterpreter
{
    /// <summary>
    /// Интерпретатор слагаемого.
    /// </summary>
    public class TermInterpreter : ITermInterpreter
    {
        /// <summary>
        /// Текст регулярного выражения, для определения слагаемого.
        /// </summary>
        public string RegexText => throw new NotImplementedException();

        /// <summary>
        /// Интерпретация текста слагаемого в структуру.
        /// </summary>
        /// <param name="termText">Текст слагаемого.</param>
        /// <returns>Полученная из текста структура.</returns>
        public Term Interpret(string termText)
        {
            throw new NotImplementedException();
        }
    }
}