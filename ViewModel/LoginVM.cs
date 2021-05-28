
using MvvmHelpers.Commands;

using Safe.Helpers;
using Safe.Model;
using Safe.ViewModel.Helpers;

using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Safe.ViewModel {
    public class LoginVM : ViewModelBase {

        private bool isShowingRegister = false;
        public ICommand RegisterCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public HelperCommand CreateAccountCommand { get; }
        public ICommand SwitchViewsCommand { get; set; }
        public User User { get; set; }
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


        private string _Email;
        public string Email {
            get { return _Email; }
            set {
                if (_Email != value) {
                    _Email = value;
                    User.email = Email;
                    RaisePropertyChanged();
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

        private string _ConfirmPassword;
        public string ConfirmPassword {
            get { return _ConfirmPassword; }
            set {
                if (_ConfirmPassword != value) {
                    _ConfirmPassword = value;
                    User.ConfirmPassword = ConfirmPassword;
                    RaisePropertyChanged();
                    RaisePropertyChanged("User");
                }
            }
        }

        private Visibility _LoginVis;
        public Visibility LoginVis {
            get { return _LoginVis; }
            set {
                if (_LoginVis != value) {
                    _LoginVis = value;
                    RaisePropertyChanged();
                }
            }
        }


        private Visibility _RegisterVis;
        public Visibility RegisterVis {
            get { return _RegisterVis; }
            set {
                if (_RegisterVis != value) {
                    _RegisterVis = value;
                    RaisePropertyChanged();
                }
            }
        }

        public event EventHandler Authenticacated;

        public LoginVM() {
            User = new User();
            LoginVis = Visibility.Visible;
            RegisterVis = Visibility.Collapsed;
            SwitchViewsCommand = new Command(() => SwitchViews());
            LoginCommand = new HelperCommand {
                ExecuteDelegate = x => LoginAsync(),
                CanExecuteDelegate = x => CanLogin()
            };
            CreateAccountCommand = new HelperCommand {
                ExecuteDelegate = x => CreateAccount(),
                CanExecuteDelegate = x => CanCreateAccount()
            };
        }

        private async void CreateAccount() {
            bool isSuccessful = await FirebaseAuth.RegisterUser(User);
            if (isSuccessful) {
                Authenticacated?.Invoke(this, new EventArgs());
            }
        }

        private bool CanCreateAccount() {
            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password)
             && !string.IsNullOrEmpty(ConfirmPassword)
             && Password == ConfirmPassword) {
                return true;
            }
            return false;
        }

        private async void LoginAsync() {
            bool isSuccessful = await FirebaseAuth.LoginUser(User);
            if (isSuccessful) {
                Authenticacated?.Invoke(this, new EventArgs());
            }

        }

        private bool CanLogin() {

            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password)) {
                return true;
            }
            return false;
        }

        private void SwitchViews() {

            isShowingRegister = !isShowingRegister;
            if (isShowingRegister) {
                RegisterVis = Visibility.Visible;
                LoginVis = Visibility.Collapsed;
            } else {
                RegisterVis = Visibility.Collapsed;
                LoginVis = Visibility.Visible;
            }
        }
    }
}