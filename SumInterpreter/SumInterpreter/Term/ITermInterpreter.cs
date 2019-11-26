namespace SumInterpreter.Term
{
    /// <summary>
    /// Интерфейс интерпретатора слагаемого.
    /// </summary>
    public interface ITermInterpreter
    {
        /// <summary>
        /// Интерпретация текста слагаемого в структуру.
        /// </summary>
        /// <param name="termText">Текст слагаемого.</param>
        /// <returns>Полученная из текста структура.</returns>
        TermStruct Interpret(string termText);
    }
}