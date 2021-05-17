
using Safe.Helpers;
using Safe.Model;
using Safe.View;
using Safe.ViewModel.Helpers;

using System;
using System.Windows.Input;

namespace Safe.ViewModel {
    public class LoginVM : ViewModelBase {
        public ICommand LoginCommand { get; private set; }

        public Action CloseAction { get; set; }

        public User User { get; set; } = new User();

        private string _Username;
        public string Username {
            get { return _Username; }
            set {
                if (_Username != value) {
                    _Username = value;
                    User.Username = Username;
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
                    User.Password = Password;
                    RaisePropertyChanged();
                    RaisePropertyChanged("User");
                }
            }
        }


        public LoginVM() {
            LoginCommand = new HelperCommand {
                ExecuteDelegate = x => Login(),
                CanExecuteDelegate = x => CanLogin()
            };
        }

        private void Login() {
            NotesWindow notesWindow = new();
            notesWindow.Show();
            CloseAction();
        }

        private bool CanLogin() {

            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password)) {
                return true;
            }
            return false;

        }
    }
}
