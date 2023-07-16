using System.Net;
using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Contracts.Services;
using IFootball.Application.Implementations.Mappers;
using IFootball.Domain.Contracts.Repositories;

namespace IFootball.Application.Implementations.Services;

public class LinePlayerService : ILinePlayerService
{
    private readonly ILinePlayerRepository _linePlayerRepository;
    private readonly ITeamClassRepository _teamClassRepository;
    private readonly IGenderRepository _genderRepository;

    public LinePlayerService(ILinePlayerRepository linePlayerRepository, ITeamClassRepository teamClassRepository, IGenderRepository genderRepository)
    {
        _linePlayerRepository = linePlayerRepository;
        _teamClassRepository = teamClassRepository;
        _genderRepository = genderRepository;
    }

    public async Task<RegisterLinePlayerResponse> RegisterAsync(RegisterLinePlayerRequest request)
    {
        var teamClassExists = await _teamClassRepository.ExistsTeamClassById(request.IdTeamClass);
        if (!teamClassExists)
            return new RegisterLinePlayerResponse(HttpStatusCode.NotFound, "O time inserido não existe");

        var genderExists = await _genderRepository.ExistsGenderById(request.IdGender);
        if(!genderExists)
            return new RegisterLinePlayerResponse(HttpStatusCode.NotFound, "O genêro inserido não existe");
        
        var linePlayer = request.ToLinePlayer();
        await _linePlayerRepository.CreateLinePlayer(linePlayer);
        return new RegisterLinePlayerResponse(linePlayer.ToLinePlayerDto());    
    }
}