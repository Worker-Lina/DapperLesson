using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace DapperLesson.Service
{
    public class ConfigurationService
    {
        public static IConfiguration Configuration { get; private set; }

        public static void Init()
        {
            if (DbProviderFactories.TryGetFactory("DataProvider", out DbProviderFactory factory) == false)
            {
                DbProviderFactories.RegisterFactory("DataProvider", SqlClientFactory.Instance);
            }

            if (Configuration == null)
            {
                var configurationBuilder = new ConfigurationBuilder();
                Configuration = configurationBuilder.AddJsonFile("appSettings.json").Build();

            }
        }
    }
}
