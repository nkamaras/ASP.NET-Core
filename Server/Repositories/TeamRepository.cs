using DemoApp.Server.Services;
using DemoApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Server.Repositories
{
    public class TeamRepository : ITeamRepository
    {

        private IDataBaseService _databaseService;

        public TeamRepository(IDataBaseService dataBaseService)
        {
            _databaseService = dataBaseService;
        }

        public async Task<Team> getTeam(string id)
        {
            var sql = @"SELECT * FROM Team WHERE TeamId=@Id";
            return _databaseService.FindObject<Team>(sql, Convert.ToInt32(id));
        }

        public async Task<List<Team>> getAllTeams()
        {
            var sql = @"SELECT * FROM Team";
            return _databaseService.GetObjects<Team>(sql);
        }

        public async Task addTeam(Team team)
        {
            var sql = @"INSERT INTO Team(TeamName) VALUES(@TeamName)";
            _databaseService.AddObject<Team>(sql, team);
        }

        public async Task removeTeam(string id)
        {
            var sql = @"DELETE FROM Team WHERE TeamId=@Id";
            _databaseService.DeleteObject<Stadium>(sql, Convert.ToInt32(id));
        }

        public async Task updateTeam(Team team)
        {


            var sql = @"UPDATE Team 
                       SET TeamName=@TeamName
                       WHERE TeamId=@TeamId";

            _databaseService.UpdateObject<Team>(sql, team);

        }
    }
}
