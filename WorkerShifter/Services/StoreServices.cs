using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerShifter.Models;

namespace WorkerShifter.Services
{
    public class StoreServices : IStoreManageServices<StoreModel>
    {
        SQLiteAsyncConnection _connection {get;set;}

        public StoreServices()
        {
            Init();
        }

        public void Init()
        {
            if (_connection == null)
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WShifter");
                string dbPath = Path.Combine(path, "Global2.db3");
                _connection = new SQLiteAsyncConnection(dbPath);
                _connection.CreateTableAsync<StoreModel>();

                if (_connection.Table<StoreModel>().CountAsync().Result == 0)
                {
                    StoreModel defaultModel = new StoreModel()
                    {
                        name = "Default",
                        address = "Default",
                    };
                    _connection.InsertAsync(defaultModel);
                }
            }

        }

        public async Task<int> Create(StoreModel model)
        {
           return await _connection.InsertAsync(model);
        }

        public async Task<int> Delete(int id)
        {
            var oldItem = await _connection.GetAsync<StoreModel>(id);

            return await _connection.DeleteAsync(oldItem);
        }

        public async Task<List<StoreModel>> GetAll()
        {
            List<StoreModel> storeModels = await _connection.Table<StoreModel>().ToListAsync();

            return storeModels;
        }

        public async Task<StoreModel> GetOneById(int id)
        {
            List<StoreModel> storeModels = await _connection.Table<StoreModel>().Where(x=> x.id == id).ToListAsync();

            return storeModels[0];
        }

        public async Task<int> Update(StoreModel model)
        {
            return await _connection.UpdateAsync(model);
        }
    }
}
