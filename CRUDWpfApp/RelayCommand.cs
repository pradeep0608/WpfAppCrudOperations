using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRUDWpfApp
{
    public class RelayCommand: ICommand
    {
        Action<object> m_action;
        public RelayCommand(Action<object> action)
        {
            m_action = action;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            m_action(parameter);
        }
    }
}
