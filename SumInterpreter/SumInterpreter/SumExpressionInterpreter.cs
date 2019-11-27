using SumInterpreter.Term;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SumInterpreter
{
    /// <summary>
    /// Интерпретатор выражения сумм.
    /// </summary>
    public class SumExpressionInterpreter : IExpressionInterpreter
    {
        private const char _partSeparator = '=';
        private const string _space = " ";

        private readonly ITermInterpreter _termInterpreter;
        private readonly Regex _termsRegex; 

        public SumExpressionInterpreter(ITermInterpreter termInterpreter)
        {
            _termInterpreter = termInterpreter;
            _termsRegex = new Regex(@"(?<minus>\-[^\+\-]+)|(?<plus>[^\+\-]+)", RegexOptions.Compiled);
        }

        /// <summary>
        /// Интерпретация строки в модель выражения.
        /// </summary>
        /// <param name="expressionText">Строка выражения.</param>
        /// <returns>Полученная модель выражения.</returns>
        public IExpression Interpret(string expressionText)
        {
            string[] parts = expressionText.Replace(_space, string.Empty).Split(_partSeparator);
            if (parts.Length != 2)
                throw new IncorrectExpressionException("В выражении должно быть две части (слева от равно и справа от равно).");

            var errors = new List<string>();

            var leftTerms = GetTerms(parts[0], "слева", errors);
            var rightTerms = GetTerms(parts[1], "справа", errors);

            if (errors.Count > 0)
                throw new IncorrectExpressionException(string.Join("\n", errors));

            return new Expression { LeftPart = leftTerms, RightPart = rightTerms };
        }

        private TermStruct[] GetTerms(string expressionPart, string sideName, List<string> errors)
        {
            var result = new List<TermStruct>();
            if (expressionPart == string.Empty)
                errors.Add($"Отсутствуют слагаемые {sideName}.");
            else
            {
                var termMatches = _termsRegex.Matches(expressionPart);
                for (int i = 0; i < termMatches.Count; i++)
                    try
                    {
                        result.Add(_termInterpreter.Interpret(termMatches[i].Value));
                    }
                    catch (IncorrectTermException)
                    {
                        errors.Add($"Слагаемое номер {i + 1} \"{termMatches[i].Value}\" {sideName} имеет некорректный вид.");
                    }
            }
            return result.ToArray();
        }
    }
}