using EntityFrameworkCore.Schema;
using EntityFrameworkCore.Schema.Extensions;
using EntityFrameworkCore.Shema.Providers;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

using System;


namespace EntityFrameWorkShema
{
    public static class Shemadatabase
    {
        public static DatabaseModel GetShema(string WorkingDirectory, DatabaseOptions databaseOptions)
        {

            var workingDirectory = GetWorkingDirectory(WorkingDirectory);
            var databaseProviders = GetDatabaseProviders(databaseOptions);
            var databaseModel = GetDatabaseModel(databaseProviders.factory, databaseOptions);

            //databaseOptions.Tables = databaseModel.Tables;



            return databaseModel;
        }


        private static string GetWorkingDirectory(string WorkingDirectory)
        {
            return WorkingDirectory ?? Environment.CurrentDirectory;
        }

        private static DatabaseModel GetDatabaseModel(IDatabaseModelFactory factory, DatabaseOptions databaseOptions)
        {
            //_logger.LogInformation("Loading database model ...");


            var connectionString = GetConnectionStringFromJsonOrSecreet(databaseOptions);
            var options = new DatabaseModelFactoryOptions();
            var databaseModel = factory.Create(connectionString, options);

            if (databaseModel == null)
                throw new InvalidOperationException("Failed to create database model");

            return databaseModel;
        }


        private static string GetConnectionStringFromJsonOrSecreet(DatabaseOptions database)
        {
            if (database.ConnectionString.HasValue())
                return database.ConnectionString;

            if (database.UserSecretsId.HasValue())
            {
                var secretsStore = new SecretsStore(database.UserSecretsId);
                if (secretsStore.ContainsKey(database.ConnectionName))
                    return secretsStore[database.ConnectionName];
            }

            throw new InvalidOperationException("Could not find connection string.");
        }
        public static (IDatabaseModelFactory factory, IRelationalTypeMappingSource mapping) GetDatabaseProviders(DatabaseOptions databaseOptions)
        {
            var provider = databaseOptions.Provider;

            //_logger.LogDebug("Creating database model factory for: {provider}", provider);

            // start a new service container to create the database model factory
            var services = new ServiceCollection()
                //.AddSingleton(_loggerFactory)
                .AddEntityFrameworkDesignTimeServices();

            switch (provider)
            {
                case DatabaseProviders.SqlServer:
                    ConfigureSqlServerServices(services);
                    break;
                case DatabaseProviders.PostgreSQL:
                    ConfigurePostgresServices(services);
                    break;
                case DatabaseProviders.MySQL:
                    ConfigureMySqlServices(services);
                    break;
                case DatabaseProviders.Sqlite:
                    ConfigureSqliteServices(services);
                    break;
                default:
                    throw new NotSupportedException($"The specified provider '{provider}' is not supported.");
            }

            var serviceProvider = services
                .BuildServiceProvider();

            var databaseModelFactory = serviceProvider
                .GetRequiredService<IDatabaseModelFactory>();

            var typeMappingSource = serviceProvider
                .GetRequiredService<IRelationalTypeMappingSource>();

            return (databaseModelFactory, typeMappingSource);
        }

        private static void ConfigureMySqlServices(IServiceCollection services)
        {
            var designTimeServices = new Pomelo.EntityFrameworkCore.MySql.Design.Internal.MySqlDesignTimeServices();
            designTimeServices.ConfigureDesignTimeServices(services);
        }

        private static void ConfigurePostgresServices(IServiceCollection services)
        {
            var designTimeServices = new Npgsql.EntityFrameworkCore.PostgreSQL.Design.Internal.NpgsqlDesignTimeServices();
            designTimeServices.ConfigureDesignTimeServices(services);
        }

        private static void ConfigureSqlServerServices(IServiceCollection services)
        {
            var designTimeServices = new Microsoft.EntityFrameworkCore.SqlServer.Design.Internal.SqlServerDesignTimeServices();
            designTimeServices.ConfigureDesignTimeServices(services);
        }

        private static void ConfigureSqliteServices(IServiceCollection services)
        {
            var designTimeServices = new Microsoft.EntityFrameworkCore.Sqlite.Design.Internal.SqliteDesignTimeServices();
            designTimeServices.ConfigureDesignTimeServices(services);
        }


    }
}
