using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WVHSMVCAppArmstrong.Data;

namespace WVHSMVCAppArmstrong.Models
{
    public class TeamPlayerRepo : ITeamPlayerRepo
    {
        private ApplicationDbContext database;

        public TeamPlayerRepo(ApplicationDbContext dbContext)
        {
            database = dbContext;
        }

        public Task AddTeamPlayer(DateTime startDate, int playerID, int teamID)
        {
            TeamPlayer teamPlayer = new TeamPlayer(startDate,playerID,teamID);
            database.AddAsync(teamPlayer);
            return database.SaveChangesAsync();
        }

    }
}
