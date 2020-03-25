using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WVHSMVCAppArmstrong.Models
{
    public class TeamPlayer
    {
        [Key]
        public int TeamPlayerID { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Required]
        public int PlayerID { get; set; } //Creating Foreign Key Link
        [ForeignKey("PlayerID")]  // Linking new object to foreign key. This gives entity framework the keys it needs to create our database
        public Player Player { get; set; } // Creating Object Oriented Link

      
        public int TeamID { get; set; }
        [ForeignKey("TeamID")]
        public Team team { get; set; }

        public TeamPlayer(DateTime startDate, int playerId,int teamId )
        {
            this.StartDate = startDate;
            this.EndDate = null;
            this.PlayerID = playerId;
            this.TeamID = teamId;
        }

        public TeamPlayer() { }
    }
}
