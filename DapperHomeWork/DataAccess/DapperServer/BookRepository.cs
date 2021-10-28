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
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString))
            {
                connection.Open();
                connection.Execute("insert into Books(Name,Price,AuthorName)values(@BookName,@BookPrice,@BAuthorName)", new { @BAuthorName=data.AuthorName, @BookName = data.Name, @BookPrice = data.Price });
            }
        }

        public void DeleteData(int id)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString))
            {
                connection.Open();
                connection.Execute("Delete from  Books Where Id=@BId ", new {  @BId = id });
            }
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
            Books book = new Books();
            using (var connection=new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString))
            {
                connection.Open();
                book = connection.QueryFirstOrDefault<Books>("select *from Books where Id=@Bid", new { @Bid = id });
            }
            return book;
        }

        public void UpdateData(int id,Books data)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString))
            {
                connection.Open();
                connection.Execute("Update Books Set Name=@BName,Price=@BPrice,AuthorName=@BAuthorName where Id=@BId", new { @BAuthorName=data.AuthorName, @BName = data.Name, @BPrice = data.Price, @BId = id });
            }
        }
    }
}
