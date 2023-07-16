namespace IFootball.Application.Contracts.Documents.Dtos;

public class TeamUserDto
{
    public long IdUser { get; set; }
    public long IdGender { get; set; }
    public long IdGoalkeeper { get; set; }
    public long IdLinePlayerFrontLeft { get; set; }
    public long IdLinePlayerFrontRight { get; set; }
    public long IdLinePlayerBackRight { get; set; }
    public long IdLinePlayerBackLeft { get; set; }
}