namespace SumInterpreter.ReaderWriter
{
    /// <summary>
    /// Интерфейс провайдера путей файлов.
    /// </summary>
    public interface IFilePathProvider
    {
        /// <summary>
        /// Путь к файлу.
        /// </summary>
        string FilePath { get; set; }
    }
}