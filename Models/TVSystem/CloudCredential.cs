using System.ComponentModel.DataAnnotations;

namespace TrackVoiceGUI.Models.TVSystem
{
    public class CloudCredential
    {
        [Key]
        public int Id { get; set; }
        public string Provider { get; set; } = null!;
        public string Region { get; set; } = null!;
        public string? Account { get; set; }
        public string? TTS_AccessKey { get; set; }
        public string? TTS_SecretAccessKey { get; set; }
        public string? TTS_SessionToken { get; set; }
        public bool Disabled { get; set; } = false;
    }
}
