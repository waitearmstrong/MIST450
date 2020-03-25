using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WVHSMVCAppArmstrong.Models
{
    public interface ITeamRepo
    {
        Team FindTeam(int schoolID, string gender);

         int FindTeamIDByCoach(string CoachID);

         Team FindTeamUsingCoach(String coachID);
    }
}
