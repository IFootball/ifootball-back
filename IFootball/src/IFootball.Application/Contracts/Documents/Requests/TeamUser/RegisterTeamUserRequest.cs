namespace IFootball.Application.Contracts.Documents.Requests;

public class RegisterTeamUserRequest
{
    public long IdGender { get; set; }
    
    public long IdGoalkeeper { get; set; }
    public long IdLinePlayerFrontLeft { get; set; }
    public long IdLinePlayerFrontRight { get; set; }
    public long IdLinePlayerBackRight { get; set; }
    public long IdLinePlayerBackLeft { get; set; }
}