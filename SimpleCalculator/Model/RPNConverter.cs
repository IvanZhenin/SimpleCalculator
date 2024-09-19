using SimpleCalculator.Helpers;

namespace SimpleCalculator.Model
{
    /// <summary>
    /// Конвертация строки математического выражения в образ обратной польской нотации (RPN)
    /// </summary>
    public class RPNConverter
    {
        public static string Convert(string inputText)
        {
            string outputText = string.Empty;
            Stack<char> operationsStack = new Stack<char>();

            for (int i = 0; i < inputText.Length; i++)
            {
                if (ExpressionsChecker.IsDelimeter(inputText[i]))
                    continue;

                if (Char.IsDigit(inputText[i]) || (inputText[i] == '-' && Char.IsDigit(inputText[i + 1]) && (i == 0 || inputText[i - 1] == '(')))
                {
                    if (inputText[i] == '-') 
                    {
                        i++;
                        outputText += "-";
                    }

                    for (; i < inputText.Length && !ExpressionsChecker.IsOperator(inputText[i]) && !ExpressionsChecker.IsDelimeter(inputText[i]); i++) 
                        outputText += inputText[i];
                    
                    outputText += " ";
                    i--;
                    continue;
                }

                if (ExpressionsChecker.IsOperator(inputText[i]))
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
                        while (operationsStack.Count > 0 && ExpressionsChecker.GetPriority(inputText[i]) <= ExpressionsChecker.GetPriority(operationsStack.Peek()))
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