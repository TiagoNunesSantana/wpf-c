using Microsoft.Extensions.Configuration;

namespace ClinicLab.App.Helpers;

public static class AppConfig
{
    public static string ConnectionString { get; }

    static AppConfig()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        ConnectionString = config.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' não encontrada.");
    }
}
