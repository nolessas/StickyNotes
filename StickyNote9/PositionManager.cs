//PositionManager.cs
using System;
using System.Collections.Generic;
using System.Drawing; // Make sure to use System.Drawing for Point
using System.IO;
using Newtonsoft.Json; // Make sure Newtonsoft.Json is referenced

namespace StickyNote9
{
    public class PositionManager
    {
        private readonly string positionFilePath;
        private Dictionary<string, Point> positions;

        public PositionManager()
        {
            string positionDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "StickyNote9");
            Directory.CreateDirectory(positionDirectory);
            positionFilePath = Path.Combine(positionDirectory, "positions.json");
            positions = LoadPositions();
        }

        public void SavePosition(string id, Point position)
        {
            positions[id] = position;
            SavePositions();
        }

        public Point LoadPosition(string id)
        {
            return positions.ContainsKey(id) ? positions[id] : new Point(100, 100); // Default position
        }

        private Dictionary<string, Point> LoadPositions()
        {
            if (File.Exists(positionFilePath))
            {
                string json = File.ReadAllText(positionFilePath);
                return JsonConvert.DeserializeObject<Dictionary<string, Point>>(json);
            }
            return new Dictionary<string, Point>();
        }

        private void SavePositions()
        {
            string json = JsonConvert.SerializeObject(positions, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(positionFilePath, json);
        }
    }
}