using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using TournamentDistributionHexa.Domain;
using TournamentDistributionHexa.Domain.Players;
using TournamentDistributionHexa.Domain.Repositories;
using TournamentDistributionHexa.Domain.Score;
using TournamentDistributionHexa.Domain.Tournament;
using TournamentDistributionHexa.Domain.Tournaments;

namespace TournamentDistributionHexa.Tests.UnitTests
{
    public class TournamentUnitTests
    {
        [Fact]
        public void CreateTournoi_Should_Return_10Matchs()
        {
            //Arrange
            var adapter = new Mock<ITournamentRepository>();
            ITournamentDomain domain = new TournamentDomain(adapter.Object);
            List<Player> players = new List<Player>() {
                new Player(){ID=1, Firstname = "Nicolas",Lastname="B",Telephone=""},
                new Player(){ID=2, Firstname = "Alexandra",Lastname="F",Telephone=""},
                new Player(){ID=3, Firstname = "Jeremy",Lastname="F",Telephone=""}
            };
            List<Game> games = new List<Game>()
            {
                new Game(){ ID = 1, Name = "Ark Nova"},
                new Game(){ ID = 2, Name = "Zombidice"},
                new Game(){ ID = 3, Name = "Perudo"},
                new Game(){ ID = 4, Name = "Living Forest"},
                new Game(){ ID = 5, Name = "Mille fiori"},
                new Game(){ ID = 6, Name = "Augustus"},
                new Game(){ ID = 7, Name = "Dune Imperium"},
                new Game(){ ID = 8, Name = "Cactus town"},
                new Game(){ ID = 9, Name = "Akropolis"},
                new Game(){ ID = 10, Name = "L'�ge de pierre"}
            };

            //Act
            List<TournamentMatch> matchs = domain.Create(players, games);

            //Assert
            Assert.True(matchs.Select(x => x.Game).Distinct().Count() == 10);
        }
        [Fact]
        public void CreateTournoi_Should_Return_1Matchs_Per_Game()
        {
            //Arrange
            var adapter = new Mock<ITournamentRepository>();
            ITournamentDomain domain = new TournamentDomain(adapter.Object);
            List<Player> players = new List<Player>() {
                new Player(){ID=1, Firstname = "Nicolas",Lastname="B",Telephone=""},
                new Player(){ID=2, Firstname = "Alexandra",Lastname="F",Telephone=""},
                new Player(){ID=3, Firstname = "Jeremy",Lastname="F",Telephone=""}
            };
            List<Game> games = new List<Game>()
            {
                new Game(){ ID = 1, Name = "Ark Nova"},
                new Game(){ ID = 2, Name = "Zombidice"},
                new Game(){ ID = 3, Name = "Perudo"},
                new Game(){ ID = 4, Name = "Living Forest"},
                new Game(){ ID = 5, Name = "Mille fiori"},
                new Game(){ ID = 6, Name = "Augustus"},
                new Game(){ ID = 7, Name = "Dune Imperium"},
                new Game(){ ID = 8, Name = "Cactus town"},
                new Game(){ ID = 9, Name = "Akropolis"},
                new Game(){ ID = 10, Name = "L'�ge de pierre"}
            };
            List<TournamentMatch> expectedMatchs = new List<TournamentMatch>()
            {
                new TournamentMatch(){ Game = games[0] },
                new TournamentMatch(){ Game = games[1] },
                new TournamentMatch(){ Game = games[2] },
                new TournamentMatch(){ Game = games[3] },
                new TournamentMatch(){ Game = games[4] },
                new TournamentMatch(){ Game = games[5] },
                new TournamentMatch(){ Game = games[6] },
                new TournamentMatch(){ Game = games[7] },
                new TournamentMatch(){ Game = games[8] },
                new TournamentMatch(){ Game = games[9] },
            };
            //Act
            List<TournamentMatch> matchs = domain.Create(players, games);
            //Assert
            Assert.True(expectedMatchs.Select(x => x.Game).Distinct().SequenceEqual(matchs.Select(x => x.Game).Distinct()));
        }
        [Fact]
        public void CreateTournoi_With1Game_Should_Return_3DifferentPlayers_Per_Match()
        {
            //Arrange
            var adapter = new Mock<ITournamentRepository>();
            ITournamentDomain domain = new TournamentDomain(adapter.Object);
            List<Player> players = new List<Player>()
            {
                new Player(){ID=1, Firstname = "Nicolas",Lastname="B",Telephone=""},
                new Player(){ID=2, Firstname = "Alexandra",Lastname="F",Telephone=""},
                new Player(){ID=3, Firstname = "Jeremy",Lastname="F",Telephone=""},
                new Player(){ID=4, Firstname = "Ludovic",Lastname="R",Telephone=""},
                new Player(){ID=5, Firstname = "Julien",Lastname="P",Telephone=""},
                new Player(){ID=6, Firstname = "Nicolas",Lastname="F",Telephone=""},
                new Player(){ID=7, Firstname = "Corentin",Lastname="C",Telephone=""},
                new Player(){ID=8, Firstname = "Corinne",Lastname="O",Telephone=""},
                new Player(){ID=9, Firstname = "Laura",Lastname="X",Telephone=""},
                new Player(){ID=10, Firstname = "No�mie",Lastname="R",Telephone=""},
                new Player(){ID=11, Firstname = "Denis",Lastname="R",Telephone=""},
                new Player(){ID=12, Firstname = "Gabriel",Lastname="Y",Telephone=""}
            };
            List<Game> games = new List<Game>()
            {
                new Game(){ ID = 1, Name = "Ark Nova"}
            };
            List<TournamentMatch> expectedMatchs = new List<TournamentMatch>()
            {
                new TournamentMatch(){ Game = games[0], Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[0] },
                    new MatchScore() { Player = players[1] },
                    new MatchScore() { Player = players[2] },
                } },
                new TournamentMatch(){ Game = games[0], Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[3] },
                    new MatchScore() { Player = players[4] },
                    new MatchScore() { Player = players[5] },
                } },
                new TournamentMatch(){ Game = games[0], Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[6] },
                    new MatchScore() { Player = players[7] },
                    new MatchScore() { Player = players[8] },
                } },
                new TournamentMatch(){ Game = games[0], Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[9] },
                    new MatchScore() { Player = players[10] },
                    new MatchScore() { Player = players[11] },
                } }

            };
            //Act
            List<TournamentMatch> matchs = domain.Create(players, games);
            //Assert
            Assert.True(expectedMatchs.SequenceEqual(matchs));
        }

        [Fact]
        public async Task GetAll_Should_Return_1_TournamentMatch()
        {
            //Arrange
            var adapter = new Mock<ITournamentRepository>();
            adapter.Setup(x => x.GetAll()).Returns(new List<TournamentMatch>() {
                new TournamentMatch() {
                    Game = new Game()
                    {
                        ID = 1,
                        Name = "Ark Nova"
                    },
                    Scores = new List<MatchScore>(){
                        new MatchScore()
                        {
                            Player = new Player(){
                                ID = 1,
                                Firstname ="Nicolas",
                                Lastname = "B",
                                Telephone=""
                            }
                        }
                    } 
                }
            });
            ITournamentDomain domain = new TournamentDomain(adapter.Object);
            //Act
            List<TournamentMatch> matchs = await domain.GetAll();
            //Assert
            Assert.True(matchs.Count() == 1);
        }
        [Fact]
        public void GetNumberOfOccurence_Should_Return_1_for_Player1()
        {
            //Arrange
            var adapter = new Mock<ITournamentRepository>();
            ITournamentDomain domain = new TournamentDomain(adapter.Object);
            List<Player> players = new List<Player>()
            {
                new Player(){ID=1, Firstname = "Nicolas",Lastname="B",Telephone=""},
                new Player(){ID=2, Firstname = "Alexandra",Lastname="F",Telephone=""},
                new Player(){ID=3, Firstname = "Jeremy",Lastname="F",Telephone=""},
                new Player(){ID=4, Firstname = "Ludovic",Lastname="R",Telephone=""},
                new Player(){ID=5, Firstname = "Julien",Lastname="P",Telephone=""},
                new Player(){ID=6, Firstname = "Nicolas",Lastname="F",Telephone=""},
                new Player(){ID=7, Firstname = "Corentin",Lastname="C",Telephone=""},
                new Player(){ID=8, Firstname = "Corinne",Lastname="O",Telephone=""},
                new Player(){ID=9, Firstname = "Laura",Lastname="X",Telephone=""},
                new Player(){ID=10, Firstname = "No�mie",Lastname="R",Telephone=""},
                new Player(){ID=11, Firstname = "Denis",Lastname="R",Telephone=""},
                new Player(){ID=12, Firstname = "Gabriel",Lastname="Y",Telephone=""}
            };
            List<Game> games = new List<Game>()
            {
                new Game(){ ID = 1, Name = "Ark Nova"}
            };
            List<TournamentMatch> tournamentMatchs = new List<TournamentMatch>()
            {
                new TournamentMatch(){ Game = games[0], Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[0] },
                    new MatchScore() { Player = players[1] },
                    new MatchScore() { Player = players[2] },
                } },
                new TournamentMatch(){ Game = games[0], Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[3] },
                    new MatchScore() { Player = players[4] },
                    new MatchScore() { Player = players[5] },
                } },
                new TournamentMatch(){ Game = games[0], Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[6] },
                    new MatchScore() { Player = players[7] },
                    new MatchScore() { Player = players[8] },
                } },
                new TournamentMatch(){ Game = games[0], Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[9] },
                    new MatchScore() { Player = players[10] },
                    new MatchScore() { Player = players[11] },
                } }

            };

            //Act
            int numberOfOccurence = domain.GetNumberOfOccurence(players[0], tournamentMatchs);

            //Assert
            Assert.True(numberOfOccurence == 1);
        }
        [Fact]
        public void GetNumberOfOccurencesOfPlayers_Should_Return_1_for_each_Player()
        {
            //Arrange
            var adapter = new Mock<ITournamentRepository>();
            ITournamentDomain domain = new TournamentDomain(adapter.Object);
            List<Player> players = new List<Player>()
            {
                new Player(){ID=1, Firstname = "Nicolas",Lastname="B",Telephone=""},
                new Player(){ID=2, Firstname = "Alexandra",Lastname="F",Telephone=""},
                new Player(){ID=3, Firstname = "Jeremy",Lastname="F",Telephone=""},
                new Player(){ID=4, Firstname = "Ludovic",Lastname="R",Telephone=""},
                new Player(){ID=5, Firstname = "Julien",Lastname="P",Telephone=""},
                new Player(){ID=6, Firstname = "Nicolas",Lastname="F",Telephone=""},
                new Player(){ID=7, Firstname = "Corentin",Lastname="C",Telephone=""},
                new Player(){ID=8, Firstname = "Corinne",Lastname="O",Telephone=""},
                new Player(){ID=9, Firstname = "Laura",Lastname="X",Telephone=""},
                new Player(){ID=10, Firstname = "No�mie",Lastname="R",Telephone=""},
                new Player(){ID=11, Firstname = "Denis",Lastname="R",Telephone=""},
                new Player(){ID=12, Firstname = "Gabriel",Lastname="Y",Telephone=""}
            };
            List<Game> games = new List<Game>()
            {
                new Game(){ ID = 1, Name = "Ark Nova"}
            };
            List<TournamentMatch> tournamentMatchs = new List<TournamentMatch>()
            {
                new TournamentMatch(){ Game = games[0], Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[0] },
                    new MatchScore() { Player = players[1] },
                    new MatchScore() { Player = players[2] },
                } },
                new TournamentMatch(){ Game = games[0], Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[3] },
                    new MatchScore() { Player = players[4] },
                    new MatchScore() { Player = players[5] },
                } },
                new TournamentMatch(){ Game = games[0], Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[6] },
                    new MatchScore() { Player = players[7] },
                    new MatchScore() { Player = players[8] },
                } },
                new TournamentMatch(){ Game = games[0], Scores = new List<MatchScore>(){
                    new MatchScore() { Player = players[9] },
                    new MatchScore() { Player = players[10] },
                    new MatchScore() { Player = players[11] },
                } }

            };
            Dictionary<Player, int> expectedResult = new Dictionary<Player, int>()
            {
                {players[0],1 },
                {players[1],1 },
                {players[2],1 },
                {players[3],1 },
                {players[4],1 },
                {players[5],1 },
                {players[6],1 },
                {players[7],1 },
                {players[8],1 },
                {players[9],1 },
                {players[10],1 },
                {players[11],1 }
            };

            //Act
            Dictionary<Player,int> numberOfOccurences = domain.GetNumberOfOccurenceOfPlayers(players, tournamentMatchs);

            //Assert
            Assert.True(numberOfOccurences.SequenceEqual(expectedResult));
        }

    }

}