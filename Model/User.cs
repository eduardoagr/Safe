
using Safe.Helpers;

using SQLite;

namespace Safe.Model {
    public class User : ViewModelBase {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private string _Name;
        public string Name {
            get { return _Name; }
            set {
                if (_Name != value) {
                    _Name = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _Lastname;
        public string Lastname {
            get { return _Lastname; }
            set {
                if (_Lastname != value) {
                    _Lastname = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _Username;
        public string Username {
            get { return _Username; }
            set {
                if (_Username != value) {
                    _Username = value;
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
                    RaisePropertyChanged();
                }
            }
        }
    }
}
