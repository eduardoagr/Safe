
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Safe.View {
    /// <summary>
    /// Interaction logic for NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window {
        readonly string region = "westeurope";
        readonly string key = "2ac1fba0bf9d40bca76d17fd0a94d69e";
        readonly SpeechRecognizer recog;
        bool isRecognizing;

        public NotesWindow() {
            InitializeComponent();

            var speechRecognizer = SpeechConfig.FromSubscription(key, region);
            var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
            recog = new SpeechRecognizer(speechRecognizer, audioConfig);

            recog.Recognized += SpeechRecognizer_Recognized;
        }
        private async void SpeechRecognizer_Recognized(object sender, SpeechRecognitionEventArgs e) {
            if (e.Result.Reason == ResultReason.RecognizedSpeech) {
                await Dispatcher.InvokeAsync(() => NoteContent.AppendText($"{e.Result.Text}"));

            }
        }
        private void NoteContent_TextChanged(object sender, TextChangedEventArgs e) {
            FlowDocument doc = NoteContent.Document;
            int count = new TextRange(doc.ContentStart, doc.ContentEnd).Text.Length;
            NumOfCharacters.Text = $"Characters: {count}";
        }
        private async void SpeechBton_Click(object sender, RoutedEventArgs e) {

            var toggle = sender as System.Windows.Controls.Primitives.ToggleButton;
            switch (toggle.Tag) {
                case "0":
                    if (!isRecognizing) {
                        await recog.StartContinuousRecognitionAsync();

                        isRecognizing = true;
                        SpeechBton.IsChecked = true;
                    } else {
                        await recog.StopContinuousRecognitionAsync();

                        isRecognizing = false;
                        SpeechBton.IsChecked = false;
                    }
                    break;
                case "1":
                    bool isChecked = toggle.IsChecked ?? false;
                    if (isChecked) {
                        NoteContent.Selection.ApplyPropertyValue(FontWeightProperty, FontWeights.Bold);
                    } else {
                        NoteContent.Selection.ApplyPropertyValue(FontWeightProperty, FontWeights.Normal);
                    }
                    break;
                case "2":
                    bool isEnable = toggle.IsChecked ?? false;
                    if (isEnable) {
                        NoteContent.Selection.ApplyPropertyValue(FontStyleProperty, FontStyles.Italic);
                    } else {
                        NoteContent.Selection.ApplyPropertyValue(FontStyleProperty, FontStyles.Normal);
                    }
                    break;
                case "3":
                    bool isPressed = toggle.IsChecked ?? false;
                    if (isPressed) {
                        NoteContent.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
                    } else {

                        (NoteContent.Selection.GetPropertyValue(Inline.TextDecorationsProperty) as TextDecorationCollection)
                            .TryRemove(TextDecorations.Underline, out TextDecorationCollection decorations);
                        NoteContent.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, decorations);
                    }
                    break;
            }
        }
        private void NoteContent_SelectionChanged(object sender, RoutedEventArgs e) {

            var selectionFontWeight = NoteContent.Selection.GetPropertyValue(Inline.FontWeightProperty);
            boldBton.IsChecked = (selectionFontWeight != DependencyProperty.UnsetValue)
                && selectionFontWeight.Equals(FontWeights.Bold);

            var selectionFontStyle = NoteContent.Selection.GetPropertyValue(Inline.FontStyleProperty);
            italicBton.IsChecked = (selectionFontStyle != DependencyProperty.UnsetValue)
                && selectionFontStyle.Equals(FontStyles.Italic);

            var selectionFontDecoration = NoteContent.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            UndelineBton.IsChecked = (selectionFontDecoration != DependencyProperty.UnsetValue)
                && selectionFontDecoration.Equals(TextDecorations.Underline);

            FontsComboBox.SelectedItem = NoteContent.Selection.GetPropertyValue(FontFamilyProperty);
            SizeConboBox.Text = (NoteContent.Selection.GetPropertyValue(FontSizeProperty)).ToString();
        }

        private void FontsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (FontsComboBox.SelectedItem != null) {
                NoteContent.Selection.ApplyPropertyValue(FontFamilyProperty, FontsComboBox.SelectedItem);
            }
        }

        private void SizeConboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            NoteContent.Selection.ApplyPropertyValue(FontSizeProperty, SizeConboBox.Text);
        }
    }
}