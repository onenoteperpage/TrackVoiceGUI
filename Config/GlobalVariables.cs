using System.ComponentModel;

namespace TrackVoiceGUI.Config
{
    public static class GlobalVariables
    {
        public static string SelectedDBFilePath { get; set; } = string.Empty;
    }

    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public string SelectedDBFilePath
        {
            get => GlobalVariables.SelectedDBFilePath;
            set
            {
                if (GlobalVariables.SelectedDBFilePath != value)
                {
                    GlobalVariables.SelectedDBFilePath = value;
                    OnPropertyChanged(nameof(SelectedDBFilePath));
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
