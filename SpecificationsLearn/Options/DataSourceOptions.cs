using Microsoft.Extensions.Configuration;

namespace SpecificationsLearn.Options
{
    public class DataSourceOptions
    {
        public string RepositoryType { get; set; }

        public bool UseNoSql { get; set; }

        public MongoDbDataProvider MongoDbDataProvider { get; set; }
        public EfCoreDataProvider EfCoreDataProvider { get; set; }

        public static DataSourceOptions ReadFromFile(string optionFileName = "App.config")
        {
            var options = new DataSourceOptions();
            var configuration = new ConfigurationBuilder().AddXmlFile(optionFileName).Build();

            configuration.GetSection("DataSourceOptions").Bind(options);

            return options;
        }
    }
}
