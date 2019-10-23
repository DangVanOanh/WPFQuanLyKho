using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropetyChange([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    class RelayCommand<T> : ICommand
    {   
        private readonly Predicate<T> _canExcute;
        private readonly Action<T> _excute;
        public RelayCommand(Predicate<T> canExcute, Action<T> excute)
        {
            if (excute == null)
            {
                throw new NotImplementedException();
            }

            this._canExcute = canExcute;
            this._excute = excute;
        }
        public bool CanExecute(object parameter)
        {
            try
            {
                return this._canExcute == null ? true : _canExcute((T)parameter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Execute(object parameter)
        {
            _excute((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value;}
        }
    }
}
