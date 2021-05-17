using System.Windows;
using System.Windows.Controls;

namespace Safe.View.Controls {
    /// <summary>
    /// Interaction logic for CustomPasswordControl.xaml
    /// </summary>
    public partial class CustomPasswordControl : UserControl {

        public string Password {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(CustomPasswordControl), new PropertyMetadata(string.Empty));


        public CustomPasswordControl() {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e) {

            Password = PasswordBox.Password;
        }
    }
}
