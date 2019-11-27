using System;

namespace SumInterpreter.ReaderWriter
{
    /// <summary>
    /// Интерфейс для считывателя из файла и писателя в файл.
    /// </summary>
    interface IFileReaderWriter : IReaderWriter, IDisposable { }
}