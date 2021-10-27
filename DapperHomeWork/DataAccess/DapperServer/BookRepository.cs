using Dapper;
using DapperHomeWork.Domain.Abstraction;
using DapperHomeWork.Domain.Entities;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperHomeWork.DataAccess.DapperServer
{
    public class BookRepository : IBooksRepository
    {
        public void AddData(Books data)
        {
            throw new NotImplementedException();
        }

        public void DeleteData(Books data)
        {
            throw new NotImplementedException();
        }

        public List<Books> GetAllData()
        {
            List<Books> products = new List<Books>();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString))
            {
                connection.Open();
                products = connection.Query<Books>("select*from Books").ToList();
            }
            return products;
        }

        public Books GetData(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(Books data)
        {
            throw new NotImplementedException();
        }
    }
}
