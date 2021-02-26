using EntityFrameworkCore.Shema.Providers;
using System.Collections.Generic;

namespace EntityFrameWorkShema
{
    public class DatabaseOptions
    {
        public DatabaseOptions()
        {
            Provider = DatabaseProviders.SqlServer;
            ConnectionString = "Server=LAPTOP-UI0SF7P6;Database=CleanArchitectureDbTest1;Trusted_Connection=True;MultipleActiveResultSets=true;";
            UserSecretsId = "";
            ConnectionName = "";
            Directory = "P:\\.NET\\CleanArchitecture.Plurasight\\TestGenerationScafold\\CrudPure";
            Exclude = new List<MatchOptions>();

        }

        public DatabaseProviders Provider { get; set; }
        public string ConnectionString { get; set; }
        public string UserSecretsId { get; set; }
        public string ConnectionName { get; set; }
        public string Directory { get; set; }

        public List<MatchOptions> Exclude { get; set; }


    }
}
