using System;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Migrations.DailyLog.Migrations;

namespace Migrations.DailyLog
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var items = input?.Split(" ");
            if (items != null)
            {
                string migrationChoice = items[0];
                var serviceProvider = CreateServices();

                using (var scope = serviceProvider.CreateScope())
                {

                    if (migrationChoice != null && migrationChoice.ToLower().Equals("up"))
                    {
                        UpdateDatabase(scope.ServiceProvider);
                    }

                    if (migrationChoice != null && migrationChoice.ToLower().Equals("down"))
                    {
                        if (items.Length > 1)
                        {
                            var version = Convert.ToInt64(items[1]);
                            if (version > -1)
                            {
                                RollbackDatabase(scope.ServiceProvider, version);
                            }
                        }
                    }
                }
            }
        }

        private static IServiceProvider CreateServices()
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddPostgres()
                    .WithGlobalConnectionString(GetConnectionString())
                    .ScanIn(typeof(_001_UserTable).Assembly).For.Migrations())
                // Enable logging to console in the FluentMigrator way
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }

        private static void RollbackDatabase(IServiceProvider serviceProvider, long rollbackVersion)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateDown(rollbackVersion);
        }

        private static string GetConnectionString()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory
                .Split(new[] { @"bin\" }, StringSplitOptions.None)[0];

            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json");

            IConfigurationRoot configuration = builder.Build();
            var connectionString = configuration.GetConnectionString(Tables.DatabaseName);
            return connectionString;
        }
    }
}