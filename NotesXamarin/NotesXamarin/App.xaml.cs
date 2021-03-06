using System;
using System.IO;
using NotesXamarin.Data;
using Xamarin.Forms;

namespace NotesXamarin
{
    public partial class App : Application
    {
        private static NoteDatabase database;

        public static NoteDatabase Database
        {
            get
            {
                if (database == null)
                    database = new NoteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
