using IFootball.Application.Contracts.Documents.Dtos;
using System.Net;

namespace IFootball.Application.Contracts.Documents.Responses.Player
{
    public class SetPlayerScoutResponse : BaseResponse
    {
        public CompletePlayerDto? Player { get; set; }
        public SetPlayerScoutResponse(CompletePlayerDto player) 
        {
            Player = player;
        }
        public SetPlayerScoutResponse(HttpStatusCode statusCode, string? message) : base(new ErrorResponse(statusCode, message)) { }
    }
}
