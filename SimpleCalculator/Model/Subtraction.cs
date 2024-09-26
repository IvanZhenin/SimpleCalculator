using SimpleCalculator.Model.Enums;
using SimpleCalculator.Model.Interfaces;

namespace SimpleCalculator.Model
{
    public class Subtraction : IOperation
    {
        public char Symbol => '-';
        public OperatorPriority Priority => OperatorPriority.AdditionSubtraction;
        public double Operation(double firstNum, double secondNum) => firstNum - secondNum;
    }
}