using Moq;
using System;
using WVHSMVCAppArmstrong.Models;
using WVHSMVCAppArmstrong.Controllers;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WVHSMVCAppArmstrong.ViewModels;

namespace WVHSTestProjectArmstrong
{
    public class PlayerTest
    {
        private Mock<IPlayerRepo> mockPlayerRepo;
        private Mock<ISchoolRepo> mockSchoolRepo;
        private Mock<ITeamRepo> mockTeamRepo;
        private Mock<ITeamPlayerRepo> mockTeamPlayerRepo;
        private PlayersController playersController;
        private List<Player> mockPlayerList;

        public PlayerTest()
        {
            mockPlayerRepo = new Mock<IPlayerRepo>();
            mockSchoolRepo = new Mock<ISchoolRepo>();
            mockTeamPlayerRepo = new Mock<ITeamPlayerRepo>();
            mockTeamRepo = new Mock<ITeamRepo>();
            playersController = new PlayersController(mockPlayerRepo.Object,mockSchoolRepo.Object,mockTeamRepo.Object,mockTeamPlayerRepo.Object);
            mockPlayerList = new List<Player>();

        }

        public List<Player> MockPlayerData()
        {
            List<Player> playerList = new List<Player>();

            School schoolOne = new School("Morgantown High School", "1 High St", "AAA", 1);
            schoolOne.SchoolID = 1;

            Team teamOne = new Team("Male", "Mohigans", 1);
            teamOne.TeamID = 1;
            teamOne.CoachID = "1";

            Coach coachTwo = new Coach("Graham", "Peace", "TEST.COACH1@WVU.EDU", "304.000.0003", "Test.Coach1",1);
            coachTwo.Id = "1";
            coachTwo.TeamID = 1;
            Player playerOne = new Player("Rex", "Williamson", "D");
            playerOne.ID = 1;

            DateTime startDate = new DateTime(2018, 8, 15);
            TeamPlayer teamPlayerOne = new TeamPlayer(startDate, 1, 1);
            teamPlayerOne.TeamPlayerID = 1;
            teamPlayerOne.Player = playerOne;
            teamPlayerOne.team = teamOne;
            teamPlayerOne.TeamID = 1;

            playerOne.TeamPlayers.Add(teamPlayerOne);
            teamOne.TeamPlayers.Add(teamPlayerOne);
            playerList.Add(playerOne);


            playerOne = new Player("Mack", "Tillerson", "F");
            playerOne.ID = 2;

            startDate = new DateTime(2019, 9, 16);
            teamPlayerOne = new TeamPlayer(startDate, 2, 1);
            teamPlayerOne.TeamPlayerID = 2;
            teamPlayerOne.Player = playerOne;
            teamPlayerOne.team = teamOne;
            teamPlayerOne.TeamID = 1;
            teamOne.TeamPlayers.Add(teamPlayerOne);
            teamOne.TeamPlayers.Add(teamPlayerOne);
            playerList.Add(playerOne);


            teamOne = new Team("Female", "Mohigans", 1);
            teamOne.TeamID = 2;
            teamOne.CoachID = "2";

            Coach coachThree = new Coach("Sam", "Grease", "TEST.COACH1@WVU.EDU", "304.000.0003", "Test.Coach1",2);
            coachThree.TeamID = 2;
            coachThree.Team = teamOne;

            playerOne = new Player("Mackenzie", "Williamson", "D");
            playerOne.ID = 3;
            teamPlayerOne = new TeamPlayer(startDate, 3, 2);
            teamPlayerOne.TeamPlayerID = 3;
            teamPlayerOne.Player = playerOne;
            teamPlayerOne.PlayerID = 3;
            teamPlayerOne.team = teamOne;
            playerOne.TeamPlayers.Add(teamPlayerOne);
            teamOne.TeamPlayers.Add(teamPlayerOne);
            playerList.Add(playerOne);


            playerOne = new Player("Allison", "Williamson", "G");
            playerOne.ID = 4;
            startDate = new DateTime(2015, 3, 20);
            teamPlayerOne = new TeamPlayer(startDate, 4, 2);
            teamPlayerOne.TeamPlayerID = 4;
            teamPlayerOne.Player = playerOne;
            teamPlayerOne.team = teamOne;
            teamPlayerOne.TeamPlayerID = 4;
            playerOne.TeamPlayers.Add(teamPlayerOne);
            teamOne.TeamPlayers.Add(teamPlayerOne);
            playerList.Add(playerOne);

            schoolOne = new School("Braxton County High School", "200 Jerry Burton Dr", "AA", 2);
            schoolOne.SchoolID = 2;

            teamOne = new Team("Male", "Eagles", 2);
            teamOne.TeamID = 3;
            teamOne.CoachID = "3";

            playerOne = new Player("James", "Antonson", "G");
            playerOne.ID = 5;
            teamPlayerOne = new TeamPlayer(startDate, 5, 3);
            teamPlayerOne.TeamPlayerID = 5;
            teamPlayerOne.Player = playerOne;
            teamPlayerOne.team = teamOne;
            teamPlayerOne.PlayerID = 5;
            playerOne.TeamPlayers.Add(teamPlayerOne);
            teamOne.TeamPlayers.Add(teamPlayerOne);
            playerList.Add(playerOne);

            return playerList;
        }
        [Fact]
        public void ShouldListAllPlayers()
        {
            mockPlayerList = MockPlayerData();
            mockPlayerRepo.Setup(m => m.ListAllPlayers()).Returns(mockPlayerList);
            int expectedNumberOfPlayers = mockPlayerList.Count;
            int actualNumberOfPlayers = 0;

            List<Player> actualPlayerList = playersController.ListAllPlayersHelper();
            actualNumberOfPlayers = actualPlayerList.Count;

            Assert.Equal(expectedNumberOfPlayers, actualNumberOfPlayers);
            Assert.Equal(mockPlayerList, actualPlayerList);
        }

