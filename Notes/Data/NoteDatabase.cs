using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Notes.Models;
using System;

namespace Notes.Data
{
    public class NoteDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public NoteDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Note>().Wait();
        }

        public async Task<List<Note>> GetNotesAsync()
        {
            List<Note> notesNoDetails = await _database.Table<Note>().ToListAsync();
            List<Note> notesWithDetails = new List<Note>();
            foreach(Note note in notesNoDetails)
            {
                if(note.LastUpdatedDate is null)
                {
                    //note.Detail = $"Created {note.CreateDate.ToString("g")}";
                    note.DisplayCreateDate = $"Created {note.CreateDate.ToString("g")}";
                    note.DisplayLastUpdatedDate = "";
                }
                else
                {
                    note.DisplayCreateDate = $"Created {note.CreateDate.ToString("g")}";
                    note.DisplayLastUpdatedDate = $"Updated {note.LastUpdatedDate?.ToString("g")}";
                    //note.Detail = $"Created {note.CreateDate.ToString("g")} Last Updated {note.LastUpdatedDate?.ToString("g")}";
                }
                notesWithDetails.Add(note);
            }
            return notesWithDetails;
            //return _database.Table<Note>().ToListAsync();
        }

        public Task<Note> GetNoteAsync(int id)
        {
            return _database.Table<Note>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Note note)
        {
            if(string.IsNullOrWhiteSpace(note.Title))
            {
                note.Title = "No Title";
            }

            if (note.ID != 0)
            {
                return _database.UpdateAsync(note);
            }
            else
            {
                return _database.InsertAsync(note);
            }
        }

        public Task<int> DeleteNoteAsync(Note note)
        {
            return _database.DeleteAsync(note);
        }
    }
}