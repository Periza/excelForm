using System;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

public sealed class AppSettings
{
    private static  Lazy<AppSettings> lazy = new Lazy<AppSettings>(() => LoadSettings());

    public static AppSettings Instance { get { return lazy.Value; } }

    public string KfServerPath { get; set; }
    public string SculptorPath { get; set; }
    public string ProjectPath { get; set; }

    public string TehnonPath { get; set; }

    private AppSettings()
    {
        Debug.WriteLine("app settings");
    }

    private static AppSettings LoadSettings()
    {
        if (!File.Exists("appsettings.json"))
        {
            Debug.WriteLine("File does not exist");
            var defaultSettings = new AppSettings
            {
                KfServerPath = @"C:\Sculptor1\bin\kfserver.exe",
                ProjectPath = @"D:\Tehnon2023\tehnon23",
                TehnonPath = @"D:\Tehnon2023",
                SculptorPath = @"C:\Sculptor1"
            };
            SaveSettings(defaultSettings);
            return defaultSettings;
        }
        else
        {
            using (var reader = new StreamReader("appsettings.json"))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return new JsonSerializer().Deserialize<AppSettings>(jsonReader);
            }
        }
    }

    private static void SaveSettings(AppSettings settings)
    {
        using (var writer = new StreamWriter("appsettings.json"))
        using (var jsonWriter = new JsonTextWriter(writer))
        {
            var serializer = new JsonSerializer()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };
            serializer.Serialize(jsonWriter, settings);
        }
    }
    public static void SaveSettings(string kfServer, string sculptor, string project, string tehnon)
    {
        var tempSettings = new AppSettings
        {
            KfServerPath = kfServer,
            ProjectPath = project,
            TehnonPath = tehnon,
            SculptorPath = sculptor
        };
        SaveSettings(tempSettings);
        lazy = new Lazy<AppSettings>(() => LoadSettings());
    }
}
