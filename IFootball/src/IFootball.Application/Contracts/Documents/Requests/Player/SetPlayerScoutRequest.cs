
using IFootball.Domain.Models.enums;

namespace IFootball.Application.Contracts.Documents.Requests.Player
{
    public class SetPlayerScoutRequest
    {
        public int? Goals { get; set; }
        public int? Assists { get; set; }
        public int? YellowCard { get; set; }
        public int? RedCard { get; set; }
        public int? Fouls { get; set; }
        public int? Wins { get; set; }
        public int? TakenGols { get; set; }
        public int? PenaltySaves { get; set; }
        public int? Saves { get; set; }
    }
}
