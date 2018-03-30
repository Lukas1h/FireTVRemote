using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ADBRemoteUI {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private MainWindowViewModel ViewModel { get; set; }
        static MainWindow() {
            
        }

        public MainWindow() {
            InitializeComponent();
            ViewModel = new MainWindowViewModel();
            this.DataContext = ViewModel;
            this.Closing += MainWindow_Closing;
        }
        
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            ADB_Lib.ADBCommand.ExecuteAdbCommand("disconnect");
            ADB_Lib.ADBCommand.ExecuteAdbCommand("kill-server");
            Environment.Exit(0);
        }
    }
}
