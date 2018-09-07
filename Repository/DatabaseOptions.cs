using Microsoft.Extensions.Configuration;

namespace mydapper.Repository
{
    public class DatabaseOptions
    {
        public string ConnectionString { get; set; }
        public readonly IConfigurationRoot Configuration;

        public DatabaseOptions(IConfigurationRoot config)
        {
            Configuration = config;
        }

        public string GetConnection()
        {
            var connection = Configuration.GetSection("ConnectionStrings").GetSection("MBO").Value;
            return connection;
        }
    }
}