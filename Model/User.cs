
using Safe.Helpers;

using SQLite;

namespace Safe.Model {
    public class User : ViewModelBase {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}