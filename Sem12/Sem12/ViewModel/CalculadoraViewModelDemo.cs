using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Windows.Input;
using Xamarin.Forms;

namespace Sem12.ViewModel
{
    public class CalculadoraViewModelDemo : INotifyPropertyChanged
    {
        private string result;
        public CalculadoraViewModelDemo()
        {
            CalculateCommand = new Command<string>(Calculate);
            ClearCommand = new Command(Clear);
            result = string.Empty;

        }
        public string Result
        {
            get { return result; }
            set
            {
                if (result != value)
                {
                    result = value;
                    OnPropertyChanged(nameof(Result));
                }
            }
        }

        public ICommand CalculateCommand { get; }
        public ICommand ClearCommand { get; }

        private void Calculate(string parameter)
        {
            if (parameter == "=")
            {
                Result = new DataTable().Compute(Result, null).ToString();
            }
            else
            {
                Result += parameter;
            }
        }

        private void Clear()
        {
            Result = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}