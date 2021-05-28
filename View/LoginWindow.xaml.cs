
using Safe.ViewModel;

using System.Windows;

namespace Safe.View {
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window {
        readonly LoginVM vM;
        public LoginWindow() {
            InitializeComponent();

            vM = Resources["vm"] as LoginVM;
            vM.Authenticacated += VM_Authenticacated;

        }

        private void VM_Authenticacated(object sender, System.EventArgs e) {
            Close();
        }
    }
}
