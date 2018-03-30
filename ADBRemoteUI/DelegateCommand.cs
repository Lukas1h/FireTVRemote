using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ADBRemoteUI {
    class DelegateCommand : ICommand {
        public event EventHandler CanExecuteChanged;
        private Action<object> executeDelegate = null;
        private Func<object, bool> canExecuteDelegate = null;
        public DelegateCommand(Action<object> execute = null, Func<object, bool> canExecute = null) {
            executeDelegate = execute;
            canExecuteDelegate = canExecute;
        }

        public bool CanExecute(object parameter) {
            if (canExecuteDelegate != null) {
                return canExecuteDelegate(parameter);
            }
            return true;
        }

        public void Execute(object parameter) {
            if (executeDelegate != null) {
                executeDelegate(parameter);
            }
        }
    }
}
