using SimpleCalculator.Helpers;
using SimpleCalculator.Model;
using SimpleCalculator.RPNCalculator;
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
            => String.IsNullOrEmpty(_currentText) ? string.Empty : RPNCounter.CountExpression(RPNConverter.Convert(_currentText)).ToString();

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
    }
}