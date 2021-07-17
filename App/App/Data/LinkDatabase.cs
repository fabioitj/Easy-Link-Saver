using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using App.Models;

namespace App.Data
{
    public class LinkDatabase
    {
        readonly SQLiteAsyncConnection database;

        public LinkDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<LinksModel>().Wait();
        }

        public Task<List<LinksModel>> GetLinksAsync()
        {
            //Get all links.
            return database.Table<LinksModel>().ToListAsync();
        }

        public Task<LinksModel> GetLinkAsync(int id)
        {
            // Get a specific link.
            return database.Table<LinksModel>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveLinkAsync(LinksModel link)
        {
            if (link.ID != 0)
            {
                // Update an existing link.
                return database.UpdateAsync(link);
            }
            else
            {
                // Save a new link.
                return database.InsertAsync(link);
            }
        }

        public Task<int> DeleteLinkAsync(LinksModel link)
        {
            // Delete a link.
            return database.DeleteAsync(link);
        }
    }
}