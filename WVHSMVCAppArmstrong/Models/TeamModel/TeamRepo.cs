using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WVHSMVCAppArmstrong.Data;

namespace WVHSMVCAppArmstrong.Models
{
    public class TeamRepo : ITeamRepo
    {
        private ApplicationDbContext database;

        public TeamRepo(ApplicationDbContext dbContext)
        {
            database = dbContext;
        }

        public Team FindTeam(int schoolID, string gender)
        {
            Team team = database.Teams.Where(t => t.SchoolID == schoolID && t.Gender == gender)
                .FirstOrDefault();
            return team;
        }

        public int FindTeamIDByCoach(string coachID)
        {
            return database.Coaches.Find(coachID).Team.TeamID;
        }

        public Team FindTeamUsingCoach(string coachID)
        {
            int teamID = FindTeamIDByCoach(coachID);
            Team team = database.Teams.Include(t => t.School)
                .Where(t => t.TeamID == teamID).FirstOrDefault();
            return team;
        }
    }
}
