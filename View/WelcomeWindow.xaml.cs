using Safe.ViewModel;

using System.Windows;

namespace Safe.View {
    /// <summary>
    /// Interaction logic for WelcomeWindow.xaml
    /// </summary>
    public partial class WelcomeWindow : Window {
        public WelcomeWindow() {
            InitializeComponent();

            WelcomeWindowVM welcomeWindowVM = new();
            DataContext = welcomeWindowVM;
            if (welcomeWindowVM.CloseAction == null) {
                welcomeWindowVM.CloseAction = new(Close);
            }
        }
    }
}
