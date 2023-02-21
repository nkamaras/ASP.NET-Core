using System.Collections.Generic;

namespace DemoApp.Server.Services
{
    public interface IDataBaseService
    {
        void AddObject<T>(string sql, T Object);
        void DeleteObject<T>(string sql, int id);
        T FindObject<T>(string sql, int id);
        List<T> GetObjects<T>(string sql);
        void UpdateObject<T>(string sql, T Object);
    }
}