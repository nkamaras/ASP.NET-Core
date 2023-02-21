using DemoApp.Server.Services;
using DemoApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Server.Repositories
{
    public class StadiumRepository : IStadiumRepository
    {
        private IDataBaseService _databaseService;

        public StadiumRepository(IDataBaseService dataBaseService)
        {
            _databaseService = dataBaseService;
        }

        public async Task<Stadium> getStadium(string id)
        {
            var sql = @"SELECT * FROM Stadium WHERE StadiumId=@Id";
            return _databaseService.FindObject<Stadium>(sql, Convert.ToInt32(id));
        }

        public async Task<List<Stadium>> getAllStadiums()
        {
            var sql = @"SELECT * FROM Stadium";
            return _databaseService.GetObjects<Stadium>(sql);
        }

        public async Task addStadium(Stadium stadium)
        {
            var sql = @"INSERT INTO Stadium(Name, City,Address, PostalCode) VALUES(@Name, @City, @Address, @PostalCode)";
            _databaseService.AddObject<Stadium>(sql, stadium);
        }

        public async Task removeStadium(string id)
        {
            var sql = @"DELETE FROM Stadium WHERE StadiumId=@Id";
            _databaseService.DeleteObject<Stadium>(sql, Convert.ToInt32(id));
        }

        public async Task updateStadium(Stadium stadium)
        {


            var sql = @"UPDATE Stadium 
                       SET Name=@Name, City=@City, Address=@Address, PostalCode=@PostalCode
                       WHERE StadiumId=@StadiumId";

            _databaseService.UpdateObject<Stadium>(sql, stadium);

        }

    }
}
