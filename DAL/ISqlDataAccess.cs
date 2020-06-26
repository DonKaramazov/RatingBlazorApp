using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public interface ISqlDataAccess
    {
        Task<List<T>> SelectMany<T, U>(string query, U parameters);
        Task SaveData<T>(string query, T parameters);

        Task<int> SaveData2<T>(string query, T parameters);
    }
}