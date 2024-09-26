using SimpleCalculator.Model;

namespace SimpleCalculator.Helpers
{
    public static class ExpressionChecker
    {
        public static bool IsOperator(char symbol)
        {
            return OperationsRepository.OperatorList.Any(p => p.Symbol.Equals(symbol));
        }

        public static bool IsDelimeter(char symbol)
        {
            return symbol == ' ';
        }

        public static bool IsInvalidSymbol(char symbol)
        {
            return !IsOperator(symbol) && !char.IsDigit(symbol) && !IsDelimeter(symbol);
        }
    }
}