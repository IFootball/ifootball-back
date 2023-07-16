using IFootball.Domain.Models.enums;

namespace IFootball.Application.Contracts.Documents.Dtos;

public class CompleteTeamUserDto
{
    public GenderName Gender { get; set; }
    public GenericPlayerDto Goalkeeper { get; set; }
    public GenericPlayerDto LinePlayerFront { get; set; }
    public GenericPlayerDto LinePlayerMiddle { get; set; }
    public GenericPlayerDto LinePlayerBackRight { get; set; }
    public GenericPlayerDto LinePlayerBackLeft { get; set; }
    public GenericPlayerDto ReservePlayerOne { get; set; }
    public GenericPlayerDto ReservePlayerTwo { get; set; }
}