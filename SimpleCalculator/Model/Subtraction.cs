using SimpleCalculator.Model.Interfaces;

namespace SimpleCalculator.Model
{
    public class Subtraction : IOperation
    {
        public double Operation(double firstNum, double secondNum) => firstNum - secondNum;
    }
}