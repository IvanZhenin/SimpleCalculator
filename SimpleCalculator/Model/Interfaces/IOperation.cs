namespace SimpleCalculator.Model.Interfaces
{
    public interface IOperation : IOperator
    {
        public double Operation(double firstNum, double secondNum);
    }
}