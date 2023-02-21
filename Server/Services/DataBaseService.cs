using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Server.Services
{

    public class DataBaseService : IDataBaseService
    {

        private IConfiguration _configuration { get; set; }
        private string ConnectionString { get; }
        private IDbConnection db;

        public DataBaseService(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            this.db = new SqlConnection(ConnectionString);
        }

        public void AddObject<T>(string sql, T Object)
        {
            db.Execute(sql, Object, commandType: CommandType.Text);
        }

        public List<T> GetObjects<T>(string sql)
        {
            return db.Query<T>(sql).ToList();
        }

        public T FindObject<T>(string sql, int id)
        {
            return db.Query<T>(sql, new { @Id = id }).Single();
        }

        public void UpdateObject<T>(string sql, T Object)
        {
            db.Execute(sql, Object, commandType: CommandType.Text);
        }

        public void DeleteObject<T>(string sql, int id)
        {
            db.Execute(sql, new { id }, commandType: CommandType.Text);
        }


    }
}
