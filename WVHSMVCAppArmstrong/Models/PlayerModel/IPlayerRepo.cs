using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WVHSMVCAppArmstrong.ViewModels;

namespace WVHSMVCAppArmstrong.Models
{
    public interface IPlayerRepo
    {
        //Promises what will be done
        List<Player> ListAllPlayers();

         Task AddPlayerAsync(Player player);

         Player FindPlayer(int playerID);

         Task EditPlayerAsync(Player player);

         Task DeletePlayerAsync(Player player);
    }
}
