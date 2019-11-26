namespace SumInterpreter.Term
{
    /// <summary>
    /// Структура слагаемого.
    /// </summary>
    public struct TermStruct
    {
        /// <summary>
        /// Множитель.
        /// </summary>
        public decimal Multiplier;

        /// <summary>
        /// Переменная или переменные.
        /// </summary>
        public string Variable;

        /// <summary>
        /// Степень.
        /// </summary>
        public int Power;

        /// <summary>
        /// Возвращает слагаемое с противоположным знаком.
        /// </summary>
        /// <returns>Слагаемое с противоположным знаком.</returns>
        public TermStruct Minus()
        {
            return new TermStruct { Multiplier = -Multiplier, Power = Power, Variable = Variable };
        }
    }
}