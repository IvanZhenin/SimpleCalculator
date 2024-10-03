namespace SimpleCalculator.Model.Interfaces
{
    public interface IOperator
    {
        public char Symbol { get; }
        public byte Priority { get; }
    }
}