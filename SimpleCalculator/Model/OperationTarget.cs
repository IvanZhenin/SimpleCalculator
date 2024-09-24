using SimpleCalculator.Model.Interfaces;

namespace SimpleCalculator.Model
{
    public static class OperationTarget
    {
        public static IOperation GetOperation(char symbol)
        {
            return symbol switch
            {
                '+' => new Addition(),
                '-' => new Subtraction(),
                '*' => new Multiplication(),
                '/' => new Division(),
                _ => throw new ArgumentException("Некорректный тип операции")
            };
        }
    }
}