        [Fact]
        public void ShouldSearchForAllPlayers()
        {
            mockPlayerList = MockPlayerData();
            mockPlayerRepo.Setup(m => m.ListAllPlayers()).Returns(mockPlayerList);
            int expectedNumberOfPlayers = mockPlayerList.Count;
            int actualNumberOfPlayers = 0;
            SearchPlayersViewModel viewModel = new SearchPlayersViewModel();
            viewModel.SchoolID = null;
            viewModel.Gender = null;
            viewModel.SearchEndDate = null;
            viewModel.Division = null;

            List<Player> actualPlayerList = playersController.SearchPlayersHelper(viewModel);
            actualNumberOfPlayers = actualPlayerList.Count;

            Assert.Equal(expectedNumberOfPlayers, actualNumberOfPlayers);
            Assert.Equal(mockPlayerList, actualPlayerList);
        }

        [Fact]
        public void ShouldSearchForAllPlayersAtMHS()
        {
            mockPlayerList = MockPlayerData();
            mockPlayerRepo.Setup(m => m.ListAllPlayers()).Returns(mockPlayerList);
            int expectedNumberOfPlayers = mockPlayerList.Count;
            int actualNumberOfPlayers = 0;
            SearchPlayersViewModel viewModel = new SearchPlayersViewModel();
            viewModel.SchoolID = 1;
            viewModel.Gender = "";
            viewModel.SearchEndDate = null;
            viewModel.Division = "";
            List<Player> expectedPlayerList = mockPlayerList.Where(
                m => m.TeamPlayers.All(tp => tp.team.SchoolID == viewModel.SchoolID
                                             && tp.team.Gender == viewModel.Gender)).ToList<Player>();

            List<Player> actualPlayerList = playersController.SearchPlayersHelper(viewModel);
            actualNumberOfPlayers = actualPlayerList.Count;
            expectedNumberOfPlayers = expectedPlayerList.Count; 

            Assert.Equal(expectedNumberOfPlayers, actualNumberOfPlayers);
            Assert.Equal(expectedPlayerList, actualPlayerList);
        }
        [Fact]
        public void ShouldSearchForAllMalePlayersAtMHSthatAreDefenders()
        {
            mockPlayerList = MockPlayerData();
            mockPlayerRepo.Setup(m => m.ListAllPlayers()).Returns(mockPlayerList);
            int expectedNumberOfPlayers = mockPlayerList.Count;
            int actualNumberOfPlayers = 0;
            SearchPlayersViewModel viewModel = new SearchPlayersViewModel();
            viewModel.SchoolID = 1;
            viewModel.Gender = "Male";
            viewModel.SearchEndDate = null;
            viewModel.Division = null;
            viewModel.Position = "D";
            List<Player> expectedPlayerList = mockPlayerList.Where(
                m => m.TeamPlayers.All(tp => tp.team.SchoolID == viewModel.SchoolID
                                             && tp.team.Gender == viewModel.Gender)&& m.Position == viewModel.Position).ToList<Player>();

            List<Player> actualPlayerList = playersController.SearchPlayersHelper(viewModel);
            actualNumberOfPlayers = actualPlayerList.Count;
            expectedNumberOfPlayers = expectedPlayerList.Count;

            Assert.Equal(expectedNumberOfPlayers, actualNumberOfPlayers);
            Assert.Equal(expectedPlayerList, actualPlayerList);
        }

