using TrackVoiceGUI.Data;
using TrackVoiceGUI.Models.TVSystem;

namespace TrackVoiceGUI.Methods
{
    public class TVSystemBase
    {
        public static void InitDb(string dbFilename)
        {
            var emptyCredentials = new CloudCredential
            {
                Provider = "Test",
                Region = "Test",
                Account = "Test",
                TTS_AccessKey = "Test",
                TTS_SecretAccessKey = "Test",
                TTS_SessionToken = "Test",
                Disabled = false
            };

            using (CloudCostingsContext context = new CloudCostingsContext(dbFilename))
            {
                context.Database.EnsureCreated();
                context.CloudCredentials.Add(emptyCredentials);
                context.SaveChanges();
            }
        }


        public static List<string> LoadDbProviders(string dbFilename)
        {
            using (CloudCostingsContext context = new CloudCostingsContext(dbFilename))
            {
                // Retrieve all providers, convert them to uppercase, and get distinct values
                var uniqueProviders = context.CloudCredentials
                                             .Where(u => u.Provider != null)
                                             .Select(u => u.Provider.ToUpper())
                                             .Distinct()
                                             .ToList();

                return uniqueProviders;
            }
        }


        public static List<string> LoadDbRegions(string dbFilename, string provider)
        {
            using (CloudCostingsContext context = new CloudCostingsContext(dbFilename))
            {
                var uniqueRegions = context.CloudCredentials
                    .Where(u => u.Provider.ToUpper() == provider)
                    .Select(u => u.Region!.ToUpper())
                    .Distinct()
                    .ToList();

                return uniqueRegions;
            }
        }
    }
}
