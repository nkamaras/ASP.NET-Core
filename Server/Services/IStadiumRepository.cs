using DemoApp.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoApp.Server.Services
{
    public interface IStadiumRepository
    {
        Task addStadium(Stadium stadium);
        Task<List<Stadium>> getAllStadiums();
        Task<Stadium> getStadium(string id);
        Task removeStadium(string id);
        Task updateStadium(Stadium stadium);
    }
}