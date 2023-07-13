namespace IFootball.Application.Contracts.Documents.Requests;

public class RegisterTeamUserRequest
{
    public long IdGoalkeeper { get; set; }
    public long IdLinePlayerFront { get; set; }
    public long IdLinePlayerMiddle { get; set; }
    public long IdLinePlayerBackRight { get; set; }
    public long IdLinePlayerBackLeft { get; set; }
    public long? IdReservePlayerOne { get; set; }
    public long? IdReservePlayerTwo { get; set; }
    public long? IdCaptain { get; set; }
}