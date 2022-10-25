using TournamentDistributionHexa.Domain;
using TournamentDistributionHexa.Domain.Players;
using TournamentDistributionHexa.Domain.Repositories;
using TournamentDistributionHexa.Domain.Score;
using TournamentDistributionHexa.Domain.Tournament;

namespace TournamentDistributionHexa.Tests
{
    public class TournamentTests
    {
        [Fact]
        public void CreateTournoi_Should_Return_10Matchs()
        {
            //Arrange
            ITournamentDomain domain = new TournamentDomain();
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
                new Game(){ ID = 10, Name = "L'âge de pierre"}
            };

            //Act
            List<TournamentMatch> matchs = domain.Create(players,games);

            //Assert
            Assert.True(matchs.Select(x => x.Game).Distinct().Count() == 10);
        }
        [Fact]
        public void CreateTournoi_Should_Return_1Matchs_Per_Game()
        {
            //Arrange
            ITournamentDomain domain = new TournamentDomain();
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
                new Game(){ ID = 10, Name = "L'âge de pierre"}
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
            List<TournamentMatch> matchs = domain.Create(players,games);
            //Assert
            Assert.True(expectedMatchs.Select(x => x.Game).Distinct().SequenceEqual(matchs.Select(x => x.Game).Distinct()));
        }
        [Fact]
        public void CreateTournoi_With1Game_Should_Return_3DifferentPlayers_Per_Match()
        {
            //Arrange
            ITournamentDomain domain = new TournamentDomain();
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
                new Player(){ID=10, Firstname = "Noémie",Lastname="R",Telephone=""},
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
    }

}