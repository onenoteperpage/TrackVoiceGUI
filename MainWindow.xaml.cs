using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using TrackVoiceGUI.Config;
using TrackVoiceGUI.Data;
using TrackVoiceGUI.Methods;
using TrackVoiceGUI.Windows;

namespace TrackVoiceGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ComboBox_CloudProvider.SelectedIndex = -1; // No item selected
            ComboBox_CloudProvider.Text = "Select provider..."; // Placeholder text
            ComboBox_CloudProvider.SelectionChanged += ComboBox_CloudProvider_SelectionChanged;
            //TVSystemBase.InitDb();
        }

        private void SelectDB_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "SQLite Database files (*.sqlitedb)|*.sqlitedb";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == true)
            {
                GlobalVariables.SelectedDBFilePath = openFileDialog.FileName;
                DBSelectedPath.Text = GlobalVariables.SelectedDBFilePath; // Directly set the TextBox text

                try
                {
                    // load the cloud provider dropdown
                    var cloudProviders = TVSystemBase.LoadDbProviders(dbFilename: GlobalVariables.SelectedDBFilePath);
                    ComboBox_CloudProvider.Items.Clear();
                    foreach (var cloudProvider in cloudProviders)
                    {
                        ComboBox_CloudProvider.Items.Add(cloudProvider);
                    }

                    // enable cloud provider selector drop box
                    ComboBox_CloudProvider.IsEnabled = true;

                    // enable refresh button
                    Button_RefreshDB.IsEnabled = true;
                }
                catch
                {
                    MessageBoxResult result = MessageBox.Show("Invalid DB selected, TrackVoice will exit.\n\nUse 'Config' to create empty new DB\nor obtain appropriate DB file.", "Error - Invalid DB", MessageBoxButton.OK, MessageBoxImage.Question);
                    if (result == MessageBoxResult.OK)
                    {
                        this.Close();
                    }
                }

            }
        }

        private void SetDirectory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_CloudProvider_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox_Region.Items.Clear();

            if (ComboBox_CloudProvider.SelectedItem is string selectedProvider)
            {
                var regions = TVSystemBase.LoadDbRegions(dbFilename: GlobalVariables.SelectedDBFilePath, provider: selectedProvider);
                foreach (var region in regions)
                {
                    ComboBox_Region.Items.Add(region);
                }
                ComboBox_Region.IsEnabled = true;
            }

            //ComboBox_Region.SelectedIndex = 0;
        }

        private void OpenConfig_Click(object sender, RoutedEventArgs e)
        {
            ConfigWindow configWindow = new ConfigWindow();
            configWindow.Owner = this;
            configWindow.ShowDialog();
        }
    }
}