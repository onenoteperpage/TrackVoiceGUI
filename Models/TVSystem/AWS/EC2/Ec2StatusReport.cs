using System.ComponentModel.DataAnnotations;

namespace TrackVoiceGUI.Models.TVSystem.AWS.EC2
{
    public class Ec2StatusReport
    {
        [Key]
        public int Id { get; set; }
        public string InstanceId { get; set; } = null!;  // must be provided, is an instance Id (for AWS, extend to Azure?)
        public string Provider { get; set; } = "AWS";
        public string? ProductOwner { get; set; }  // this correlates directly into Ec2CsvReport table for the same parameter
        public bool IsExempt { get; set; } = false;  // if a record is exempt, this should be set to true, it will be ignored in reports unless ExtendedAttributes are selected
        public string UpdatedBy { get; set; } = string.Empty;  // who updated this record? they need to put their name against it or it won't take
        public DateTime LastUpdated { get; set; }  // datetime value the record was last updated
    }
}
