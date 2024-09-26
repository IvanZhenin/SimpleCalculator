using SimpleCalculator.Model.Enums;
using SimpleCalculator.Model.Interfaces;

namespace SimpleCalculator.Model
{
    public class BracketOpen : IOperator
    {
        public char Symbol => '(';
        public byte Priority => (byte)OperatorPriority.BracketOpen;
    }
}