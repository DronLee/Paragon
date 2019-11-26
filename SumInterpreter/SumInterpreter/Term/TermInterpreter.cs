using System.Globalization;
using System.Text.RegularExpressions;

namespace SumInterpreter.Term
{
    /// <summary>
    /// Интерпретатор слагаемого.
    /// </summary>
    public class TermInterpreter : ITermInterpreter
    {
        private const string decimalSeparator = ".";

        private readonly Regex _regex;

        public TermInterpreter()
        {
            RegexText = $@"^(?<multiplier>\d+(\{decimalSeparator}\d+)?)?((?<variable>[a-z]+)(\^(?<power>\d+))?)?$";
            _regex = new Regex(RegexText, RegexOptions.Compiled);
        }

        /// <summary>
        /// Текст регулярного выражения, для определения слагаемого.
        /// </summary>
        public string RegexText { get; }

        /// <summary>
        /// Интерпретация текста слагаемого в структуру.
        /// </summary>
        /// <param name="termText">Текст слагаемого.</param>
        /// <returns>Полученная из текста структура.</returns>
        public TermStruct Interpret(string termText)
        {
            var match = _regex.Match(termText);
            if (!match.Success)
                throw new IncorrectTermException();

            var multiplierGroup = match.Groups["multiplier"];
            var variableGroup = match.Groups["variable"];
            var powerGroup = match.Groups["power"];

            return new TermStruct
            {
                Multiplier = multiplierGroup.Success ? decimal.Parse(
                    multiplierGroup.Value.Replace(decimalSeparator, CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)) : 1,
                Variable = variableGroup.Success ? variableGroup.Value : null,
                Power = powerGroup.Success ? int.Parse(powerGroup.Value) : 1
            };
        }
    }
}