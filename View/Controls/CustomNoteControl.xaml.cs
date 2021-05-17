using Safe.Model;

using System.Windows;
using System.Windows.Controls;

namespace Safe.View.Controls {
    /// <summary>
    /// Interaction logic for CustomNoteControl.xaml
    /// </summary>
    public partial class CustomNoteControl : UserControl {
        public Note Note {
            get { return (Note)GetValue(NoteProperty); }
            set { SetValue(NoteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Note.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NoteProperty =
            DependencyProperty.Register("Note", typeof(Note), typeof(CustomNoteControl), new PropertyMetadata(null, SetValue));

        private static void SetValue(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var CustomNote = d as CustomNoteControl;

            if (CustomNote != null) {
                CustomNote.DataContext = CustomNote.Note;
            }
        }

        public CustomNoteControl() {
            InitializeComponent();
        }
    }
}
