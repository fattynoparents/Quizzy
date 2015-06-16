using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quizzy
{
    /// <summary>
    /// A command whose sole purpose is to 
    /// relay its functionality to other
    /// objects by invoking delegates. The
    /// default return value for the CanExecute
    /// method is 'true'.
    /// </summary>
    public class RelayCommand : ICommand, INotifyPropertyChanged
    {
        #region Fields

        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        string description;
        bool isVisible = false;
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion // Fields

        // ----   ----   ----   ----   ----   ----   ----   ----    ----   ----    ----    ----

        #region Constructors

        /// <summary>
        /// Creates a new command that can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(string descr, Action<object> execute)
            : this(descr, execute, null)
        {
        }
        // ----   ----   ----   ----   ----   ----   ----   ----    ----   ----    ----    ----

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(string descr, Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            description = descr;
            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion // Constructors
        // ----   ----   ----   ----   ----   ----   ----   ----    ----   ----    ----    ----


        public bool IsVisible
        {
            get { return (isVisible); }
            set
            {
                if (isVisible != value)
                {
                    isVisible = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("IsVisible"));
                }
            }
        }
        // ----   ----   ----   ----   ----   ----   ----   ----    ----   ----    ----    ----
        public string Description
        {
            get { return (description); }
            set
            {
                if (description != value)
                {
                    description = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Description"));
                }
            }
        }
        // ----   ----   ----   ----   ----   ----   ----   ----    ----   ----    ----    ----

        #region ICommand Members

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        #endregion // ICommand Members
    }

}
