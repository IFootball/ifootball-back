namespace IFootball.Application.Contracts.Documents.Requests;

public class EditUserRequest
{
    public long IdClass { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
}