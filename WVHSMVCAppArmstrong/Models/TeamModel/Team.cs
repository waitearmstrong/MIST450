using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WVHSMVCAppArmstrong.Models
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        [Required]
        public String Gender { get; set; }
        public string Name { get; set; }

        //Relational Connection
        
        public int SchoolID { get; set; }
        //OOP Connection
        [ForeignKey("SchoolID")]
        public School School { get; set; }


        public string CoachID { get; set; }

        [ForeignKey("CoachID")]
        public Coach Coach { get; set; }


        public List<TeamPlayer> TeamPlayers { get; set; }
        public Team()
        {

        }

        public Team(string gender, string name)
        {
            this.Gender = gender;
            this.Name = name;
            this.TeamPlayers = new List<TeamPlayer>();
        }
        public Team(String gender,String name,int schoolID)
        {
            this.Gender = gender;
            this.Name = name;
            this.SchoolID = schoolID;
            this.TeamPlayers = new List<TeamPlayer>();
            
        }

    }
}
