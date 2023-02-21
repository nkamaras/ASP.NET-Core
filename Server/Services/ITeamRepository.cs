using DemoApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Server.Services
{
    public interface ITeamRepository
    {
        Task addTeam(Team team);
        Task<List<Team>> getAllTeams();
        Task<Team> getTeam(string id);
        Task removeTeam(string id);
        Task updateTeam(Team team);
    }
}
