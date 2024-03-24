using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;

namespace StickyNote9
{
    public class NoteManager
    {
        private string notesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "notes");

        public NoteManager()
        {
            // Ensure the notes directory exists
            if (!Directory.Exists(notesDirectory))
            {
                Directory.CreateDirectory(notesDirectory);
            }
        }

        public void Save(Note note)
        {
            // Use a fully qualified name for Formatting to resolve ambiguity
            string noteFilePath = Path.Combine(notesDirectory, $"{note.Id}.json");
            string json = JsonConvert.SerializeObject(note, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(noteFilePath, json);
        }
        public bool Delete(string id)
        {
            string noteFilePath = Path.Combine(notesDirectory, $"{id}.json");
            try
            {
                if (File.Exists(noteFilePath))
                {
                    File.Delete(noteFilePath);
                    return true; // File deleted successfully
                }
                return false; // File not found
            }
            catch (Exception ex)
            {
                // Log the exception here
                return false; // An error occurred
            }
        }





        public Note Load(string id)
        {
            string noteFilePath = Path.Combine(notesDirectory, $"{id}.json");
            if (File.Exists(noteFilePath))
            {
                string json = File.ReadAllText(noteFilePath);
                return JsonConvert.DeserializeObject<Note>(json);
            }
            return null;
        }

        public IEnumerable<Note> LoadAll()
        {
            foreach (string filePath in Directory.GetFiles(notesDirectory, "*.json"))
            {
                string json = File.ReadAllText(filePath);
                yield return JsonConvert.DeserializeObject<Note>(json);
            }
        }
    }

    public class Note
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public Point Position { get; set; }
        public Size Size { get; set; } // Add this line
        public Color NoteColor { get; set; }
        public bool Pinned { get; set; }
    }
}