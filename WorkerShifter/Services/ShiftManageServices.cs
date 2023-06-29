using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerShifter.Models;

namespace WorkerShifter.Services
{
    class ShiftManageServices : IStoreManageServices<ShiftModel>
    {
        SQLiteAsyncConnection _connection { get; set; }

        public async void Init()
        {
            // string helperPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "WShifter");
            //string dbPath = Path.Combine(helperPath, "Global.db3");
            _connection = new SQLiteAsyncConnection(Constants.DatabasePath);
            _connection.CreateTableAsync<ShiftModel>().Wait();
            if (_connection.Table<ShiftModel>().CountAsync().Result == 0)
            {
                _connection.InsertAsync(new ShiftModel() {Id=1, date = DateTime.Parse("2001-10-04T00:00"), startTime=DateTime.Parse("2001-10-04T00:00"), endTime = DateTime.Parse("2001-10-05T00:00"), storeId=1, personId=1});
            }
        }

        public ShiftManageServices()
        {
            Init();
        }

        public async Task<int> Create(ShiftModel model)
        {
            return await _connection.InsertAsync(model);
        }

        public async Task<int> Delete(int id)
        {
            List<ShiftModel> helperList = await _connection.Table<ShiftModel>().Where(x => x.Id == id).ToListAsync();

            return await _connection.DeleteAsync(helperList[0]);
        }

        public async Task<List<ShiftModel>> GetAll()
        {
            return await _connection.Table<ShiftModel>().ToListAsync();
        }

        public async Task<ShiftModel> GetOneById(int id)
        {
            List<ShiftModel> helperList = await _connection.Table<ShiftModel>().Where(x => x.Id == id).ToListAsync();
            if (helperList.Count == 1)
            {
                return helperList[0];
            }

            ShiftModel NoExistShift = new ShiftModel() { Id = 1, date = DateTime.Parse("2001-10-0400:00"), startTime = DateTime.Parse("2001-10-0400:00"), endTime = DateTime.Parse("2001-10-0500:00"), storeId = 1, personId = 1 };

            return NoExistShift;
        }

        public async Task<int> Update(ShiftModel model)
        {
            return await _connection.UpdateAsync(model);
        }
    }
}
