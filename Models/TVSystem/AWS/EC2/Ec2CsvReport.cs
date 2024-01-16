using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace TrackVoiceGUI.Models.TVSystem.AWS.EC2
{
    public class Ec2CsvReport
    {
        [Key]
        public int Id { get; set; }
        public string InstanceId { get; set; } = null!;
        public string? Name { get; set; }
        public DateTime LaunchTime { get; set; } = DateTime.UtcNow;
        public string InstanceType { get; set; } = null!;
        public string? Environment { get; set; }
        public string AvailabilityZone { get; set; } = null!;
        public string? Account { get; set; }
        public string OperatingSystem { get; set; } = null!;
        public string? PrivateIP { get; set; }
        public string PowerState { get; set; } = null!;
        public string ReportingMonth { get; set; } = GetFormattedLastMonth();
        public double? CpuAvgUsage { get; set; } = Math.Round((double)0, 2);
        public double? CpuHigh { get; set; } = Math.Round((double)0, 2);
        public double? CpuLow { get; set; } = Math.Round((double)0, 2);
        public decimal? EstimatedPrice { get; set; }
        public decimal CalculatedCost { get; set; }
        public string? Recommendation { get; set; }
        public string? ProductOwner { get; set; }

        private static string GetFormattedLastMonth()
        {
            return DateTime.Now.AddMonths(-1).ToString("MMM-yyyy", CultureInfo.InvariantCulture).ToUpper();
        }
    }
}
