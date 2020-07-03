using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Recordsets
{
    public class BeerRec : IBeerRec
    {
        private readonly ISqlDataAccess _db;

        public BeerRec(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<BeerModel>> SelectAll()
        {
            string query = "select * from dbo.BEER"; // pas opti mais tmp

            return _db.SelectMany<BeerModel, dynamic>(query, new { });
        }

        public Task<int> InsertBeer(BeerModel beer)
        {
            string query = @"insert into dbo.BEER (name, description, color, style, abv)
                             values (@name, @description, @color, @style, @abv);
                             select cast(scope_identity() as int)";

            return _db.SaveData<int,BeerModel>(query, beer);
        }

        public Task DeleteBeer(int idBee)
        {
            string query = $"delete from dbo.BEER where idbee = '{idBee}' ";

            return _db.Delete(query);
        }

        public Task<BeerModel> ReadById(int idBee)
        {
            string query = "select * from dbo.BEER where Idbee = @IdBee";

            return _db.SelectOne<BeerModel, dynamic>(query, new { IdBee = idBee });
        }
    }
}
