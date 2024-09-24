using SimpleCalculator.Model.Interfaces;

namespace SimpleCalculator.Model
{
    public class Addition : IOperation
    {
        public double Operation(double firstNum, double secondNum) => firstNum + secondNum;
    }
}
