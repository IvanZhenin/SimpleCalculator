using SimpleCalculator.Model.Enums;

namespace SimpleCalculator.Model.Interfaces
{
    public interface IOperator
    {
        public char Symbol { get; }
        public OperatorPriority Priority { get; }
    }
}