        [Fact]
        public void ShouldAddPlayer()
        {
            // 1. Arrange
            Player player = new Player
            {
                ID = 1,
                FirstName = "Carl",
                LastName = "Forward",
                TeamPlayers = new List<TeamPlayer>()
            };
            // 2. Act
            Player expectedPlayer = player;
            Player actualAddedPlayer = null;

            mockPlayerRepo.Setup(m => m.AddPlayerAsync(It.IsAny<Player>()))
                .Returns(Task.CompletedTask)
                .Callback<Player>(p => actualAddedPlayer = p);

            playersController.AddPlayerHelper(player).Wait();
            // 3. Assert
            Assert.Equal(expectedPlayer.FullName,actualAddedPlayer.FullName);
            Assert.Equal(expectedPlayer, actualAddedPlayer);
        }
        [Fact]
        public void ShouldFindExistingTeam()
        {
            School school = new School("Morgantown High School", "109 Wilson Avenue", "AAA", 1);
            school.SchoolID = 1;

            Team team = new Team("Mohigans", "Boys", 1);
            team.TeamID = 1;

            int schoolID = 1;
            string gender = "Girls";

            Team expectedTeam = team;
            Team actualTeamFound = null;

            mockTeamRepo.Setup
                    (m => m.FindTeam(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(team);
            //Act

            actualTeamFound = playersController.FindTeam(schoolID,gender);
            //Assert

            Assert.Equal(expectedTeam.Name, actualTeamFound.Name);

            //playersController = new PlayersTestingController(mockPlayerRepo.Object,
            // mockSchoolRepo.Object, mockTeamRepo.Object);

        }
        [Fact(Skip = "Not Yet Implemented")]
        public void ShouldAddNonExistingTeam()
        {

        }
        [Fact(Skip = "Not Yet Implemented")]
        public void ShouldAddPlayerToTeam()
        {

        }

        [Fact]
        public void ShouldEditPlayer()
        {
            Player player = new Player
            {
                ID = 1,
                FirstName = "Carl",
                LastName = "Forward",
                TeamPlayers = new List<TeamPlayer>()
            };
            mockPlayerRepo.Setup(m => m.EditPlayerAsync(It.IsAny<Player>()));
            IActionResult result =  playersController.EditPlayer(player);

            mockPlayerRepo.Verify(m => m.EditPlayerAsync(It.IsAny<Player>()),Times.Once);

        }

        [Fact]
        public void ShouldDeletePlayer()
        {
            Player player = new Player
            {
                ID = 1,
                FirstName = "Carl",
                LastName = "Forward",
                TeamPlayers = new List<TeamPlayer>()
            };
            mockPlayerRepo.Setup(m => m.DeletePlayerAsync(It.IsAny<Player>()));
            IActionResult result = playersController.DeletePlayer(player);

            mockPlayerRepo.Verify(m => m.DeletePlayerAsync(It.IsAny<Player>()), Times.Once);

        }



    }
}
