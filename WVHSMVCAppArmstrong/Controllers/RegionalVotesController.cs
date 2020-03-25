using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WVHSMVCAppArmstrong.Models;
using WVHSMVCAppArmstrong.Models.RegionalVoteModel;
using WVHSMVCAppArmstrong.ViewModels;

namespace WVHSMVCAppArmstrong.Controllers
{
    public class RegionalVotesController : Controller
    {
        private ISchoolRepo iSchoolRepo;
        private IPlayerRepo iPlayerRepo;
        private ITeamRepo iTeamRepo;
        private IRegionalVoteRepo iRegionalVoteRepo;

        public RegionalVotesController(ISchoolRepo schoolRepo, IPlayerRepo playerRepo,ITeamRepo TeamRepo, IRegionalVoteRepo iRegionalVoteRepo)
        {
            this.iSchoolRepo = schoolRepo;
            this.iPlayerRepo = playerRepo;
            this.iTeamRepo = TeamRepo;
            this.iRegionalVoteRepo = iRegionalVoteRepo;
        }

        public void PopulateDropDownLists()
        {
            string coachID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Team team = iTeamRepo.FindTeamUsingCoach(coachID);


            ViewData["SchoolList"] = new SelectList(iSchoolRepo.ListSchoolsForRegionalVoting(team.School.SchoolClassification,team.School.SchoolRegion,team.SchoolID),
                "SchoolID", "SchoolName");
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchPlayers()
        {
            PopulateDropDownLists();
            RegionalVoteViewModel viewModel = new RegionalVoteViewModel();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult SearchPlayersByRegionalVote(RegionalVoteViewModel viewModel)
        {
            PopulateDropDownLists();


            viewModel.playerList = SearchPlayersHelper(viewModel);
            return View(viewModel);
        }

        public List<Player> SearchPlayersHelper(RegionalVoteViewModel viewModel)
        {
            List<Player> playerList = iPlayerRepo.ListAllPlayers();
            playerList = playerList.Where(
                    p => p.TeamPlayers.All(
                        tp => tp.team.SchoolID == viewModel.SchoolID)).ToList<Player>();
            //Search gender and Search End Date
            if (viewModel.Position != null)
            {
                playerList = playerList.Where(
                    p => p.Position == viewModel.Position).ToList<Player>();
            } return playerList;
        }

        public IActionResult VoteForPlayer(int playerID)
        {
            string coachID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Team team = iTeamRepo.FindTeamUsingCoach(coachID);
            RegionalVote regionalVote = new RegionalVote(team.School.SchoolRegion, team.School.SchoolClassification,
                team.Gender, playerID, coachID);

            bool coachVoted = iRegionalVoteRepo.CheckIfCoachHasVotedForCertainPosition(coachID, playerID);
            if (!coachVoted)
            {
                iRegionalVoteRepo.VoteForPlayerAsync(regionalVote).Wait();
            }

            List<RegionalVote> regionalVotes = iRegionalVoteRepo.ListAllRegionalVotes();
            return View("ListOfRegionalVotes", regionalVotes);
        }

    }
}