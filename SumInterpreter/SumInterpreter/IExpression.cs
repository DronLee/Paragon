﻿using SumInterpreter.Term;

namespace SumInterpreter
{
    /// <summary>
    /// Интерфейс выражения.
    /// </summary>
    public interface IExpression
    {
        /// <summary>
        /// Левая часть выражения (да знака равно).
        /// </summary>
        TermStruct[] LeftPart { get; }

        /// <summary>
        /// Правая часть выражения (после знака равно).
        /// </summary>
        TermStruct[] RightPart { get; }

        /// <summary>
        /// Нормализация выражения и получение результата в виде строки. 
        /// </summary>
        /// <returns>Текст нормализованного выражения.</returns>
        string Normalization();
    }
}