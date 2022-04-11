using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NotesXamarin.Models;
using SQLite;

namespace NotesXamarin.Data
{
    public class NoteDatabase
    {
        private readonly SQLiteAsyncConnection database;

        public NoteDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Note>().Wait();
        }

        public Task<List<Note>> GetNotesAsync()
            => database.Table<Note>().ToListAsync();

        public Task<Note> GetNoteAsync(int id)
            => database.Table<Note>()
                       .Where(x => x.Id == id)
                       .FirstOrDefaultAsync();

        public Task<int> SaveNoteAsync(Note note)
        {
            if (note.Id != 0)
                return database.UpdateAsync(note);

            return database.InsertAsync(note);
        }

        public Task<int> DeleteNoteAsync(Note note)
            => database.DeleteAsync(note);
    }
}
