using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace DataLayer.DataAccess
{
    public static class SqlDataAccess
    {
        public static string GetConnectionString(string connectionName ="GTL")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static List<T> LoadData<T>(string sql,Dictionary<string, object> dict)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                var param = new DynamicParameters(dict);
                return cnn.Query<T>(sql, param).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }

        
    }
}
