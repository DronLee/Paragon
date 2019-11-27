using System;
using System.Collections.Generic;

namespace SumInterpreter.ReaderWriter
{
    /// <summary>
    /// Считыватель из консоли и писатель в консоль.
    /// </summary>
    public class ConsoleReaderWriter : IReaderWriter
    {
        /// <summary>
        /// Получение входных выражений.
        /// </summary>
        /// <returns>Выражения.</returns>
        public IEnumerable<string> GetInputExpressions()
        {
            while(true)
            {
                Console.WriteLine("Введите выражение: ");
                yield return Console.ReadLine();
            }
        }

        /// <summary>
        /// Записать результат.
        /// </summary>
        /// <param name="resultExpression">Выражение результата для записи.</param>
        public void WriteResult(string resultExpression)
        {
            Console.WriteLine(resultExpression);
        }
    }
}