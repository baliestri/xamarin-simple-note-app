using System;
using System.IO;
using NotesXamarin.Models;
using Xamarin.Forms;

namespace NotesXamarin.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class NoteEntryPage : ContentPage
    {
        public string ItemId { set => LoadNote(value); }

        public NoteEntryPage()
        {
            InitializeComponent();
            BindingContext = new Note();
        }

        async void LoadNote(string itemId)
        {
            try
            {
                var id = Convert.ToInt32(itemId);
                var note = await App.Database.GetNoteAsync(id);

                BindingContext = note;
            }
            catch
            {
                Console.WriteLine("Failed to load note.");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            note.Date = DateTime.UtcNow;

            if (!string.IsNullOrWhiteSpace(note.Text))
                await App.Database.SaveNoteAsync(note);

            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            await App.Database.DeleteNoteAsync(note);

            await Shell.Current.GoToAsync("..");
        }
    }
}