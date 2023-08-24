using IFootball.Domain.Models.enums;

namespace IFootball.Application.Contracts.Documents.Dtos;

public class CompleteTeamUserDto
{
    public GenderName Gender { get; set; }
    public long IdCaptain { get; set; }
    public SimplePlayerDto Goalkeeper { get; set; }
    public SimplePlayerDto LinePlayerOne { get; set; }
    public SimplePlayerDto LinePlayerTwo { get; set; }
    public SimplePlayerDto LinePlayerThree { get; set; }
    public SimplePlayerDto LinePlayerFour { get; set; }
    public SimplePlayerDto ReservePlayerOne { get; set; }
    public SimplePlayerDto ReservePlayerTwo { get; set; }
}