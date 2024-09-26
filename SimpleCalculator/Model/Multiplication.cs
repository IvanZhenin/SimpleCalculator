using SimpleCalculator.Model.Enums;
using SimpleCalculator.Model.Interfaces;

namespace SimpleCalculator.Model
{
    public class Multiplication : IOperation
    {
        public char Symbol => '*';
        public byte Priority => (byte)OperatorPriority.MultiplicationDivision;
        public double Operation(double firstNum, double secondNum) => firstNum * secondNum;
    }
}