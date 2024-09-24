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
                OnPropertyChanged(nameof(DeleteSymbolCommand));
                OnPropertyChanged(nameof(DeleteTextCommand));
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
                if (CheckCurrentText.Length <= 0)
                    OnPropertyChanged(nameof(CheckResultText));
            }, (obj) => CheckCurrentText.Length > 0);

        public ICommand DeleteTextCommand
            => new RelayCommand((obj) =>
            {
                CheckCurrentText = string.Empty;
                OnPropertyChanged(nameof(CheckResultText));
            }, (obj) => CheckCurrentText.Length > 0);

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

                        for (; i < inputText.Length && !ExpressionsChecker.IsDelimeter(inputText[i]) && !ExpressionsChecker.IsOperator(inputText[i]); i++)
                            tempNumToPushStack += inputText[i];

                        numbersStack.Push(double.Parse(tempNumToPushStack));
                        i--;
                    }
                    else if (ExpressionsChecker.IsOperator(inputText[i]))
                    {
                        double secondNum = numbersStack.Pop();
                        double firstNum = numbersStack.Pop();
                        expressionResult = OperationTarget.GetOperation(inputText[i]).Operation(firstNum, secondNum);
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