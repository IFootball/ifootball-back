namespace IFootball.Application.Contracts.Documents.Dtos;

public class SimpleTeamUserDto
{
    public long IdUser { get; set; }
    public long IdCaptain { get; set; }
    public long IdGender { get; set; }
    public long IdGoalkeeper { get; set; }
    public long IdPlayerOne { get; set; }
    public long IdPlayerTwo { get; set; }
    public long IdPlayerThree { get; set; }
    public long IdPlayerFour { get; set; }
    public long IdReservePlayerOne { get; set; }
    public long IdReservePlayerTwo { get; set; }
}