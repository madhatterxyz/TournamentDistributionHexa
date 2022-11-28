using RestSharp;
using TournamentDistributionHexa.Application.Models.Requests;
using TournamentDistributionHexa.Domain.Scores;
using TournamentDistributionHexa.Presentation.Web.Services.Interfaces;

namespace TournamentDistributionHexa.Presentation.Web.Services
{
    public class ScoreServices : IScoreServices
    {
        private readonly RestClient _restClient;
        public ScoreServices(IConfiguration configuration)
        {
            _restClient = new RestClient(configuration["AppSettings:ServicesURL"]);
        }

        public async Task<List<GetScoreResponse>> GetScores(long tournamentId)
        {
            var request = new RestRequest($"Tournaments/{tournamentId}/Scores");
            var response = await _restClient.ExecuteGetAsync<List<GetScoreResponse>>(request);
            return response.Data;
        }
        public async Task<ScoreDTO> GetById(long matchId,long joueurId)
        {
            var request = new RestRequest($"Scores/{matchId}?joueurId={joueurId}");
            var response = await _restClient.ExecuteGetAsync<ScoreDTO>(request);
            return response.Data;
        }

        public async Task Update(ScoreDTO scoreDTO)
        {
            var request = new RestRequest($"Scores", Method.Put);
            request.AddBody(scoreDTO);
            var response = await _restClient.ExecutePutAsync(request);
        }
    }
}
