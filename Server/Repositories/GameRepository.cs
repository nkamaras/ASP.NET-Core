using DemoApp.Server.Services;
using DemoApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Server.Repositories
{
    public class GameRepository : IGameRepository
    {

        private IDataBaseService _dataBaseService;

        public GameRepository(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<List<Game>> getAllGames()
        {

            string sql = @"SELECT * FROM Game";

            return _dataBaseService.GetObjects<Game>(sql).ToList();
        }

        public async Task<Game> getGame(string id)
        {

            string sql = @"SELECT * FROM Game WHERE GameId=@Id";

            return _dataBaseService.FindObject<Game>(sql, Convert.ToInt32(id));
        }

        public async Task removeGame(string id)
        {

            var sql = @"DELETE FROM Game WHERE GameId=@Id";
            _dataBaseService.DeleteObject<Stadium>(sql, Convert.ToInt32(id));
        }

        public async Task addGame(Game game)
        {

            var sql = @"INSERT INTO Game (GameDescription, TeamAId, TeamBId, GameHour, attendees, StadiumId)
                       VALUES(@GameDescription, @TeamAId, @TeamBId, @GameHour,@attendees,@StadiumId)";

            _dataBaseService.AddObject<Game>(sql, game);

        }

        public async Task updateGame(Game game)
        {

            string sql = @"UPDATE 
                          Game SET GameDescription = @GameDescription, TeamAId = @TeamAId, TeamBId = @TeamBId, GameHour = @GameHour, StadiumId = @StadiumId 
                          WHERE GameId=@GameId";


            _dataBaseService.UpdateObject<Game>(sql, game);

        }




    }
}
