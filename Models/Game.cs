using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Shared.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string GameDescription { get; set; }
        public int TeamAId { get; set; }
        public int TeamBId { get; set; }
        public string GameHour { get; set; }
        public int attendees { get; set; }
        public int StadiumId { get; set; }
        public virtual Stadium Stadium { get; set; }
    }
}
