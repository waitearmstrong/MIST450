using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WVHSMVCAppArmstrong.Models.RegionalVoteModel
{
    public interface IRegionalVoteRepo
    {
         Task VoteForPlayerAsync(RegionalVote regionalVote);

         bool CheckIfCoachHasVotedForCertainPosition(string coachID, int playerID);

         List<RegionalVote> ListAllRegionalVotes();
    }
}
