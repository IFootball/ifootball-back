namespace IFootball.Application.Contracts.Documents.Requests;

public class EditUserRequest
{
    public string Name { get; set; }
    public string NewPassword { get; set; }
    public string OldPassword { get; set; }
}

