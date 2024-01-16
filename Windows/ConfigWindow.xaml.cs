using Microsoft.Win32;
using System.IO;
using System.Windows;
using TrackVoiceGUI.Config;
using TrackVoiceGUI.Methods;

namespace TrackVoiceGUI.Windows
{
    /// <summary>
    /// Interaction logic for ConfigWindow.xaml
    /// </summary>
    public partial class ConfigWindow : Window
    {
        public ConfigWindow()
        {
            InitializeComponent();
            CW_EnableButtons();
        }

        private void CW_EnableButtons()
        {
            if (!string.IsNullOrEmpty(GlobalVariables.SelectedDBFilePath))
            {
                CWButton_UpdateCredentials.IsEnabled = true;
            }
        }

        private void CWButton_UpdateCredentials_Click(object sender, RoutedEventArgs e)
        {
            CredentialsWindow credentialsWindow = new CredentialsWindow();
            credentialsWindow.Owner = this;
            credentialsWindow.ShowDialog();
        }

        private void CWButton_InitDB_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.FileName = "TrackVoiceDB.sqlitedb";
            saveFileDialog.DefaultExt = ".sqlitedb";
            saveFileDialog.Filter = "SQLite Database files (*.sqlitedb)|*.sqlitedb";

            // show save file dialog
            bool? result = saveFileDialog.ShowDialog();

            // process to save file dialog box results
            if (result == true)
            {
                // save document
                string filename = saveFileDialog.FileName;

                // create an empty .db file at the location
                File.Create(filename).Dispose();

                TVSystemBase.InitDb(dbFilename: filename);
            }
        }

        private void CWButton_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CWButton_SetSeedValue_Click(object sender, RoutedEventArgs e)
        {
            SetSeedValueWindow setSeedValueWindow = new SetSeedValueWindow();
            setSeedValueWindow.Owner = this;
            setSeedValueWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            setSeedValueWindow.ShowDialog();
        }
    }
}
