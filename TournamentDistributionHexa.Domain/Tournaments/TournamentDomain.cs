﻿using Microsoft.Extensions.Configuration;
using TournamentDistributionHexa.Domain.Players;
using TournamentDistributionHexa.Domain.Score;
using TournamentDistributionHexa.Domain.Teams;
using TournamentDistributionHexa.Domain.Tournament;
using TournamentDistributionHexa.Domain.Tournaments;

namespace TournamentDistributionHexa.Domain.Repositories
{
    public class TournamentDomain : ITournamentDomain
    {
        public const int NUMBER_PLAYERS_PER_MATCH = 3;
        private readonly ITournamentRepository _repositoryAdapter;
        private readonly IConfiguration _configuration;
        public TournamentDomain(ITournamentRepository tournamentRepositoryAdapter, IConfiguration configuration)
        {
            _repositoryAdapter = tournamentRepositoryAdapter;
            _configuration = configuration;
        }
        public List<TournamentMatch> Create(List<Player> players, List<Game> games)
        {
            var list = new List<TournamentMatch>();
            foreach (var game in games)
            {
                int numberOfPlayersCounter = 0;
                int numberOfMatchesCounter = 1;
                while (numberOfPlayersCounter < players.Count)
                {
                    List<MatchScore> scoreList = new List<MatchScore>();
                    while (numberOfPlayersCounter < NUMBER_PLAYERS_PER_MATCH * numberOfMatchesCounter)
                    {
                        scoreList.Add(new MatchScore() { Player = players[numberOfPlayersCounter] });
                        numberOfPlayersCounter++;
                    }
                    list.Add(new TournamentMatch() { Game = game, Scores = scoreList });
                    numberOfMatchesCounter++;
                }
            }
            _repositoryAdapter.Create(list);
            return list;
        }

        public async Task<List<TournamentMatch>> GetAll()
        {
            return _repositoryAdapter.GetAll();
        }
        public int GetNumberOfOccurence(Player player, List<TournamentMatch> tournamentMatchs)
        {
            return tournamentMatchs.Count(x => x.Scores.Any(y => y.Player.Equals(player)));
        }
        public Dictionary<Player, int> GetNumberOfOccurenceOfPlayers(List<Player> players, List<TournamentMatch> tournamentMatchs)
        {
            Dictionary<Player, int> result = new Dictionary<Player, int>();
            foreach (Player player in players)
            {
                result.Add(player, GetNumberOfOccurence(player, tournamentMatchs));
            }
            return result;
        }
        public List<Game> GetEvenlyDistributedGames(int gameCount, int playerCount)
        {
            List<int> players = new List<int>();
            for (int i = 0; i < playerCount; i++)
                players.Add(i);
            List<Game> games = new List<Game>();
            for (int i = 0; i < gameCount; i++)
                games.Add(new Game());

            int[] counter = new int[players.Count];
            PlayerMeeting playerMeetings = new PlayerMeeting(playerCount);

            int numberOfPlayersByTeam = int.Parse(_configuration["AppSettings:NumberOfPlayersByTeam"].ToString());
            BrowseGames(playerCount, games, counter, playerMeetings, numberOfPlayersByTeam);

            return games;
        }
        /// <summary>
        /// Browse the games in a tournament
        /// </summary>
        /// <param name="playerCount">Number of players in the tournament</param>
        /// <param name="games">List of the games in the tournament</param>
        /// <param name="counter">Number of assignation in a team for each player</param>
        /// <param name="playersMeetings">Number of meetings between two players</param>
        /// <param name="numberOfPlayersByTeam">Number of players maximum by team</param>
        private void BrowseGames(int playerCount, List<Game> games, int[] counter, PlayerMeeting playersMeetings, int numberOfPlayersByTeam)
        {
            foreach (Game game in games)
            {
                game.Teams = new List<Team>();
                BrowseTeams(playerCount, counter, playersMeetings, numberOfPlayersByTeam, game);
            }
        }
        /// <summary>
        /// Browse the teams in a game
        /// </summary>
        /// <param name="playerCount">Number of players in the tournament</param>
        /// <param name="counter">Number of assignation in a team for each player</param>
        /// <param name="playersMeetings">Number of assignation in a team for each player</param>
        /// <param name="numberOfPlayersByTeam">Number of players maximum by team</param>
        /// <param name="game"></param>
        /// <returns></returns>
        private void BrowseTeams(int playerCount, int[] counter, PlayerMeeting playersMeetings, int numberOfPlayersByTeam, Game game)
        {
            int attributedPlayers = 0;
            int numberOfTeams = (playerCount + numberOfPlayersByTeam - 1) / numberOfPlayersByTeam;
            for (int i = 0; i < numberOfTeams; i++)
            {
                Team team = new Team() { Players = new List<int>() };
                attributedPlayers = SetPlayersInTeam(playerCount, counter, playersMeetings, numberOfPlayersByTeam, attributedPlayers, team);
                game.Teams.Add(team);
            }
        }

