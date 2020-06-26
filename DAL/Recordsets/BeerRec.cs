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

        public Task InsertBeer(BeerModel beer)
        {
            string query = @"insert into dbo.BEER (name, description, color, style, abv)
                             values (@name, @description, @color, @style, @abv)";

            return _db.SaveData(query, beer);
        }

        public Task<int> InsertBeer2(BeerModel beer)
        {
            string query = @"insert into dbo.BEER (name, description, color, style, abv)
                             values (@name, @description, @color, @style, @abv);
                             select cast(scope_identity() as int)";

            return _db.SaveData2(query, beer);
        }
    }
}
