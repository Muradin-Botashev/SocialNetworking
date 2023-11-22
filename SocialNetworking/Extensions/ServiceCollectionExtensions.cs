using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using SocialNetworking.Services.UserService;
using SocialNetworking.Storages.Migrations;
using SocialNetworking.Storages.UserStorage;

namespace SocialNetworking.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IUserStorage, UserStorage>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient(x => new NpgsqlConnection(connectionString));
            return services;
        }

        public static IServiceCollection AddFluentMigrator(this IServiceCollection services, string connectionString)
        {
          var serviceProvider=  services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddPostgres()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(InitialMigration).Assembly).For.Migrations())
                    .AddLogging(lb => lb.AddFluentMigratorConsole())
                    .BuildServiceProvider(false);
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();

            return services;
        }
    }
}