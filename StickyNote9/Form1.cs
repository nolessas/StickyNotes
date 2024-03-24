using System;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace StickyNote9
{
    public partial class Form1 : Form
    {
        private NoteManager noteManager;
        private ColorManager colorManager;
        private PositionManager positionManager;
        private Settings settings;
        private Note thisNote; // Declare thisNote to keep track of the current note

        public Form1(Note note = null) // The constructor now takes a Note object as an optional parameter
        {
            InitializeComponent();
            noteManager = new NoteManager();
            colorManager = new ColorManager();
            positionManager = new PositionManager();
            settings = Settings.LoadOrCreateDefault();

            ApplyLoadedSettings();

            if (note != null)
            {
                thisNote = note;
                LoadSpecificNote(note);
            }
            else
            {
                thisNote = CreateDefaultNote();
            }
            LoadNote();
        }

        private void ApplyLoadedSettings()
        {
            this.TopMost = settings.Pinned;
            textBox1.BackColor = settings.NoteColor;
            // Apply other settings as needed
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveNote(); // This will save the note's current state
        }

        public void SavePosition()
        {
            positionManager.SavePosition(thisNote.Id, this.Location); // Your saving logic here
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SaveNote(); // Save note whenever text changes
        }

        // New method to handle the Move event for the form
        private void Form1_Move(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal && thisNote != null)
            {
                thisNote.Position = this.Location;
                positionManager.SavePosition(thisNote.Id, this.Location); // Make sure SavePosition is accessible
                SaveNote();
            }
        }


        public void SaveNote()
        {
            // Update thisNote properties
            thisNote.Content = textBox1.Text;

      

            thisNote.Pinned = this.TopMost;

            // Save thisNote using NoteManager
            noteManager.Save(thisNote);
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            if (thisNote != null && WindowState == FormWindowState.Normal)
            {
                SaveNote(); // Save note whenever the form is resized
            }
        }


        private Note CreateDefaultNote()
        {
            return new Note
            {
                Id = Guid.NewGuid().ToString(),
                Content = "",
                Position = new Point(200, 200),
      
                NoteColor = colorManager.GetNextColor(),
                Pinned = false
            };
        }



        private void LoadNote()
        {
            Note loadedNote = noteManager.Load(thisNote.Id);
            if (loadedNote != null)
            {
                thisNote = loadedNote;
                DisplayNote(thisNote);
                this.Location = positionManager.LoadPosition(thisNote.Id);
                textBox1.BackColor = thisNote.NoteColor;
            }
        }




        private void DisplayNote(Note note)
        {
            textBox1.Text = note.Content;
            this.Location = note.Position;
          
            textBox1.BackColor = note.NoteColor;
            ApplyNoteColor(note.NoteColor);
            PinNote(note.Pinned);
        }


        private void ApplyNoteColor(Color color)
        {
            textBox1.BackColor = color;
            settings.NoteColor = color;
        }

        private void PinNote(bool pin)
        {
            this.TopMost = pin;
            settings.Pinned = pin;
        }


        // Event handler for the Color button click
        private void Color_Click(object sender, EventArgs e)
        {
            var nextColor = colorManager.GetNextColor();
            textBox1.BackColor = nextColor;
            if (thisNote != null)
            {
                thisNote.NoteColor = nextColor; // Update the note's color
                noteManager.Save(thisNote); // Save changes
            }
        }



        // Event handler for the Pin checkbox changed
        private void Pin_CheckedChanged(object sender, EventArgs e)
        {
            PinNote(Pin.Checked);
        }

        // Event handler for the Add button click

        private void Add_Click(object sender, EventArgs e)
        {
            CreateNewNote();
        }

        // Logic to create a new note instance and form
        private void CreateNewNote()
        {
            var newNote = new Note
            {
                Id = Guid.NewGuid().ToString(),
                Content = "",
                Position = CalculateNewNotePosition(),
                NoteColor = colorManager.GetNextColor(),
                Pinned = false
            };

            noteManager.Save(newNote); // Save the new note immediately
            var newNoteForm = new Form1(newNote);
            newNoteForm.Show();
        }

        private Point CalculateNewNotePosition()
        {
            // Logic to calculate new note position, e.g., offset from current window
            return new Point(this.Location.X + 20, this.Location.Y + 20);
        }

        private void LoadSpecificNote(Note note)
        {
            textBox1.Text = note.Content;
            this.Location = note.Position;
            ApplyNoteColor(note.NoteColor);
            PinNote(note.Pinned);
            DisplayNote(note);
        }

        private void Del_Click(object sender, EventArgs e)
        {
            if (thisNote != null)
            {
                bool isDeleted = noteManager.Delete(thisNote.Id);
                if (isDeleted)
                {
                    // If you have any other cleanup code, it should go here.
                    this.Close(); // Closes the form
                }
                else
                {
                    MessageBox.Show("Note could not be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}