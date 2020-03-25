using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WVHSMVCAppArmstrong.Models;

namespace WVHSMVCAppArmstrong.ViewModels
{
    public class SearchPlayersViewModel
    {
        //Properties for search input (All optional
        public int? SchoolID { get; set; }
        public string Gender { get; set; }
        public string Position { get; set; }
        public string Division { get; set; }
        [DataType(DataType.Date)]
        public DateTime? SearchStartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? SearchEndDate { get; set; }

        //search result
        public List<Player> PlayerList { get; set; }
       
    }
}
