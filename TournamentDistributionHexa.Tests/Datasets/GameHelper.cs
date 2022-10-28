using TournamentDistributionHexa.Domain;

namespace TournamentDistributionHexa.Tests.Datasets
{
    public static class GameHelper
    {
        public static List<Game> GetGames()
        {
            return new List<Game>()
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
        }
        public static Game Get1Game()
        {
            return GetGames()[0];
        }
        public static List<Game> Get2Games()
        {
            return new List<Game>() { GetGames()[0], GetGames()[1] };
        }
    }
}
