namespace SimpleCalculator.Helpers
{
    public class ExpressionsChecker
    {
        public static byte GetPriority(char symbol)
        {
            switch (symbol)
            {
                case '(': return 0;
                case ')': return 1;
                case '-':
                case '+': return 2;
                case '*':
                case '/': return 3;
                default: return 4;
            }
        }

        public static bool IsOperator(char symbol)
        {
            if ("+-*/()".Contains(symbol))
                return true;
            return false;
        }

        public static bool IsDelimeter(char symbol)
        {
            if (" ".Contains(symbol))
                return true;
            return false;
        }
    }
}