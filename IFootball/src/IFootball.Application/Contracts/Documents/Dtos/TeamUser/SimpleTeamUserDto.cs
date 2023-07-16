namespace IFootball.Application.Contracts.Documents.Dtos;

public class SimpleTeamUserDto
{
    public long IdUser { get; set; }
    public long? IdCaptain { get; set; }
    public long IdGender { get; set; }
    public long IdGoalkeeper { get; set; }
    public long IdLinePlayerFront { get; set; }
    public long IdLinePlayerMiddle { get; set; }
    public long IdLinePlayerBackRight { get; set; }
    public long IdLinePlayerBackLeft { get; set; }
    public long? IdReservePlayerOne { get; set; }
    public long? IdReservePlayerTwo { get; set; }
}