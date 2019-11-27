using Autofac;
using SumInterpreter.ReaderWriter;
using SumInterpreter.Term;
using System;

namespace SumInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            var isConsoleMode = args.Length == 0;

            var container = GetAutofacContainer(isConsoleMode);

            var interpreter = container.Resolve<IExpressionInterpreter>();

            if (isConsoleMode)
            {
                var readerWriter = container.Resolve<IReaderWriter>();
                Process(readerWriter, interpreter);
            }
            else
            {
                var filePathProvider = container.Resolve<IFilePathProvider>();
                foreach (var inputFile in args)
                {
                    filePathProvider.FilePath = inputFile;
                    try
                    {
                        using (var readerWriter = container.Resolve<IFileReaderWriter>())
                        {
                            Console.WriteLine("Обработка файла: " + inputFile);
                            Process(readerWriter, interpreter);
                        }
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        Console.WriteLine("Не найден указанный файл: " + inputFile);
                    }
                }
                Console.WriteLine("Нормализация выражений из файлов завершена.");
                Console.ReadKey();
            }   
        }

        private static void Process(IReaderWriter readerWriter, IExpressionInterpreter interpreter)
        {
            foreach (var inputExpression in readerWriter.GetInputExpressions())
                try
                {
                    readerWriter.WriteResult(interpreter.Interpret(inputExpression).Normalization());
                }
                catch(IncorrectExpressionException exc)
                {
                    Console.WriteLine(exc.Message);
                }
                catch(Exception exc)
                {
                    Console.WriteLine("Непредвиденное исключение: " + exc.Message);
                }
        }

        private static IContainer GetAutofacContainer(bool IsConsoleMode)
        {
            var containerBuilder = new ContainerBuilder();

            if (IsConsoleMode)
                containerBuilder.RegisterType<ConsoleReaderWriter>().As<IReaderWriter>().SingleInstance();
            else
            {
                containerBuilder.RegisterType<FilePathProvider>().As<IFilePathProvider>().SingleInstance();
                containerBuilder.RegisterType<FileReaderWriter>().As<IFileReaderWriter>();
            }

            containerBuilder.RegisterType<TermInterpreter>().As<ITermInterpreter>().SingleInstance();
            containerBuilder.RegisterType<SumExpressionInterpreter>().As<IExpressionInterpreter>().SingleInstance();

            return containerBuilder.Build();
        }
    }
}