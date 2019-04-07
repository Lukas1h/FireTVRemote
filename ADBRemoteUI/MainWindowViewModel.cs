using System;
using System.ComponentModel;
using System.Windows.Input;
using ADB_Lib;

namespace ADBRemoteUI {
    class MainWindowViewModel : INotifyPropertyChanged {
        public MainWindowViewModel() {
            IsConnected = false;
            ConnectCommand = new DelegateCommand((o) => { ADBCommand.ConnectServer(IpAddress);  IsConnected = true; });
            DisconnectCommand = new DelegateCommand((o) => { if (IsConnected == true) ADBCommand.DisconnectServer(); IsConnected = false; });
            HomeCommand = new DelegateCommand((o) => { if (IsConnected == true) ADBCommand.ADBActionKey(ConsoleKey.Escape);  }, (o) => { return true; });
            SelectCommand = new DelegateCommand((o) => { if (IsConnected == true) ADBCommand.ADBActionKey(ConsoleKey.Enter); }, (o) => { return true; });
            UpCommand = new DelegateCommand((o) => { if (IsConnected == true) ADBCommand.ADBActionKey(ConsoleKey.UpArrow);  }, (o) => { return true; });
            DownCommand = new DelegateCommand((o) => { if (IsConnected == true) ADBCommand.ADBActionKey(ConsoleKey.DownArrow);  }, (o) => { return true; });
            LeftCommand = new DelegateCommand((o) => { if (IsConnected == true) ADBCommand.ADBActionKey(ConsoleKey.LeftArrow); }, (o) => { return true; });
            RightCommand = new DelegateCommand((o) => { if (IsConnected == true) ADBCommand.ADBActionKey(ConsoleKey.RightArrow);  }, (o) => { return true; });
            BackCommand = new DelegateCommand((o) => { if (IsConnected == true) ADBCommand.ADBActionKey(ConsoleKey.Backspace); }, (o) => { return true; });
        }

        private string ipAddress = "192.168.1.86:5555";
        public string IpAddress {
            get {
                return ipAddress;
            }
            set {
                ipAddress = value;
                OnPropertyChanged("IpAddress");
            }
        }

        private bool? isConnected = false;
        public bool? IsConnected {
            get { return isConnected; }
            set {
                isConnected = value;
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
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }        
        }
    }
}
