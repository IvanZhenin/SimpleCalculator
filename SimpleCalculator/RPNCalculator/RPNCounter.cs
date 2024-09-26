using SimpleCalculator.Helpers;

namespace SimpleCalculator.RPNCalculator
{
    public class RPNCounter
    {
        /// <summary>
        /// Подсчет выражения преобразованной в формат обратной польской нотации строки
        /// </summary>
        public static double CountExpression(string inputText)
        {
            double expressionResult = 0;
            Stack<double> numbersStack = new Stack<double>();
            try
            {
                for (int i = 0; i < inputText.Length; i++)
                {
                    if (Char.IsDigit(inputText[i]) || (inputText[i] == '-' && Char.IsDigit(inputText[i + 1])))
                    {
                        string tempNumToPushStack = string.Empty;
                        if (inputText[i] == '-')
                        {
                            i++;
                            tempNumToPushStack += "-";
                        }

                        for (; i < inputText.Length && !ExpressionChecker.IsDelimeter(inputText[i]) && !ExpressionChecker.IsOperator(inputText[i]); i++)
                            tempNumToPushStack += inputText[i];

                        numbersStack.Push(double.Parse(tempNumToPushStack));
                        i--;
                    }
                    else if (ExpressionChecker.IsOperator(inputText[i]))
                    {
                        double secondNum = numbersStack.Pop();
                        double firstNum = numbersStack.Pop();
                        expressionResult = OperatorRegistry.GetOperation(inputText[i]).Operation(firstNum, secondNum);
                        numbersStack.Push(expressionResult);
                    }
                }

                return numbersStack.Peek();
            }
            catch (Exception)
            {
                return double.NaN;
            }
        }
    }
}
