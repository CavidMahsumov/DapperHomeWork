using DapperHomeWork.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperHomeWork.DataAccess.DapperServer
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBooksRepository booksRepository => new BookRepository();
    }
}
