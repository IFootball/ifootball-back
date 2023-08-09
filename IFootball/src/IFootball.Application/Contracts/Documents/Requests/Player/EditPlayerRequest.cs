namespace IFootball.Application.Contracts.Documents.Requests;

public class EditPlayerRequest
{
    public long IdGender { get; set; }
    public long IdTeamClass { get; set; }
    
    public string Name { get; set; }
    public string? Image { get; set; }
}