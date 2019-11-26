namespace SumInterpreter
{
    /// <summary>
    /// Структура слагаемого.
    /// </summary>
    public struct Term
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
    }
}