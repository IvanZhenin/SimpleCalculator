using SimpleCalculator.Helpers;
using SimpleCalculator.Model;
using System.ComponentModel;
using System.Windows.Input;


namespace SimpleCalculator.ViewModel
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}