using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WVHSMVCAppArmstrong.Models;
using WVHSMVCAppArmstrong.ViewModels;

namespace WVHSMVCAppArmstrong.Controllers
{
    public class PlayersController : Controller
    {
        //private ApplicationDbContext database;
        private IPlayerRepo iPlayerRepo;
        private ISchoolRepo iSchoolRepo;
        private ITeamRepo iTeamRepo;
        private ITeamPlayerRepo iTeamPlayerRepo;

        public PlayersController(IPlayerRepo playerRepo, ISchoolRepo schoolRepo, ITeamRepo teamRepo, ITeamPlayerRepo iTeamPlayerRepo)
        {
            this.iPlayerRepo = playerRepo;
            this.iSchoolRepo = schoolRepo;
            this.iTeamRepo = teamRepo;
            this.iTeamPlayerRepo = iTeamPlayerRepo;
        }

        public IActionResult ListAllPlayers()
        {
            List<Player> playerList = ListAllPlayersHelper();
            return View("~/Views/Players/ListAllPlayers.cshtml", playerList);
        }

        public List<Player> ListAllPlayersHelper()
        {
            List<Player> playerList = iPlayerRepo.ListAllPlayers();
            return playerList;
        }


        [HttpGet]
        public IActionResult SearchPlayers()
        {
            PopulateDropDownLists();
            SearchPlayersViewModel viewModel = new SearchPlayersViewModel();
            return View("~/Views/Players/SearchPlayers.cshtml", viewModel);
        }
        [HttpPost]
        public IActionResult SearchPlayers(SearchPlayersViewModel viewModel)
        {
            PopulateDropDownLists();


            viewModel.PlayerList = SearchPlayersHelper(viewModel);
            return View("~/Views/Players/SearchPlayers.cshtml", viewModel);
        }

        public List<Player> SearchPlayersHelper(SearchPlayersViewModel viewModel)
        {
            List<Player> playerList = iPlayerRepo.ListAllPlayers();


            if (viewModel.SchoolID != null)
            {
                playerList = playerList.Where(
                    p => p.TeamPlayers.All(
                        tp => tp.team.SchoolID == viewModel.SchoolID)).ToList<Player>();
            }

            //Search gender and Search End Date
            if (viewModel.Gender != null)
            {
                playerList = playerList.Where(
                    p => p.TeamPlayers.All(
                        tp => tp.team.Gender == viewModel.Gender)).ToList<Player>();
            }
            if (viewModel.Position != null)
            {
                playerList = playerList.Where(
                    p => p.Position == viewModel.Position).ToList<Player>();
            }

            if (viewModel.SearchStartDate != null)
            {
                playerList = playerList.Where(p => p.TeamPlayers.All(
                    tp => tp.StartDate.Date >= viewModel.SearchStartDate.Value.Date)).ToList<Player>();
            }

            return playerList;
        }

        [HttpGet]
        [Authorize(Roles = "Coach")]
        public IActionResult AddPlayersByCoach()
        {
            AddPlayersViewModel viewModel = new AddPlayersViewModel();
            return View("~/Views/Players/AddPlayers.cshtml", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Coach")]
        public IActionResult AddPlayersByCoach(AddPlayersViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Player player = new Player(viewModel.FirstName, viewModel.LastName, viewModel.Position);
                iPlayerRepo.AddPlayerAsync(player).Wait();
                //Find players team coachid

                string coachID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                int playerID = player.ID;

                int teamID = iTeamRepo.FindTeamIDByCoach(coachID);
                /*
                TeamPlayer teamPlayer = new TeamPlayer(viewModel.startDate, player.ID, team.TeamID);
                database.TeamPlayers.Add(teamPlayer);
                database.SaveChanges();
                */
                iTeamPlayerRepo.AddTeamPlayer(viewModel.startDate, playerID, teamID).Wait();


                return RedirectToAction("SearchPlayers");

            }//END OF IF STATEMENT
            else
            {
                PopulateDropDownLists();
                return View("~/Views/Players/AddPlayers.cshtml");
            }
            //must have add player working and tested 
            //ALSO create findTeamHelper()
            //Create TeamPlayerRepo

        }
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult EditPlayer(int playerID)
        {
            Player player = iPlayerRepo.FindPlayer(playerID);
            return View("~/Views/Players/EditPlayer.cshtml", player);
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult EditPlayer(Player player)
        {
            iPlayerRepo.EditPlayerAsync(player).Wait();
            return RedirectToAction("SearchPlayers");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Coach")]
        public IActionResult AddPlayers()
        {
            PopulateDropDownLists();
            AddPlayersViewModel viewModel = new AddPlayersViewModel();
            return View("~/Views/Players/AddPlayers.cshtml", viewModel);
        }

        [HttpPost]
        public IActionResult AddPlayers(AddPlayersViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Player player = new Player(viewModel.FirstName, viewModel.LastName, viewModel.Position);
                iPlayerRepo.AddPlayerAsync(player).Wait();
                //Find players team from the values passed in from the view model schoolID and Gender

                Team team = iTeamRepo.FindTeam(viewModel.SchoolID, viewModel.Gender);
                int teamID = team.TeamID;
                int playerID = player.ID;
                /*
                TeamPlayer teamPlayer = new TeamPlayer(viewModel.startDate, player.ID, team.TeamID);
                database.TeamPlayers.Add(teamPlayer);
                database.SaveChanges();
                */
                iTeamPlayerRepo.AddTeamPlayer(viewModel.startDate, playerID, teamID).Wait();


                return RedirectToAction("SearchPlayers");

            }//END OF IF STATEMENT
            else
            {
                PopulateDropDownLists();
                return View("~/Views/Players/AddPlayers.cshtml");
            }


        }

        public async Task AddPlayerHelper(Player player)
        {
            await iPlayerRepo.AddPlayerAsync(player);
        }

        public Team FindTeam(int schoolID, string gender)
        {
            return iTeamRepo.FindTeam(schoolID, gender);
        }

        public IActionResult DeletePlayer(Player player)
        {
            iPlayerRepo.DeletePlayerAsync(player).Wait();
            return RedirectToAction("SearchPlayers");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult ConfirmDeletePlayer(int playerID)
        {
            Player player = iPlayerRepo.FindPlayer(playerID);
            return View("~/Views/Players/ConfirmDeletePlayer.cshtml", player);
        }


        public void PopulateDropDownLists()
        {
            ViewData["SchoolList"] = new SelectList(iSchoolRepo.ListAllSchools(), "SchoolID", "SchoolName");
        }


    }
}
