namespace IFootball.Application.Contracts.Documents.Dtos.TeamClass;

public class CompleteTeamClassDto
{
    public long IdGender { get; set; }
    public long IdClass { get; set; }
    
    public IEnumerable<GoalkeeperDto> TeamClassGoalkeepers { get; set; }
    public IEnumerable<LinePlayerDto> TeamClassLinePlayers { get; set; }
}