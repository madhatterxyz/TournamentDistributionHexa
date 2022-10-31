﻿using TournamentDistributionHexa.Domain.Players;
using TournamentDistributionHexa.Domain.Tournament;

namespace TournamentDistributionHexa.Domain.Repositories
{
    public interface ITournamentDomain
    {
        List<TournamentMatch> Create(string nom, IList<Player> players, IList<Game> games);
        List<TournamentMatch> GetAll();
        IList<Game> GetEvenlyDistributedGames(IList<Game> games, int playerCount);
    }
}