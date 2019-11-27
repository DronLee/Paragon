using System.Collections.Generic;

namespace SumInterpreter.ReaderWriter
{
    /// <summary>
    /// Интерфейс считывателя входных данных.
    /// </summary>
    public interface IInputReader
    {
        /// <summary>
        /// Получение входных выражений.
        /// </summary>
        /// <returns>Выражения.</returns>
        IEnumerable<string> GetInputExpressions();
    }
}