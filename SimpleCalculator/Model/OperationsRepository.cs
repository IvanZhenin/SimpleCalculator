using SimpleCalculator.Model.Interfaces;

namespace SimpleCalculator.Model
{
    public static class OperationsRepository
    {
        public static readonly IReadOnlyList<IOperator> OperatorList = new List<IOperator>()
        {
            new BracketOpen(),
            new BracketClose(),
            new Addition(),
            new Subtraction(),
            new Multiplication(),
            new Division(),
        }.AsReadOnly();

        public static readonly IReadOnlyList<IOperation> OperationList = new List<IOperation>()
        {
            new Addition(),
            new Subtraction(),
            new Multiplication(),
            new Division(),
        }.AsReadOnly();
    }
}