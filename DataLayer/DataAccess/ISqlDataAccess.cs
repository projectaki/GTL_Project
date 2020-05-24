using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer.DataAccess
{
    public interface ISqlDataAccess
    {
        string GetConnectionString(string connectionName = "GTL");
        List<T> LoadData<T>(string sql);
        List<T> LoadData<T>(string sql, Dictionary<string, object> dict);
        List<T> LoadDataSp<T>(string storedProcedure, T parameters);
        int SaveData<T>(string sql, T data);
        int SaveDataSP<T>(string storedProcedure, T parameters);
        
    }
}