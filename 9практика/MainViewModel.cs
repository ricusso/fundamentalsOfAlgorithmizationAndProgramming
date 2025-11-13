using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace WpfApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _userInput;
        private string _statusMessage = "Готов к работе";

        public string UserInput
        {
            get { return _userInput; }
            set
            {
                _userInput = value;
                OnPropertyChanged(nameof(UserInput));
                UpdateStatus();
            }
        }

        public string StatusMessage
        {
            get { return _statusMessage; }
            set
            {
                _statusMessage = value;
                OnPropertyChanged(nameof(StatusMessage));
            }
        }

        public ObservableCollection<string> Items { get; set; }
        public ICommand AddCommand { get; set; }

        public MainViewModel()
        {
            Items = new ObservableCollection<string>
            {
                "Пример элемента 1",
                "Пример элемента 2",
                "Пример элемента 3"
            };
            AddCommand = new RelayCommand(AddItem, CanAddItem);
        }

        private void AddItem(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(UserInput))
            {
                Items.Add(UserInput);
                StatusMessage = $"Добавлен элемент: {UserInput}";
                UserInput = string.Empty;
            }
        }

        private bool CanAddItem(object parameter)
        {
            return !string.IsNullOrWhiteSpace(UserInput);
        }

        private void UpdateStatus()
        {
            if (string.IsNullOrWhiteSpace(UserInput))
            {
                StatusMessage = "Введите текст для добавления";
            }
            else
            {
                StatusMessage = $"Текст для добавления: '{UserInput}'";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}