using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Liquinator.MVVM {
    public class RelayCommand : ICommand {
        private Action commandTask;
        private Action<object> commandTaskWithParameter;

        public RelayCommand(Action workToDo) {
            commandTask = workToDo;
        }

        public RelayCommand(Action<object> workToDo) {
            commandTaskWithParameter = workToDo;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute() {
            commandTask();
        }
        public void Execute(object parameter) {
            if (parameter != null) {
                commandTaskWithParameter(parameter);
            } else {
                commandTask();
            }
        }
    }
}
