namespace SumInterpreter.ReaderWriter
{
    /// <summary>
    /// Провайдер путей файлов.
    /// </summary>
    public class FilePathProvider : IFilePathProvider
    {
        /// <summary>
        /// Путь к файлу.
        /// </summary>
        public string FilePath { get; set; }
    }
}