﻿
using System;
using System.Windows.Input;

namespace Safe.ViewModel.Helpers {
    public class HelperCommand : ICommand {
        public Predicate<object> CanExecuteDelegate { get; set; }
        public Action<object> ExecuteDelegate { get; set; }

        #region ICommand Members

        public bool CanExecute(object parameter) {
            if (CanExecuteDelegate != null)
                return CanExecuteDelegate(parameter);
            return true;// if there is no can execute default to true
        }

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter) {
            if (ExecuteDelegate != null) {
                ExecuteDelegate(parameter);
            }

            #endregion
        }
    }
}