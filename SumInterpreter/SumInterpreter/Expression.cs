using System;
using SumInterpreter.Term;

namespace SumInterpreter
{
    public struct Expression : IExpression
    {
        public TermStruct[] LeftPart { get; set; }

        public TermStruct[] RightPart { get; set; }

        public string Normalization()
        {
            throw new NotImplementedException();
        }
    }
}