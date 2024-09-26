using SimpleCalculator.Model.Enums;
using SimpleCalculator.Model.Interfaces;

namespace SimpleCalculator.Model
{
    public class Division : IOperation
    {
        public char Symbol => '/';
        public OperatorPriority Priority => OperatorPriority.MultiplicationDivision;
        public double Operation(double firstNum, double secondNum) => firstNum / secondNum;
    }
}