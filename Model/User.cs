
using Safe.Helpers;

namespace Safe.Model {
    public class User : ViewModelBase {
        public string email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}