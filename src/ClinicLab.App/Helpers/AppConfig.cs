using ClinicLab.App.Services;

namespace ClinicLab.App.Helpers;

public static class AppConfig
{
    public static string ConnectionString
    {
        get
        {
            var env = Environment.GetEnvironmentVariable("CLINICLAB_CONNECTION_STRING");

            if (!string.IsNullOrWhiteSpace(env))
                return env;

            var settings = ConfigService.Load();

            if (!string.IsNullOrWhiteSpace(settings.ConnectionString))
                return settings.ConnectionString;

            return "Host=localhost;Port=5432;Database=cliniclab;Username=postgres;Password=postgres";
        }
    }
}