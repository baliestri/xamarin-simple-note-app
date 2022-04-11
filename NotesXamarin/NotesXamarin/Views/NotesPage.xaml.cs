using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NotesXamarin.Models;
using Xamarin.Forms;

namespace NotesXamarin.Views
{
    public partial class NotesPage : ContentPage
    {
        private readonly string _filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");

        public NotesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            collectionView.ItemsSource = await App.Database.GetNotesAsync();
        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(NoteEntryPage));
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                var note = (Note)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(NoteEntryPage)}?{nameof(NoteEntryPage.ItemId)}={note.Id.ToString()}");
            }
        }
    }
}