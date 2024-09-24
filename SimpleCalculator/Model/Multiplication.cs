using SimpleCalculator.Model.Interfaces;

namespace SimpleCalculator.Model
{
    public class Multiplication : IOperation
    {
        public double Operation(double firstNum, double secondNum) => firstNum * secondNum;
    }
}