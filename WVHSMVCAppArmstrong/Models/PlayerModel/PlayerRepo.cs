using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WVHSMVCAppArmstrong.Data;

namespace WVHSMVCAppArmstrong.Models
{
    public class PlayerRepo : IPlayerRepo
    {
        private ApplicationDbContext database;

        public PlayerRepo(ApplicationDbContext dbContext)
        {
            database = dbContext;
        }

        public Task AddPlayerAsync(Player player)
        {
            database.Players.AddAsync(player);
            return database.SaveChangesAsync();
        }

        public Task DeletePlayerAsync(Player player)
        {
            database.Players.Remove(player);
            return database.SaveChangesAsync();
        }

        public Task EditPlayerAsync(Player player)
        {
            database.Players.Update(player);
            return database.SaveChangesAsync();
        }

        public Player FindPlayer(int playerID)
        {
            return database.Players.Find(playerID);
        }


        public List<Player> ListAllPlayers()
        {
            
                List<Player> playerList = database.Players
                    .Include(player => player.TeamPlayers)
                    .ThenInclude(teamplayer => teamplayer.team)
                    .ThenInclude(teamplayer => teamplayer.School)
                    .ToList<Player>();
                return playerList;
        }




    }
}
