
using Safe.Helpers;
using Safe.Model;
using Safe.View;
using Safe.ViewModel.Helpers;

using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Safe.ViewModel {
    public class RegisterVM : ViewModelBase {

        public Action CloseAction { get; set; }
        public ICommand CreateAccountCommand { get; set; }
        public User User { get; set; } = new User();

        private string _Name;
        public string Name {
            get { return _Name; }
            set {
                if (_Name != value) {
                    _Name = value;
                    User.Name = _Name;
                    RaisePropertyChanged();
                    RaisePropertyChanged("User");
                }
            }
        }


        private string _Lastname;
        public string Lastname {
            get { return _Lastname; }
            set {
                if (_Lastname != value) {
                    _Lastname = value;
                    User.Lastname = Lastname;
                    RaisePropertyChanged();
                    RaisePropertyChanged("User");
                }
            }
        }

        private string _Username;
        public string Username {
            get { return _Username; }
            set {
                if (_Username != value) {
                    _Username = value;
                    User.Username = _Username;
                    RaisePropertyChanged();
                    RaisePropertyChanged("User");
                }
            }
        }

        private string _Password;
        public string Password {
            get { return _Password; }
            set {
                if (_Password != value) {
                    _Password = value;
                    User.Password = _Password;
                    RaisePropertyChanged();
                    RaisePropertyChanged("User");

                }
            }
        }

        public RegisterVM() {

            CreateAccountCommand = new HelperCommand() {
                ExecuteDelegate = x => RegisterUser(),
                CanExecuteDelegate = x => CanRegister()
            };
        }

        private bool CanRegister() {
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Lastname) &&
               !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password)) {
                return true;
            }
            return false;
        }

        private void RegisterUser() {
            LoginWindow loginWindow = new();
            loginWindow.Show();
            CloseAction();
        }
    }
}