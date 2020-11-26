using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TexasRangers.Model;

namespace TexasRangers.Data
{
    public class Reservations_db
    {
        readonly SQLiteAsyncConnection _database;

        public Reservations_db(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Reservations>().Wait();
        }

        public Task<List<Reservations>> GetNotesAsync()
        {
            return _database.Table<Reservations>().ToListAsync();
        }

        public Task<Reservations> GetNoteAsync(int id)
        {
            return _database.Table<Reservations>()
                            .Where(i => i.id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveReservationAsync(Reservations note)
        {
            if (note.id != 0)
            {
                return _database.UpdateAsync(note);
            }
            else
            {
                return _database.InsertAsync(note);
            }
        }

        public Task<int> DeleteReservationAsync(Reservations note)
        {
            return _database.DeleteAsync(note);
        }
    }
}
