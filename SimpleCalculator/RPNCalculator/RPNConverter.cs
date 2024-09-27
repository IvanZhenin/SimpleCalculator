using SimpleCalculator.Helpers;
using SimpleCalculator.Model;
using System.Text.RegularExpressions;

namespace SimpleCalculator.RPNCalculator
{
    /// <summary>
    /// Конвертация строки математического выражения в образ обратной польской нотации (RPN)
    /// </summary>
    public class RPNConverter
    {
        public static string Convert(string inputText)
        {
            if (!ExpressionChecker.IsCorrectStringExpression(inputText))
                return string.Empty;

            string outputText = string.Empty;
            Stack<char> operationsStack = new Stack<char>();

            for (int i = 0; i < inputText.Length; i++)
            {
                if (ExpressionChecker.IsDelimeter(inputText[i]))
                    continue;

                if (char.IsDigit(inputText[i]) || inputText[i] == '-' && char.IsDigit(inputText[i + 1]) && (i == 0 || inputText[i - 1] == '('))
                {
                    if (inputText[i] == '-')
                    {
                        i++;
                        outputText += "-";
                    }

                    for (; i < inputText.Length && !ExpressionChecker.IsOperator(inputText[i]) && !ExpressionChecker.IsDelimeter(inputText[i]); i++)
                        outputText += inputText[i];

                    outputText += " ";
                    i--;
                    continue;
                }
                
                if (ExpressionChecker.IsOperator(inputText[i]))
                {
                    if (inputText[i] == '(' && inputText[i] != '-')
                        operationsStack.Push(inputText[i]);
                    else if (inputText[i] == ')')
                    {
                        char currentSymbol = operationsStack.Pop();

                        while (currentSymbol != '(')
                        {
                            outputText += currentSymbol.ToString() + " ";
                            currentSymbol = operationsStack.Pop();
                        }
                    }
                    else
                    {
                        while (operationsStack.Count > 0 && OperatorRegistry.GetPriority(inputText[i]) 
                            <= OperatorRegistry.GetPriority(operationsStack.Peek()))
                        {
                            outputText += operationsStack.Pop() + " ";
                        }
                        operationsStack.Push(inputText[i]);
                    }
                }
            }
            while (operationsStack.Count > 0)
            {
                outputText += operationsStack.Pop() + " ";
            }

            return outputText;
        }
    }
}