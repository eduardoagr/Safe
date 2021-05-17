using Safe.Model;

using System.Windows;
using System.Windows.Controls;

namespace Safe.View.Controls {
    /// <summary>
    /// Interaction logic for CustomNotebookControl.xaml
    /// </summary>
    public partial class CustomNotebookControl : UserControl {

        public Notebook Notebook {
            get { return (Notebook)GetValue(NotebookProperty); }
            set { SetValue(NotebookProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Notebook.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NotebookProperty =
            DependencyProperty.Register("Notebook", typeof(Notebook), typeof(CustomNotebookControl), new PropertyMetadata(null, SetValue));

        private static void SetValue(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var customNotebook = d as CustomNotebookControl;

            if (customNotebook != null) {

                customNotebook.DataContext = customNotebook.Notebook;
            }
        }

        public CustomNotebookControl() {
            InitializeComponent();
        }
    }
}
