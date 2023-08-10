using IFootball.Domain.Models.enums;

namespace IFootball.Application.Contracts.Documents.Requests;

public class RegisterPlayerRequest
{
    public long IdGender { get; set; }
    public long IdTeamClass { get; set; }

    public string Name { get; set; }
    public string? Image { get; set; }
    public PlayerType PlayerType { get; set; }
}