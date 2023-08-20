namespace IFootball.Application.Contracts.Documents.Dtos.TeamClass;

public class CompleteTeamClassDto
{
    public long IdGender { get; set; }
    public long IdClass { get; set; }
    public string ClassName { get; set; }

    public IEnumerable<SimplePlayerDto> TeamClassPlayers { get; set; }
}