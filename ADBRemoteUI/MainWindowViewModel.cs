using System;
using System.ComponentModel;
using System.Windows.Input;
using ADB_Lib;

namespace ADBRemoteUI {
    class MainWindowViewModel : INotifyPropertyChanged {
        public MainWindowViewModel() {
            IsConnected = false;
            ConnectCommand = new DelegateCommand((o) =>
            {
                Properties.Settings.Default.IpAddress = IpAddress;
                Properties.Settings.Default.Save();
                ADBCommand.ConnectServer(IpAddress);  IsConnected = true;
            });
            DisconnectCommand = new DelegateCommand((o) => { if (IsConnected == true) ADBCommand.DisconnectServer(); IsConnected = false; });
            HomeCommand = new DelegateCommand((o) => { if (IsConnected == true) ADBCommand.ADBActionKey(ConsoleKey.Escape);  }, (o) => true);
            SelectCommand = new DelegateCommand((o) => { if (IsConnected == true) ADBCommand.ADBActionKey(ConsoleKey.Enter); }, (o) => true);
            UpCommand = new DelegateCommand((o) => { if (IsConnected == true) ADBCommand.ADBActionKey(ConsoleKey.UpArrow);  }, (o) => true);
            DownCommand = new DelegateCommand((o) => { if (IsConnected == true) ADBCommand.ADBActionKey(ConsoleKey.DownArrow);  }, (o) => true);
            LeftCommand = new DelegateCommand((o) => { if (IsConnected == true) ADBCommand.ADBActionKey(ConsoleKey.LeftArrow); }, (o) => true);
            RightCommand = new DelegateCommand((o) => { if (IsConnected == true) ADBCommand.ADBActionKey(ConsoleKey.RightArrow);  }, (o) => true);
            BackCommand = new DelegateCommand((o) => { if (IsConnected == true) ADBCommand.ADBActionKey(ConsoleKey.Backspace); }, (o) => true);
            MenuCommand = new DelegateCommand((o) => { if (IsConnected == true) ADBCommand.ADBActionKey(ConsoleKey.Tab); }, (o) => true);
            RewindCommand = new DelegateCommand((o) => { if (IsConnected == true) ADBCommand.ADBActionKey(ConsoleKey.MediaPrevious); }, (o) => true);
            FastForwardCommand = new DelegateCommand((o) => { if (IsConnected == true) ADBCommand.ADBActionKey(ConsoleKey.MediaNext); }, (o) => true);
            PlayPauseCommand = new DelegateCommand((o) => { if (IsConnected == true) ADBCommand.ADBActionKey(ConsoleKey.MediaPlay); }, (o) => true);
        }

        private string _ipAddress = Properties.Settings.Default.IpAddress;
        public string IpAddress {
            get {
                return _ipAddress;
            }
            set {
                _ipAddress = value;
                OnPropertyChanged("IpAddress");
            }
        }

        private bool? _isConnected = false;
        public bool? IsConnected {
            get { return _isConnected; }
            set {
                _isConnected = value;
                OnPropertyChanged("IsConnected");
            }
        }

        
        public ICommand ConnectCommand { get; set; }
        public ICommand DisconnectCommand { get; set; }
        public ICommand UpCommand { get; set; }
        public ICommand DownCommand { get; set; }
        public ICommand LeftCommand { get; set; }
        public ICommand RightCommand { get; set; }
        public ICommand HomeCommand { get; set; }
        public ICommand SelectCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand MenuCommand { get; set; }
        public ICommand RewindCommand { get; set; }
        public ICommand FastForwardCommand { get; set; }
        public ICommand PlayPauseCommand { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }        
        }
    }
}
