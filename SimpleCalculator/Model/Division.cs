using SimpleCalculator.Model.Interfaces;

namespace SimpleCalculator.Model
{
    public class Division : IOperation
    {
        public double Operation(double firstNum, double secondNum) => firstNum / secondNum;
    }
}