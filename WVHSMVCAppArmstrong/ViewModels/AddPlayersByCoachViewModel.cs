using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WVHSMVCAppArmstrong.ViewModels
{
    public class AddPlayersByCoachViewModel
    {
        [Required(ErrorMessage = "Need to enter first name")]
        [StringLength(maximumLength:50,MinimumLength = 1,ErrorMessage = "Must be between 1 and 50 characters")]
        public String FirstName { get; set; }
        [Required(ErrorMessage = "Need to enter Last name")]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 characters")]
        public String LastName { get; set; }
        [Required]
        public string Position { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime startDate { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime endDate { get; set; }
    }
}
