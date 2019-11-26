namespace SumInterpreter.Term
{
    /// <summary>
    /// Интерфейс интерпретатора слагаемого.
    /// </summary>
    public interface ITermInterpreter
    {
        /// <summary>
        /// Текст регулярного выражения, для определения слагаемого.
        /// </summary>
        string RegexText { get; }

        /// <summary>
        /// Интерпретация текста слагаемого в структуру.
        /// </summary>
        /// <param name="termText">Текст слагаемого.</param>
        /// <returns>Полученная из текста структура.</returns>
        Term Interpret(string termText);
    }
}