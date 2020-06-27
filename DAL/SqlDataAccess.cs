using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public string ConnectionStringName { get; set; } = "Default";

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> SelectMany<T,U>(string query, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(query, parameters);

                return data.ToList();
            }
        }

        //public async Task SaveData<T>(string query, T parameters)
        //{
        //    string connectionString = _config.GetConnectionString(ConnectionStringName);

        //    using (IDbConnection connection = new SqlConnection(connectionString))
        //    {
        //        await connection.ExecuteAsync(query, parameters);

        //        //await connection.ExecuteScalarAsync<int>(query, parameters);
        //    }
        //}

        //public async Task<int> SaveData<T>(string query, T parameters)
        //{
        //    string connectionString = _config.GetConnectionString(ConnectionStringName);

        //    using (IDbConnection connection = new SqlConnection(connectionString))
        //    {
        //        var id = await connection.QuerySingleAsync<int>(query, parameters);

        //        return int.Parse(id.ToString());
        //    }
        //}

        public async Task<T> SaveData<T,U>(string query, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var result = await connection.QuerySingleAsync<T>(query, parameters);

                return result;
            }
        }
    }
}
