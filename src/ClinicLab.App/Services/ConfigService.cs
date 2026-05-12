using System.IO;
using System.Text.Json;
using ClinicLab.App.Models;

namespace ClinicLab.App.Services;

public static class ConfigService
{
    private static readonly string ConfigPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "ClinicLab",
        "cliniclab-config.json"
    );

    public static bool Exists()
    {
        return File.Exists(ConfigPath);
    }

    public static AppSettings Load()
    {
        if (!File.Exists(ConfigPath))
            return new AppSettings();

        var json = File.ReadAllText(ConfigPath);

        return JsonSerializer.Deserialize<AppSettings>(json) ?? new AppSettings();
    }

    public static void Save(AppSettings settings)
    {
        var folder = Path.GetDirectoryName(ConfigPath);

        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder!);

        var json = JsonSerializer.Serialize(
            settings,
            new JsonSerializerOptions
            {
                WriteIndented = true
            }
        );

        File.WriteAllText(ConfigPath, json);
    }
}