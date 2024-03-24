using System;
using System.Linq;
using System.Windows.Forms;

namespace StickyNote9
{
    internal static class Program
    {
        // Declare noteManager at the class level if needed across multiple static methods.
        private static NoteManager noteManager;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize noteManager here if it's only needed in Main.
            noteManager = new NoteManager();
            var notes = noteManager.LoadAll().ToList();

            // Application exit event handler to save all notes
            Application.ApplicationExit += (sender, e) =>
            {
                // Save notes on application exit.
                foreach (var form in Application.OpenForms.OfType<Form1>())
                {
                    form.SaveNote();
                }
            };

            // Show the main form or the first note
            Form1 mainForm = notes.Any() ? new Form1(notes.First()) : new Form1();
            mainForm.Show();

            // Show any additional notes
            foreach (var note in notes.Skip(1))
            {
                var noteForm = new Form1(note);
                noteForm.Show();
            }

            Application.Run();
        }
    }
}
