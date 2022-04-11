using System;
using System.IO;

using Xamarin.Forms;

namespace NotesXamarin.Views
{
    public partial class NotesPage : ContentPage
    {
        private readonly string _filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");

        public NotesPage()
        {
            InitializeComponent();

            if (File.Exists(_filename))
                editor.Text = File.ReadAllText(_filename);
        }

        void OnSaveButtonClicked(object sender, EventArgs e)
        {
            File.WriteAllText(_filename, editor.Text);
        }

        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (File.Exists(_filename))
                File.Delete(_filename);

            editor.Text = string.Empty;
        }
    }
}