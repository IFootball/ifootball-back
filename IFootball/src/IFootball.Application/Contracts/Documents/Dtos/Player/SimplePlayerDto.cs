using IFootball.Domain.Models.enums;

namespace IFootball.Application.Contracts.Documents.Dtos;

public class SimplePlayerDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public long IdTeamClass { get; set; }
    public long IdGender { get; set; }
    public PlayerType PlayerType { get; set; }
}