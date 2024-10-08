﻿using SimpleCalculator.Model;

namespace SimpleCalculator.Helpers
{
    public static class ExpressionChecker
    {
        public static bool IsOperator(char symbol)
        {
            return OperationsRepository.OperatorList.Any(p => p.Symbol.Equals(symbol));
        }

        public static bool IsOperation(char symbol)
        {
            return OperationsRepository.OperationList.Any(p => p.Symbol.Equals(symbol));
        }

        public static bool IsDelimeter(char symbol)
        {
            return symbol == ' ';
        }

        public static bool IsCorrectStringExpression(string text)
        {
            if (IsInvalidText(text))
                return false;
            if (!IsBalancedOperations(text))
                return false;
            if (!IsBalancedBrackets(text))
                return false;
            if (!IsBalancedCommas(text))
                return false;

            return true;
        }

        public static bool IsInvalidText(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (!IsOperator(text[i]) && !char.IsDigit(text[i]) && !IsDelimeter(text[i]) && text[i] != ',')
                    return true;
            }

            return false;
        }

        public static bool IsBalancedOperations(string text)
        {
            int operationsCount = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (IsOperation(text[i]))
                {
                    if (text[i] == '-' && (i == 0 || text[i - 1] == '('))
                        continue;
                    operationsCount++;
                }
                else if (Char.IsDigit(text[i]))
                {
                    operationsCount--;
                    for (; i < text.Length && !IsDelimeter(text[i]) && !IsOperation(text[i]);)
                        i++;
                    i--;
                }
            }

            return operationsCount == -1;
        }

        public static bool IsBalancedBrackets(string text)
        {
            int openBrackets = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '(')
                    openBrackets++;
                else if (text[i] == ')')
                    openBrackets--;
            }

            return openBrackets == 0;
        }

        public static bool IsBalancedCommas(string text)
        {
            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] == ',' && text[i + 1] == ',')
                    return false;
            }

            return true;
        }
    }
}