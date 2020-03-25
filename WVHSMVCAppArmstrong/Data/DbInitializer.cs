using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using WVHSMVCAppArmstrong.Models;

namespace WVHSMVCAppArmstrong.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(IServiceProvider services)
        {
            ApplicationDbContext database = services.GetRequiredService<ApplicationDbContext>();

            UserManager<ApplicationUser> userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            RoleManager<IdentityRole> roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            string roleCoach = "Coach";
            string roleAdministrator = "Administrator";

            if (!database.Roles.Any())
            {
                IdentityRole role = new IdentityRole(roleCoach);
                await roleManager.CreateAsync(role);
                IdentityRole roleOne =  new IdentityRole(roleAdministrator);
                await roleManager.CreateAsync(roleOne);
            }
            

            if (!database.Coaches.Any())
            {
                
                ApplicationUser appUser = new ApplicationUser("Test", "Administrator", "Test.Administrator@WVU.EDU", "304.000.0001", "test.administrator1");
                await userManager.CreateAsync(appUser);
                await userManager.AddToRoleAsync(appUser, roleAdministrator);
                
                
                ApplicationUser appUserTwo = new ApplicationUser("Test", "Coach", "TEST.COACH1@WVU.EDU", "304.000.0003", "Test.Coach1");
                await userManager.CreateAsync(appUserTwo);
                await userManager.AddToRoleAsync(appUserTwo, roleCoach);

                ApplicationUser appUserThree = new ApplicationUser("TestTwo", "Coach", "TEST.COACH2@WVU.EDU", "304.000.0004", "Test.Coach2");
                await userManager.CreateAsync(appUserThree);
                await userManager.AddToRoleAsync(appUserThree, roleCoach);
                

                
            }


            if (!database.Schools.Any())
            {
                School schoolOne = new School("Morgantown High School", "1 High St", "AAA", 1);
                database.Schools.Add(schoolOne);
                database.SaveChanges();

                schoolOne = new School("Braxton County High School", "200 Jerry Burton Dr", "AA", 2);
                database.Schools.Add(schoolOne);
                database.SaveChanges();

                /*
                schoolOne = new School("Oak Hill High School", "350 W Oyler Ave", "AA", 3);
                database.Schools.Add(schoolOne);
                schoolOne = new School("Winfield High School", "3022 Winfield Rd", "AA", 4);
                database.Schools.Add(schoolOne);
                schoolOne = new School("Elkins High School", "100 Kennedy Drive", "AA", 2);
                database.Schools.Add(schoolOne);
                schoolOne = new School("Hurricane High School", "3350 Teays Valley Road", "AAA", 4);
                database.Schools.Add(schoolOne);
                schoolOne = new School("Buckhannon Upshur High School", "270 B-U Dr.", "AAA", 1);
                database.Schools.Add(schoolOne);
                schoolOne = new School("Lewis County High SChool", "205 Minuteman Drive", "AA", 2);
                database.Schools.Add(schoolOne);
                schoolOne = new School("Webster County High", "One Highlander Drive", "A", 3);
                database.Schools.Add(schoolOne);
                schoolOne = new School("Tug Valley High School", "555 Panther Avenue", "A", 4);
                database.Schools.Add(schoolOne);
                */

                database.SaveChanges();
            }

            if (!database.Players.Any())
            {
                Player playerOne = new Player("Waite", "Armstrong", "F");
                //playerOne.ID = 1;
                database.Players.Add(playerOne);
                database.SaveChanges();
                
                playerOne = new Player("Shaun", "Armstrong", "M");
                //playerOne.ID = 2;
                database.Players.Add(playerOne);
                database.SaveChanges();

                playerOne = new Player("Sean", "Armentrout", "G");
                //playerOne.ID = 3;
                database.Players.Add(playerOne);
                database.SaveChanges();

                playerOne = new Player("Don", "Aldeen", "M");
                //playerOne.ID = 4;
                database.Players.Add(playerOne);
                database.SaveChanges();

                playerOne = new Player("Ron", "Dobb", "D");
                //playerOne.ID = 5;
                database.Players.Add(playerOne);
                database.SaveChanges();

                playerOne = new Player("Shelton", "Wyant", "M");
                //playerOne.ID = 6;
                database.Players.Add(playerOne);
                database.SaveChanges();

                playerOne = new Player("Roscoe", "Alston", "F");
                //playerOne.ID = 7;
                database.Players.Add(playerOne);
                database.SaveChanges();

                playerOne = new Player("Juan", "Rodriguez", "D");
                //playerOne.ID = 8;
                database.Players.Add(playerOne);
                database.SaveChanges();

                /*

                playerOne = new Player("Charlie", "Fitzgerald", "M");
                playerOne.ID = 9;
                database.Players.Add(playerOne);
                
                playerOne = new Player("Ryan", "Smith", "M");
                playerOne.ID = 10;
                database.Players.Add(playerOne);

                playerOne = new Player("Lazar", "Djokovic", "M");
                playerOne.ID = 11;
                database.Players.Add(playerOne);

                playerOne = new Player("Lionel", "Messi", "G");
                playerOne.ID = 12;
                database.Players.Add(playerOne);

                playerOne = new Player("Zlatan", "Ibrahamovic", "F");
                playerOne.ID = 13;
                database.Players.Add(playerOne);

                playerOne = new Player("Jimmy", "Wright", "M");
                playerOne.ID = 14;
                database.Players.Add(playerOne);

                playerOne = new Player("James", "Crowder", "G");
                playerOne.ID = 15;
                database.Players.Add(playerOne);

                playerOne = new Player("John", "Wheeler", "F");
                playerOne.ID = 16;
                database.Players.Add(playerOne);

                playerOne = new Player("Adam", "Wilson", "D");
                playerOne.ID = 17;
                database.Players.Add(playerOne);

                playerOne = new Player("Cameron", "Harmon", "M");
                playerOne.ID = 18;
                database.Players.Add(playerOne);

                playerOne = new Player("James", "Antonson", "F");
                playerOne.ID = 19;
                database.Players.Add(playerOne);

                playerOne = new Player("Zach", "Williams", "F");
                playerOne.ID = 20;
                database.Players.Add(playerOne);

                playerOne = new Player("Rex", "Williamson", "D");
                playerOne.ID = 21;
                database.Players.Add(playerOne);
                
                playerOne = new Player("Mack", "Tillerson", "F");
                playerOne.ID = 22;
                database.Players.Add(playerOne);

                playerOne = new Player("Aaron", "Williamson", "D");
                playerOne.ID = 23;
                database.Players.Add(playerOne);

                playerOne = new Player("Allison", "Williamson", "D");
                playerOne.ID = 24;
                database.Players.Add(playerOne);
                */
                database.SaveChanges();

            }

            if (!database.Teams.Any())
            {
                Team team = new Team("Male", "Mohigans");
                team.SchoolID = 1;
                team.Coach = database.Coaches.Where(x => x.Email == "TEST.COACH1@WVU.EDU").FirstOrDefault();
                database.Teams.Add(team);
                database.SaveChanges();

                /*
                Team teamOne = new Team("Male","Mohigans");
                teamOne.SchoolID = 1;
                teamOne.TeamID = 1;
                teamOne.Coach = database.Coaches.First();
                teamOne.CoachID = teamOne.Coach.Id;
                teamOne.School = database.Schools.Find(1);
                database.Teams.Add(teamOne);
                //teamOne.TeamID = 1;
                
                database.Teams.Add(teamOne);
                teamOne = new Team("Female", "Lady Mohigans", 1);
                teamOne.School = database.Schools.Find(1);
                teamOne.SchoolID = 1;
                //teamOne.TeamID = 2;
                database.Teams.Add(teamOne);
                teamOne = new Team("Male", "Eagles", 2);
                teamOne.School = database.Schools.Find(2);
                teamOne.SchoolID = 2;
                //teamOne.TeamID = 3;
                database.Teams.Add(teamOne);
                teamOne = new Team("Female", "Lady Eagles", 2);
                teamOne.School = database.Schools.Find(2);
                teamOne.SchoolID = 2;
                //teamOne.TeamID = 4;
                database.Teams.Add(teamOne);
                database.SaveChanges();
                */
            }

            

           
            if (!database.TeamPlayers.Any())
            {
                 DateTime startDate = new DateTime(2018, 8, 15);
                 DateTime endDate = new DateTime(2019, 8, 15);
                TeamPlayer teamPlayerOne = new TeamPlayer(startDate, 1,1);
                teamPlayerOne.TeamPlayerID = 1;
                database.TeamPlayers.Add(teamPlayerOne);
                database.SaveChanges();

                teamPlayerOne = new TeamPlayer(DateTime.Now, 2, 1);
                teamPlayerOne.TeamPlayerID = 2;
                database.TeamPlayers.Add(teamPlayerOne);
                database.SaveChanges();

                teamPlayerOne = new TeamPlayer(DateTime.Now, 3, 1);
                teamPlayerOne.TeamPlayerID = 3;
                database.TeamPlayers.Add(teamPlayerOne);
                database.SaveChanges();

                teamPlayerOne = new TeamPlayer(startDate, 4, 2);
                teamPlayerOne.EndDate = endDate;
                teamPlayerOne.TeamPlayerID = 4;
                database.TeamPlayers.Add(teamPlayerOne);
                database.SaveChanges();

            }

            //By Monday at 4:00 update google doc with user stories, business rules
            
        }
    }
}
