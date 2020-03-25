using System; 
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WVHSMVCAppArmstrong.Models
{
    public class Player
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }

        public String FullName => FirstName + " " + LastName;
        [Required]
        public string Position { get; set; }

        public List<TeamPlayer> TeamPlayers { get; set; }

        public Player()
        {
        }

        public Player(string firstName, string lastName, string position)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Position = position;
            this.TeamPlayers = new List<TeamPlayer>();
        }
    }
}
