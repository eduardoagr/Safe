using MvvmHelpers.Commands;

using Safe.View;

using System;
using System.Windows;
using System.Windows.Input;

namespace Safe.ViewModel {
    public class WelcomeWindowVM {

        public Action CloseAction { get; set; }
        public ICommand SingUpCommand { get; set; }
        public ICommand SignInCommand { get; set; }

        public WelcomeWindowVM() {

            SingUpCommand = new Command(() => {
                RegisterWindow registerWindow = new();
                registerWindow.Show();
                CloseAction();
            });

            SignInCommand = new Command(() => {
                LoginWindow login = new();
                login.Show();
                CloseAction();
            });
        }
    }
}
