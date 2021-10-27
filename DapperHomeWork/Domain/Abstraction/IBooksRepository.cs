using DapperHomeWork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperHomeWork.Domain.Abstraction
{
    public interface IBooksRepository:IRepository<Books>
    {
    }
}
