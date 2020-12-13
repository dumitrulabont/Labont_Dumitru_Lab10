using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Labont_Dumitru_Lab10.Models;

namespace Labont_Dumitru_Lab10.Data
{
    public class ShopingListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ShopingListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ShopList>().Wait();
        }
        public Task<List<ShopList>> GetShopListAsync()
        {
            return _database.Table<ShopList>().ToListAsync();
        }
        public Task<ShopList> GetShopAsync(int id)
        {
            return _database.Table<ShopList>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }
        public Task<int> SaveShopListAstnc(ShopList slist)
        {
            if(slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteShopListAsync(ShopList slist)
        {
            return _database.DeleteAsync(slist);
        }
    }
}
