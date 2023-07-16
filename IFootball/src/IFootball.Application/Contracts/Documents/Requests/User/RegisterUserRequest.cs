namespace IFootball.Application.Contracts.Documents.Requests
{
    public class RegisterUserRequest
    {
        public long IdClass { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