        /// <summary>
        /// Attribute X number of players in a team
        /// </summary>
        /// <param name="playerCount">Number of players in the tournament</param>
        /// <param name="counter">Number of assignation in a team for each player</param>
        /// <param name="playersMeetings"></param>
        /// <param name="numberOfPlayersByTeam">Number of players maximum by team</param>
        /// <param name="attributedPlayers"></param>
        /// <param name="team"></param>
        /// <returns></returns>
        private static int SetPlayersInTeam(int playerCount, int[] counter, PlayerMeeting playersMeetings, int numberOfPlayersByTeam, int attributedPlayers, Team team)
        {
            for (int j = 0; j < numberOfPlayersByTeam; j++)
            {
                if (attributedPlayers < playerCount)
                {
                    int currentMinimumIndex = FilterPlayerMinList(SearchMinPlayerIndex(counter), playersMeetings, team);
                    team.Players.Add(currentMinimumIndex);
                    counter[currentMinimumIndex]++;
                    attributedPlayers++;
                    FeedNumberOfMeetingsBetweenTwoPlayers(currentMinimumIndex, playersMeetings, team);
                }
            }

            return attributedPlayers;
        }

        /// <summary>
        /// Feed the number of meetings between two players
        /// </summary>
        /// <param name="playersMeetings">Already initialized array of meetings between players</param>
        /// <param name="team"></param>
        private static void FeedNumberOfMeetingsBetweenTwoPlayers(int currentMinimumIndex, PlayerMeeting playersMeetings, Team team)
        {
            for (int l = 0; l < team.Players.Count; l++)
            {
                if (team.Players[l] != currentMinimumIndex)
                {
                    playersMeetings.IncrementMeetingsNumber(currentMinimumIndex, team.Players[l]);
                    playersMeetings.IncrementMeetingsNumber(team.Players[l], currentMinimumIndex);
                }
            }

        }

        /// <summary>
        /// Search for the first player who is the least distributed in the teams
        /// </summary>
        /// <param name="playCount">Donne le nombre de fois qu'un joueur est dans une team</param>
        /// <returns></returns>
        private static List<int> SearchMinPlayerIndex(int[] playCount)
        {
            int currentMinimumValue = int.MaxValue;
            for (int k = 0; k < playCount.Count(); k++)
            {
                if (currentMinimumValue > playCount[k])
                {
                    currentMinimumValue = playCount[k];
                }
            }
            List<int> playerWithSameMinimumValue = new List<int>();
            for (int l = 0; l < playCount.Count(); l++)
            {
                if (currentMinimumValue == playCount[l])
                {
                    playerWithSameMinimumValue.Add(l);
                }
            }
            return playerWithSameMinimumValue;
        }
        private static int FilterPlayerMinList(List<int> playersMin, PlayerMeeting playerMeetings, Team team)
        {
            int currentMinimumValue = int.MaxValue;
            for (int i = 0; i < playersMin.Count; i++)
            {
                int player = playersMin[i];
                int maximum = playerMeetings.GetMeetingsMaximumNumber(player, team.Players);
                if (maximum != int.MinValue && currentMinimumValue > maximum)
                {
                    currentMinimumValue = maximum;
                }
            }
            if (currentMinimumValue == int.MaxValue)
            {
                return playersMin[0];
            }

            List<int> playerWithSameMinimumValue = new List<int>();
            for (int i = 0; i < playersMin.Count; i++)
            {
                int player = playersMin[i];
                int maximum = playerMeetings.GetMeetingsMaximumNumber(player, team.Players);
                if (currentMinimumValue == maximum)
                {
                    playerWithSameMinimumValue.Add(player);
                }
            }

            return playerWithSameMinimumValue[0];
        }

    }
}