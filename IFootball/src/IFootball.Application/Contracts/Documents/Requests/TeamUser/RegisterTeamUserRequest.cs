namespace IFootball.Application.Contracts.Documents.Requests;

public class RegisterTeamUserRequest
{
    public long? IdGoalkeeper { get; set; }
    public long? IdLinePlayerFour { get; set; }
    public long? IdLinePlayerThree { get; set; }
    public long? IdLinePlayerOne { get; set; }
    public long? IdLinePlayerTwo { get; set; }
    public long? IdReservePlayerOne { get; set; }
    public long? IdReservePlayerTwo { get; set; }
    public long? IdCaptain { get; set; }
}