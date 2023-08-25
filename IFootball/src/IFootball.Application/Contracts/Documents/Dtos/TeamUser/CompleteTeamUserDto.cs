using IFootball.Domain.Models.enums;

namespace IFootball.Application.Contracts.Documents.Dtos;

public class CompleteTeamUserDto
{
    public GenderName Gender { get; set; }
    public long IdCaptain { get; set; }
    public TeamUserPlayerDto Goalkeeper { get; set; }
    public TeamUserPlayerDto LinePlayerOne { get; set; }
    public TeamUserPlayerDto LinePlayerTwo { get; set; }
    public TeamUserPlayerDto LinePlayerThree { get; set; }
    public TeamUserPlayerDto LinePlayerFour { get; set; }
    public TeamUserPlayerDto ReservePlayerOne { get; set; }
    public TeamUserPlayerDto ReservePlayerTwo { get; set; }
}