

using Newtonsoft.Json;

using Safe.Model;

using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Safe.ViewModel.Helpers {
    public class FirebaseAuth {

        public static string FirebaseKey = "AIzaSyA-ZJyEl0cQJlu0LUKBgOv3Q-1Vjr2-qaY";
        public static async Task<bool> RegisterUser(User user) {

            using HttpClient client = new();
            var body = new {

                email = user.email,
                password = user.Password,
                returnSecureToken = true
            };

            var bodyJson = JsonConvert.SerializeObject(body);
            var data = new StringContent(bodyJson, Encoding.UTF8, "application/json");
            var response = await client.PostAsync
                ($"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={FirebaseKey}", data);

            if (response.IsSuccessStatusCode) {
                string resutJson = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<AuthResult>(resutJson);
                App.UserId = res.localId;

                return true;

            } else {
                string errorJson = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<AuthError>(errorJson);
                MessageBox.Show(res.error.message);

                return false;
            }


        }
        public static async Task<bool> LoginUser(User user) {

            using HttpClient client = new();
            var body = new {

                email = user.email,
                password = user.Password,
                returnSecureToken = true
            };

            var bodyJson = JsonConvert.SerializeObject(body);
            var data = new StringContent(bodyJson, Encoding.UTF8, "application/json");
            var response = await client.PostAsync
                ($"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={FirebaseKey}", data);

            if (response.IsSuccessStatusCode) {
                string resutJson = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<AuthResult>(resutJson);
                App.UserId = res.localId;
                return true;

            } else {
                string errorJson = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<AuthError>(errorJson);
                MessageBox.Show(res.error.message);

                return false;
            }


        }
    }

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
