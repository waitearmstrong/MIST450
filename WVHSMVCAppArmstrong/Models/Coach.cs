using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WVHSMVCAppArmstrong.Models
{
    public class Coach: ApplicationUser
    {

        public int TeamID { get; set; }
        [ForeignKey("TeamID")]
        public Team Team { get; set; }
        
        public Coach()
        { }
        public Coach(string firstName, string lastName, string email, string phoneNumber, string password,int teamid) 
            : base(firstName, lastName, email, phoneNumber, password)
        {
            this.TeamID = teamid;
        }
    }
}
