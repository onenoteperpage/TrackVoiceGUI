using Microsoft.EntityFrameworkCore;
using TrackVoiceGUI.Models.TVSystem;
using TrackVoiceGUI.Models.TVSystem.AWS.EC2;

namespace TrackVoiceGUI.Data
{
    public class CloudCostingsContext : DbContext
    {
        private readonly string _dbFile;

        public DbSet<CloudCredential> CloudCredentials { get; set; }
        public DbSet<Ec2StatusReport> Ec2StatusReports { get; set; }

        public CloudCostingsContext(string dbFile)
        {
            _dbFile = dbFile;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source={_dbFile}");
            }
        }
    }
}
