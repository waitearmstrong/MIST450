using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WVHSMVCAppArmstrong.Models
{
    public class School
    {
        [Key]
        public int SchoolID { get; set; }
        [Required]
        public String SchoolName { get; set; }
        [Required]
        public string SchoolAddress { get; set; }
        [Required]
        public string SchoolClassification { get; set; }
        [Required]
        public int SchoolRegion { get; set; }

        public List<Team> Teams { get; set; }

        public School()
        {

        }
        public School(string schoolName, string schoolAddress, string schoolClassification, int schoolRegion)
        {
            this.SchoolName = schoolName;
            this.SchoolAddress = schoolAddress;
            this.SchoolClassification = schoolClassification;
            this.SchoolRegion = schoolRegion;
            this.Teams = new List<Team>();
        }
    }
}
