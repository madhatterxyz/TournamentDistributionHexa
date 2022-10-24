using System.Numerics;

namespace TournamentDistributionHexa.Tests
{
    public class TournamentTests
    {
        [Fact]
        public void CreateTournoi_Should_Return_10Matchs()
        {
            //Arrange
            TournamentDomain domain = new TournamentDomain();
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
            List<TournamentMatch> matchs = domain.Create(games);

            //Assert
            Assert.True(matchs.Select(x => x.Game).Distinct().Count() == 10);
        }
        [Fact]
        public void CreateTournoi_Should_Return_1Matchs_Per_Game()
        {
            //Arrange
            TournamentDomain domain = new TournamentDomain();
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
            List<TournamentMatch> matchs = domain.Create(games);
            //Assert
            Assert.True(expectedMatchs.Select(x => x.Game).Distinct().SequenceEqual(matchs.Select(x => x.Game).Distinct()));
        }
    }

}