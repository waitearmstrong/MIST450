using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WVHSMVCAppArmstrong.Models
{
    public interface ITeamPlayerRepo
    {
        Task AddTeamPlayer(DateTime startDate, int playerID, int teamID);

    }
}
