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
        var teamClass = await _teamClassRepository.FindById(request.IdTeamClass);
        if (teamClass is null)
            return new RegisterLinePlayerResponse(HttpStatusCode.NotFound, "O time inserido não existe");

        if(teamClass.IdGender != request.IdGender)
            return new RegisterLinePlayerResponse(HttpStatusCode.UnprocessableEntity, "O jogador deve ser do genêro do time");

        var genderExists = await _genderRepository.ExistsGenderById(request.IdGender);
        if(!genderExists)
            return new RegisterLinePlayerResponse(HttpStatusCode.NotFound, "O genêro inserido não existe");
        
        var linePlayer = request.ToLinePlayer();
        await _linePlayerRepository.CreateLinePlayer(linePlayer);
        return new RegisterLinePlayerResponse(linePlayer.ToLinePlayerDto());    
    }

    public async Task<EditLinePlayerResponse> EditAsync(long idLinePlayer, EditLinePlayerRequest request)
    {
        var linePlayer = await _linePlayerRepository.FindById(idLinePlayer);
        if(linePlayer is null)
            return new EditLinePlayerResponse(HttpStatusCode.NotFound, "O jogador inserido não existe");

        var teamClass = await _teamClassRepository.FindById(request.IdTeamClass);
        if (teamClass is null)
            return new EditLinePlayerResponse(HttpStatusCode.NotFound, "O time inserido não existe");

        if(teamClass.IdGender != request.IdGender)
            return new EditLinePlayerResponse(HttpStatusCode.UnprocessableEntity, "O jogador deve ser do genêro do time");

        var genderExists = await _genderRepository.ExistsGenderById(request.IdGender);
        if(!genderExists)
            return new EditLinePlayerResponse(HttpStatusCode.NotFound, "O genêro inserido não existe");
        
        linePlayer.Edit(request.IdGender, request.IdTeamClass, request.Name, request.Image);
        await _linePlayerRepository.EditLinePlayer(linePlayer);
        return new EditLinePlayerResponse(linePlayer.ToLinePlayerDto());      
    }

    public async Task<GetLinePlayerResponse> GetAsync(long idLinePlayer)
    {
        var linePlayer = await _linePlayerRepository.FindById(idLinePlayer);
        if(linePlayer is null)
            return new GetLinePlayerResponse(HttpStatusCode.NotFound, "O jogador inserido não existe");

        return new GetLinePlayerResponse(linePlayer.ToLinePlayerDto());
    }

    public async Task<DeleteLinePlayerResponse> DeleteAsync(long idLinePlayer)
    {
        var linePlayer = await _linePlayerRepository.FindById(idLinePlayer);
        if(linePlayer is null)
            return new DeleteLinePlayerResponse(HttpStatusCode.NotFound, "O jogador inserido não existe");

        await _linePlayerRepository.DeleteLinePlayer(linePlayer);
        return new DeleteLinePlayerResponse();
    }
}