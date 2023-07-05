using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerShifter.Models;
using System.Configuration;

namespace WorkerShifter.Services
{
    public class PositionService : IStoreManageServices<PositionModel>
    {
        SQLiteAsyncConnection _connection { get; set; }

        public async void Init()
        {
            // string helperPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "WShifter");
            //string dbPath = Path.Combine(helperPath, "Global.db3");
            if (!(Path.Exists(Constants.DatabasePath)))
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WShifter"));
            }

            _connection = new SQLiteAsyncConnection(Constants.DatabasePath);
            _connection.CreateTableAsync<PositionModel>().Wait();
            if (_connection.Table<PositionModel>().CountAsync().Result == 0)
            {
                _connection.InsertAsync(new PositionModel() { Id =1 , Position = "Boss", IsBoss = true });
                _connection.InsertAsync(new PositionModel() { Id =2 , Position = "Cashier", IsBoss = false});
            }
        }

        public PositionService() 
        {
            Init();
        }

        public async Task<int> Create(PositionModel model)
        {
            return  await _connection.InsertAsync(model);
        }

        public async Task<int> Delete(int id)
        {
            List<PositionModel> helperList = await _connection.Table<PositionModel>().Where(x=> x.Id == id).ToListAsync();

            return await _connection.DeleteAsync(helperList[0]);
        }

        public async Task<List<PositionModel>> GetAll()
        {
            return await _connection.Table<PositionModel>().ToListAsync();
        }

        public async Task<PositionModel> GetOneById(int id)
        {
            List<PositionModel> helperList = await _connection.Table<PositionModel>().Where(x=> x.Id == id).ToListAsync();
            if (helperList.Count == 1)
            {
                return helperList[0];
            }
            
            PositionModel noExistPosition = new PositionModel() { Id = 0, IsBoss = false, Position="Brak"};

            return noExistPosition;
        }

        public async Task<int> Update(PositionModel model)
        {
            return await _connection.UpdateAsync(model);
        }
    }
}
