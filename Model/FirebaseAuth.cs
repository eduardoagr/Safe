namespace Safe.Model {
    public class AuthResult {
        public string idToken { get; set; }
        public string email { get; set; }
        public string refreshToken { get; set; }
        public string expiresIn { get; set; }
        public string localId { get; set; }
    }
    public class ErrorDetails {
        public int code { get; set; }
        public string message { get; set; }
    }
    public class AuthError {
        public ErrorDetails error { get; set; }
    }

}