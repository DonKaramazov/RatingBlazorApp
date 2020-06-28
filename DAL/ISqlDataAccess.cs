using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public interface ISqlDataAccess
    {
        Task<List<T>> SelectMany<T, U>(string query, U parameters);
        //Task SaveData<T>(string query, T parameters);

        Task<T> SaveData<T,U>(string query, U parameters);

        Task Delete(string query);
    }
}