using Safe.ViewModel;

using System.Windows;

namespace Safe.View {
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window {
        public LoginWindow() {
            InitializeComponent();

            LoginVM loginVM = new();
            DataContext = loginVM;
            if (loginVM.CloseAction == null) {
                loginVM.CloseAction = new(Close);
            }
        }
    }
}
