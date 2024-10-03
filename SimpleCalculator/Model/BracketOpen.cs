using SimpleCalculator.Model.Interfaces;

namespace SimpleCalculator.Model
{
    public class BracketOpen : IOperator
    {
        public char Symbol => '(';
        public byte Priority => 0;
    }
}