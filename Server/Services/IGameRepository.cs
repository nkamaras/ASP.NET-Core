using DemoApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Server.Services
{
    public interface IGameRepository
    {
        Task addGame(Game game);
        Task<List<Game>> getAllGames();
        Task<Game> getGame(string id);
        Task removeGame(string id);
        Task updateGame(Game game);
    }
}
