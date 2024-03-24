//settings.cs
using System;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;

namespace StickyNote9
{
    public class Settings
    {
        public bool Pinned { get; set; }
        public Color NoteColor { get; set; }
        private readonly string settingsFilePath;

        private Settings()
        {
            // Constructor is made private to prevent direct instantiation.
            settingsFilePath = GetSettingsFilePath();
        }

        private static string GetSettingsFilePath()
        {
            string settingsDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "StickyNote9");
            Directory.CreateDirectory(settingsDirectory);
            return Path.Combine(settingsDirectory, "settings.json");
        }

        public static Settings LoadOrCreateDefault()
        {
            var settingsFilePath = GetSettingsFilePath();
            if (File.Exists(settingsFilePath))
            {
                var settingsText = File.ReadAllText(settingsFilePath);
                var settings = JsonConvert.DeserializeObject<Settings>(settingsText);
                return settings ?? CreateDefaultSettings();
            }
            else
            {
                return CreateDefaultSettings();
            }
        }

        private static Settings CreateDefaultSettings()
        {
            var settings = new Settings
            {
                Pinned = false,
                NoteColor = Color.White
            };
            settings.SaveSettings(); // Save default settings to file
            return settings;
        }

        public void SaveSettings()
        {
            var settingsText = JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(settingsFilePath, settingsText);
        }

        private void LoadSettings()
        {
            // This method now simply applies settings if they are loaded successfully.
            var settingsText = File.ReadAllText(settingsFilePath);
            var loadedSettings = JsonConvert.DeserializeObject<Settings>(settingsText);
            if (loadedSettings != null)
            {
                Pinned = loadedSettings.Pinned;
                NoteColor = loadedSettings.NoteColor;
            }
        }
    }
}
