using Safe.ViewModel;

using System.Windows;

namespace Safe.View {
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window {
        public RegisterWindow() {

            InitializeComponent();
            RegisterVM registerVM = new();
            DataContext = registerVM;
            if (registerVM.CloseAction == null)
                registerVM.CloseAction = new(Close);
        }
    }
}
