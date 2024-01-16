using System.Collections.ObjectModel;
using System.Windows;
using TrackVoiceGUI.Config;
using TrackVoiceGUI.Data;
using TrackVoiceGUI.Models.TVSystem;

namespace TrackVoiceGUI.Windows
{
    /// <summary>
    /// Interaction logic for CredentialsWindow.xaml
    /// </summary>
    public partial class CredentialsWindow : Window
    {
        public ObservableCollection<CloudCredential> CloudCredentials { get; set; }

        public CredentialsWindow()
        {
            InitializeComponent();

            CloudCredentials = new ObservableCollection<CloudCredential>();
            LoadCloudCredentials();
            myDataGrid.ItemsSource = CloudCredentials;
        }

        private void LoadCloudCredentials()
        {
            using (var context = new CloudCostingsContext(dbFile: GlobalVariables.SelectedDBFilePath))
            {
                var credentials = context.CloudCredentials.ToList();
                foreach (var credential in credentials)
                {
                    CloudCredentials.Add(credential);
                }
            }
        }

        private void SaveCloudCredentials()
        {
            using (var context = new CloudCostingsContext(dbFile: GlobalVariables.SelectedDBFilePath))
            {
                foreach (var credential in CloudCredentials)
                {
                    // If the credential has an ID, it's an existing entity, so update it.
                    // Otherwise, it's a new entity, so add it.
                    if (credential.Id > 0)
                    {
                        context.Update(credential);
                    }
                    else
                    {
                        context.Add(credential);
                    }
                }
                context.SaveChanges();

                MessageBox.Show("DB Updated", "OK");  // notify save is OK
                this.Close();  // close this window
            }
        }

        private void SaveDataGrid_Click(object sender, RoutedEventArgs e)
        {
            SaveCloudCredentials();
        }
    }
}
