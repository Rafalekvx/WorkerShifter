using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerShifter.Models;

namespace WorkerShifter.Services
{
    public interface IStoreManageServices<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetOneById(int id);
        Task<int> Create(T model);
        Task<int> Update(T model);
        Task<int> Delete(int id);
    }
}
