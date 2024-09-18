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
            => String.IsNullOrEmpty(_currentText) ? string.Empty : Counting(RPNConverter.Convert(_currentText)).ToString();

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
        public static double Counting(string input)
        {
            double result = 0;
            Stack<double> temp = new Stack<double>();
            try
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (Char.IsDigit(input[i]) || (input[i] == '-' && Char.IsDigit(input[i + 1])))
                    {
                        string tempNum = string.Empty;
                        if (input[i] == '-')
                        {
                            i++;
                            tempNum += "-";
                        }
                        while (!ExpressionsChecker.IsDelimeter(input[i]) && !ExpressionsChecker.IsOperator(input[i]))
                        {
                            tempNum += input[i];
                            i++;
                            if (i == input.Length) break;
                        }
                        temp.Push(double.Parse(tempNum));
                        i--;
                    }
                    else if (ExpressionsChecker.IsOperator(input[i]))
                    {
                        double firstNum = temp.Pop();
                        double secondNum = temp.Pop();

                        switch (input[i])
                        {
                            case '-': result = MathFuncs.Subtract(secondNum, firstNum); break;
                            case '+': result = MathFuncs.Addition(secondNum, firstNum); break;
                            case '*': result = MathFuncs.Multiply(secondNum, firstNum); break;
                            case '/': result = MathFuncs.Divide(secondNum, firstNum); break;
                        }
                        temp.Push(result);
                    }
                }

                return temp.Peek();
            }
            catch (Exception)
            {
                return double.NaN;
            }
        }
    }
}