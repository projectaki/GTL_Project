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
    public class SqlDataAccess : ISqlDataAccess
    {
        public string GetConnectionString(string connectionName = "GTL")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public List<T> LoadData<T>(string sql, Dictionary<string, object> dict)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                var param = new DynamicParameters(dict);
                return cnn.Query<T>(sql, param).ToList();
            }
        }

        public List<T> LoadDataSp<T>(string storedProcedure, T parameters)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {

                List<T> rows = cnn.Query<T>(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure).ToList();

                return rows;
            }
        }

        public int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }

        public int SaveDataSP<T>(string storedProcedure, T parameters)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }


    }
}
