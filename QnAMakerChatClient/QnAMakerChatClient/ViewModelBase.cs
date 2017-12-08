using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace QnAMakerChatClient
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public abstract class CommandBase : ICommand
    {
        protected CommandBase() { }

        abstract public void ExecuteCore(object parameter);
        abstract public bool CanExecuteCore(object parameter);

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            try
            {
                return this.CanExecuteCore(parameter);
            }
            catch
            {
                throw;
            }
        }

        public void Execute(object parameter)
        {
            try
            {
                this.ExecuteCore(parameter);
            }
            catch
            {
                throw;
            }
        }
    }
}


