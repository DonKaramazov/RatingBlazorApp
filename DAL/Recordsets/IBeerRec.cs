using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Recordsets
{
    public interface IBeerRec
    {
        Task InsertBeer(BeerModel beer);
        Task<List<BeerModel>> SelectAll();

        Task<int> InsertBeer2(BeerModel beer);
    }
}