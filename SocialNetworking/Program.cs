using Npgsql;
using SocialNetworking.Extensions;
using SocialNetworking.Models;

var builder = WebApplication.CreateBuilder(args);

var appSettings = new ConfigurationBuilder()
   .AddJsonFile("appsettings.json", true, true)
   .AddEnvironmentVariables().Build()
.GetSection(nameof(AppSettings))
.Get<AppSettings>();

var connectionString = new NpgsqlConnectionStringBuilder()
{
    Host = appSettings.DbSettings.DB_ENDPOINT,
    Port = appSettings.DbSettings.DB_PORT,
    Database = appSettings.DbSettings.DB_NAME,
    Username = appSettings.DbSettings.DB_USERNAME,
    Password = appSettings.DbSettings.DB_PASSWORD,
}.ToString();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer()
                .AddSwaggerGen()
                .AddSingleton(appSettings)
                .AddServices(connectionString)
                .AddFluentMigrator(connectionString);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();