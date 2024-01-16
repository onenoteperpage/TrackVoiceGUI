using System.Windows;
using System.Windows.Media;

namespace TrackVoiceGUI.Windows
{
    /// <summary>
    /// Interaction logic for SetSeedValueWindow.xaml
    /// </summary>
    public partial class SetSeedValueWindow : Window
    {
        public SetSeedValueWindow()
        {
            InitializeComponent();
        }

        private void SVButton_Set_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SVTextBox_Seed_Value_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SVTextBox_Seed_Value.Text == "enter seed value...")
            {
                SVTextBox_Seed_Value.Text = string.Empty;
                SVTextBox_Seed_Value.Foreground = Brushes.Black;
                SVTextBox_Seed_Value.FontStyle = FontStyles.Normal;
            }
        }

        private void SVTextBox_Seed_Value_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SVTextBox_Seed_Value.Text))
            {
                SVTextBox_Seed_Value.Text = "enter seed value...";
                SVTextBox_Seed_Value.Foreground = Brushes.Gray;
                SVTextBox_Seed_Value.FontStyle = FontStyles.Italic;
            }
        }

        private void SVButton_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
