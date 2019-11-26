using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using SumInterpreter.Term;

namespace SumInterpreter
{
    public struct Expression : IExpression
    {
        #region Константы, используемые при формировании строки выражения.
        private const string _plusSeparator = " + ";
        private const string _minusSeparator = " - ";
        private const string _minus = "-";
        private const string _powerPrefix = "^";
        private const string _normalizedRightPart = " = 0";
        private const string _decimalSeparator = ".";
        #endregion

        public TermStruct[] LeftPart { get; set; }

        public TermStruct[] RightPart { get; set; }

        public string Normalization()
        {
            var result = new StringBuilder();
            var normalizedTerms = GetNormalizedTerms();
            for (int i = 0; i < normalizedTerms.Length; i++)
            {
                var term = normalizedTerms[i];

                if (i == 0)
                {
                    if (term.Multiplier < 0)
                        result.Append(_minus);
                }
                else // Если не первый элемент, добавим разделитель.
                    result.Append(term.Multiplier < 0 ? _minusSeparator : _plusSeparator);

                var absMultiplier = Math.Abs(term.Multiplier);
                if (absMultiplier != 1)
                    result.Append(absMultiplier.ToString().Replace(
                        CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, _decimalSeparator));

                result.Append(term.Variable);

                if (term.Power != 1)
                    result.Append(_powerPrefix).Append(term.Power);
            }
            result.Append(_normalizedRightPart);
            return result.ToString();
        }

        /// <summary>
        /// Получение массива нормализованных слагаемых.
        /// </summary>
        /// <returns>Массив нормализованных слагаемых.</returns>
        private TermStruct[] GetNormalizedTerms()
        {
            // Это будет общий набор слагаемых.
            var terms = LeftPart.ToList();

            // Слагаемые с правой стороны должны перенестись влево с противоположным знаком.
            terms.AddRange(RightPart.Select(t => t.Minus()));

            var resultTerms = new List<TermStruct>();

            // Группируем по переменным и степени,
            // так как слагаемые с этими одинаковыми составляющими мы можем сложить.
            foreach (var termGroup in terms.GroupBy(t => (t.Variable, t.Power)).ToArray())
            {
                var multiplier = termGroup.Sum(t => t.Multiplier);
                if (multiplier != 0)
                    resultTerms.Add(new TermStruct
                    {
                        Multiplier = multiplier,
                        Power = termGroup.Key.Power,
                        Variable = termGroup.Key.Variable
                    });

                foreach (var removingTerm in termGroup)
                    terms.Remove(removingTerm);
            }

            resultTerms.AddRange(terms);
            return resultTerms.OrderBy(t => (0 - t.Power, t.Variable == null ? int.MaxValue : 0 - t.Variable.Length, t.Variable)).ToArray();
        }
    }
}