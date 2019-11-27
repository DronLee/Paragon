using System.Collections.Generic;
using System.IO;

namespace SumInterpreter.ReaderWriter
{
    /// <summary>
    /// Cчитыватель из файла и писатель в файл.
    /// </summary>
    public class FileReaderWriter : IFileReaderWriter
    {
        private const string resultFileExtension = ".out";

        /// <summary>
        /// Путь к файлу, из которого берутся строки для обработки.
        /// </summary>
        private readonly string _inputFile;

        /// <summary>
        /// Файловый поток записи результата.
        /// </summary>
        private readonly StreamWriter _resultFileStream;

        public FileReaderWriter(IFilePathProvider filePathProvider)
        {
            _inputFile = filePathProvider.FilePath;
            _resultFileStream = File.AppendText(
                Path.Combine(Path.GetDirectoryName(_inputFile), Path.GetFileNameWithoutExtension(_inputFile)) + resultFileExtension);
        }

        public void Dispose()
        {
            _resultFileStream.Dispose();
        }

        /// <summary>
        /// Получение входных выражений.
        /// </summary>
        /// <returns>Выражения.</returns>
        public IEnumerable<string> GetInputExpressions()
        {
            using(var streamReader = File.OpenText(_inputFile))
            {
                var line = streamReader.ReadLine();
                while(line!=null)
                {
                    var returnLine = line;
                    line = streamReader.ReadLine();
                    yield return returnLine;
                }
            }
        }

        /// <summary>
        /// Записать результат.
        /// </summary>
        /// <param name="resultExpression">Выражение результата для записи.</param>
        public void WriteResult(string resultExpression)
        {
            _resultFileStream.WriteLine(resultExpression);
        }
    }
}