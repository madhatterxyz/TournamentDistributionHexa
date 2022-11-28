using RestSharp;
using TournamentDistributionHexa.Application.Models.Requests;
using TournamentDistributionHexa.Presentation.Web.Services.Interfaces;

namespace TournamentDistributionHexa.Presentation.Web.Services
{
    public class TournamentServices : ITournamentServices
    {
        private readonly RestClient _restClient;
        public TournamentServices(IConfiguration configuration)
        {
            _restClient = new RestClient(configuration["AppSettings:ServicesURL"]);
        }

        public async Task<List<GetTournamentResponse>> All()
        {
            var request = new RestRequest($"Tournaments");
            var response = await _restClient.ExecuteGetAsync<List<GetTournamentResponse>>(request);
            return response.Data;
        }
    }
}
