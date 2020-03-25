using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WVHSMVCAppArmstrong.Data;

namespace WVHSMVCAppArmstrong.Models.RegionalVoteModel
{
    public class RegionalVoteRepo : IRegionalVoteRepo
    {
        private ApplicationDbContext database;

        public RegionalVoteRepo(ApplicationDbContext database)
        {
            this.database = database;
        }

        public bool CheckIfCoachHasVotedForCertainPosition(string coachID, int playerID)
        {
            Player play = database.Players.Find(playerID);
            string position = play.Position;
            return database.RegionalVotes.Where(r => r.coachID == coachID && r.player.Position == position).Any();

        }

        public List<RegionalVote> ListAllRegionalVotes()
        {
            return database.RegionalVotes
                .Include(r => r.coach)
                .Include(r => r.player)
                .ToList<RegionalVote>();
        }

        public Task VoteForPlayerAsync(RegionalVote regionalVote)
        {
            database.RegionalVotes.AddAsync(regionalVote);
            return database.SaveChangesAsync();
        }
    }
}
