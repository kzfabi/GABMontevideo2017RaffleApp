using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GABMontevideo2017RaffleApp.Raffle
{
    public static class RaffleAdmin
    {
        public static List<RafflePlayer> Players { get; set; }

        public static bool IsOpen { get; set; }

        static RaffleAdmin()
        {
            Players = new List<RafflePlayer>();
            IsOpen = false;
        }

        public static void AddPlayer(RafflePlayer player)
        {
            if (IsOpen)
            {
                Players.Add(player);
            }
        }

        public static void SetOpen(bool isOpen)
        {
            IsOpen = isOpen;
        }
    }

    public class RafflePlayer
    {
        public string Email { get; set; }
    }
}
