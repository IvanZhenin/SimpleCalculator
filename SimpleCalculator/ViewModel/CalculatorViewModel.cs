using SimpleCalculator.Helpers;
using SimpleCalculator.Model;
using System.ComponentModel;
using System.Windows.Input;

namespace SimpleCalculator.ViewModel
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private string _currentText = string.Empty;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string CheckCurrentText
        {
            get => _currentText;
            set
            {
                _currentText = value;
                OnPropertyChanged(nameof(CheckCurrentText));
            }
        }

        public string CheckResultText
            => String.IsNullOrEmpty(_currentText) ? string.Empty : CountingExpression(RPNConverter.Convert(_currentText)).ToString();

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand AddSymbolCommand =>
            new RelayCommand((symbol) =>
            {
                if (symbol is string s)
                    CheckCurrentText += s;
            });

        public ICommand CountExpressionCommand =>
            new RelayCommand((obj) =>
            {
                OnPropertyChanged(nameof(CheckResultText));
            });

        public ICommand DeleteSymbolCommand =>
            new RelayCommand((obj) =>
            {
                if (!string.IsNullOrEmpty(CheckCurrentText))
                    CheckCurrentText = CheckCurrentText[..^1];
            });

        public ICommand DeleteTextCommand
            => new RelayCommand((obj) =>
            {
                CheckCurrentText = string.Empty;
                OnPropertyChanged(nameof(CheckResultText));
            });

        /// <summary>
        /// Подсчет выражения преобразованной в формат обратной польской нотации строки
        /// </summary>
        public static double CountingExpression(string inputText)
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
                        while (!ExpressionsChecker.IsDelimeter(inputText[i]) && !ExpressionsChecker.IsOperator(inputText[i]))
                        {
                            tempNumToPushStack += inputText[i];
                            i++;
                            if (i == inputText.Length) break;
                        }
                        numbersStack.Push(double.Parse(tempNumToPushStack));
                        i--;
                    }
                    else if (ExpressionsChecker.IsOperator(inputText[i]))
                    {
                        double firstNum = numbersStack.Pop();
                        double secondNum = numbersStack.Pop();

                        switch (inputText[i])
                        {
                            case '-': expressionResult = MathFuncs.Subtract(secondNum, firstNum); break;
                            case '+': expressionResult = MathFuncs.Addition(secondNum, firstNum); break;
                            case '*': expressionResult = MathFuncs.Multiply(secondNum, firstNum); break;
                            case '/': expressionResult = MathFuncs.Divide(secondNum, firstNum); break;
                        }
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