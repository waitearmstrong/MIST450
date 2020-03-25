 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 using Microsoft.AspNetCore.Identity;

 namespace WVHSMVCAppArmstrong.Models
{
    public class ApplicationUser : IdentityUser
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public String FullName => FirstName + " " + LastName;

        public ApplicationUser()
        {
        }

        public ApplicationUser(string firstName, string lastName, string email, string phoneNumber, string password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.UserName = email;
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            this.PasswordHash = passwordHasher.HashPassword(this, password);

            this.SecurityStamp = Guid.NewGuid().ToString();
        }
    }
}
