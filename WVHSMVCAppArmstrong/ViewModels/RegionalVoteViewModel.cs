using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WVHSMVCAppArmstrong.Models;

namespace WVHSMVCAppArmstrong.ViewModels
{
    public class RegionalVoteViewModel
    {


        [Required] public string Position { get; set; }
        [Required] public int SchoolID { get; set; }

        public List<Player> playerList { get; set; }
    }
}