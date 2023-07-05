using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerShifter.Models;

namespace WorkerShifter.Services
{
    public class WorkerServices : IStoreManageServices<WorkerModel>
    {
        SQLiteAsyncConnection _connection { get; set; }

        public WorkerServices()
        {
            Init();
        }

        public void Init()
        {
            if (_connection == null)
            {
                //string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WShifter");
                //Directory.CreateDirectory(path);
                //string dbPath = Path.Combine(path, "Global.db3");
                _connection = new SQLiteAsyncConnection(Constants.DatabasePath);
                _connection.CreateTableAsync<WorkerModel>().Wait();

                    if (_connection.Table<WorkerModel>().CountAsync().Result == 0)
                    {
                        WorkerModel defaultModel = new WorkerModel()
                        {
                            name = "Default",
                            password = "Password",
                            position = 1,
                            bossId = 0,
                            deafultStore = 0
                        };
                        _connection.InsertAsync(defaultModel);
                    }

            }

        }

        public async Task<int> Create(WorkerModel model)
        {
           return await _connection.InsertAsync(model);
        }

        public async Task<int> Delete(int id)
        {
            List<WorkerModel> model = await _connection.Table<WorkerModel>().Where(x=> x.id == id).ToListAsync();

            return await _connection.DeleteAsync(model[0]);
        }

        public async Task<List<WorkerModel>> GetAll()
        {
            return await _connection.Table<WorkerModel>().ToListAsync();
        }

        public async Task<WorkerModel> GetOneById(int id)
        {
            List<WorkerModel> model = await _connection.Table<WorkerModel>().Where(x => x.id == id).ToListAsync();

            return model[0];
        }

        public async Task<int> Update(WorkerModel model)
        {
            return await _connection.UpdateAsync(model);
        }
    }
}
