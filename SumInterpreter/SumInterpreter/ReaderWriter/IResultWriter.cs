namespace SumInterpreter.ReaderWriter
{
    /// <summary>
    /// Интерфейс писателя результата.
    /// </summary>
    public interface IResultWriter
    {
        /// <summary>
        /// Записать результат.
        /// </summary>
        /// <param name="resultExpression">Выражение результата для записи.</param>
        void WriteResult(string resultExpression);
    }
}