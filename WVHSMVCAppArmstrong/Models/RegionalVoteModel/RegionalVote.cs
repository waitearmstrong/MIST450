using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WVHSMVCAppArmstrong.Models
{
    public class RegionalVote
    {
        [Key] public int RegionalVoteID { get; set; }
        [Required] public string Classification { get; set; }

        [Required]
        public int region { get; set; }

        [Required] 
        public string Gender { get; set; }
        [Required]
        public DateTime DateTimeVoted { get; set; }

        public string coachID { get; set; }

        [ForeignKey("coachID")] 
        public Coach coach;

        public int playerID { get; set; }
        [ForeignKey("playerID")]
        public Player player { get; set; }
       
        public RegionalVote()
        { }

        public RegionalVote(int region, string classification, string gender,int playerId,string coachId)
        {
            this.region = region;
            this.Classification = classification;
            this.Gender = gender;
            this.DateTimeVoted = System.DateTime.Now;
            this.playerID = playerID;
            this.coachID = coachID;

        }
    }
}
