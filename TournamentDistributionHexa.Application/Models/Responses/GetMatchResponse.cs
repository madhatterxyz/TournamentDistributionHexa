namespace TournamentDistributionHexa.Application.Models.Requests;

public class GetMatchResponse
{
    public GetMatchResponse(long id, string name)
    {
        Id = id;
        Name = name;
    }
    public long Id { get; init; }
    public string Name { get; init; }
}