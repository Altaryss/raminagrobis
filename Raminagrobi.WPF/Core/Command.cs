using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Raminagrobis.WPF.Core
{
    public class Command : ICommand
    {
        private Action _action;
        private Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Creates instance of the command handler
        /// </summary>
        /// <param name="action">Action to be executed by the command</param>
        /// <param name="canExecute">A bolean property to containing current permissions to execute the command</param>
        public Command(Action action, Func<bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public Command(Action action) : this(action, () => true)
        {

        }

        /// <summary>
        /// Forcess checking if execute is allowed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute.Invoke();
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }

    public class Command<T> : ICommand
    {
        private Action<T> _action;
        private Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Creates instance of the command handler
        /// </summary>
        /// <param name="action">Action to be executed by the command</param>
        /// <param name="canExecute">A bolean property to containing current permissions to execute the command</param>
        public Command(Action<T> action, Func<bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public Command(Action<T> action) : this(action, () => true)
        {

        }

        /// <summary>
        /// Forcess checking if execute is allowed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute.Invoke();
        }

        public void Execute(object parameter)
        {
            _action((T)parameter);
        }
    }
}
