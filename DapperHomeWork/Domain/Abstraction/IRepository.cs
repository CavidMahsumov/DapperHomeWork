using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperHomeWork.Domain.Abstraction
{
    public interface IRepository<T>
    {
        T GetData(int id);
        List<T> GetAllData();
        void AddData(T data);
        void UpdateData(int Id,T data);
        void DeleteData(int id);
    }
}
