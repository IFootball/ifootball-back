using System.Net;
using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Contracts.Services;
using IFootball.Application.Implementations.Mappers;
using IFootball.Domain.Contracts.Repositories;

namespace IFootball.Application.Implementations.Services;

public class GoalkeeperService : IGoalkeeperService
{
    private readonly IGoalkeeperRepository _goalkeeperRepository;
    private readonly ITeamClassRepository _teamClassRepository;
    private readonly IGenderRepository _genderRepository;

    public GoalkeeperService(IGoalkeeperRepository goalkeeperRepository, ITeamClassRepository teamClassRepository, IGenderRepository genderRepository)
    {
        _goalkeeperRepository = goalkeeperRepository;
        _teamClassRepository = teamClassRepository;
        _genderRepository = genderRepository;
    }

    public async Task<RegisterGoalkeeperResponse> RegisterAsync(RegisterGoalkeeperRequest request)
    {
        var teamClass = await _teamClassRepository.FindById(request.IdTeamClass);
        if (teamClass is null)
            return new RegisterGoalkeeperResponse(HttpStatusCode.NotFound, "O time inserido não existe");

        if(teamClass.IdGender != request.IdGender)
            return new RegisterGoalkeeperResponse(HttpStatusCode.UnprocessableEntity, "O goleiro deve ser do genêro do time");
        
        var genderExists = await _genderRepository.ExistsGenderById(request.IdGender);
        if(!genderExists)
            return new RegisterGoalkeeperResponse(HttpStatusCode.NotFound, "O genêro inserido não existe");

        var goalkeeper = request.ToGoalkeeper();
        await _goalkeeperRepository.CreateGoalkeeper(goalkeeper);
        return new RegisterGoalkeeperResponse(goalkeeper.ToGoalkeeperDto());
    }

    public async Task<EditGoalkeeperResponse> EditAsync(long idGoalkeeper, EditGoalkeeperRequest request)
    {
        var goalkeeper = await _goalkeeperRepository.FindById(idGoalkeeper);
        if(goalkeeper is null)
            return new EditGoalkeeperResponse(HttpStatusCode.NotFound, "O goleiro inserido não existe");
        
        var teamClass = await _teamClassRepository.FindById(request.IdTeamClass);
        if (teamClass is null)
            return new EditGoalkeeperResponse(HttpStatusCode.NotFound, "O time inserido não existe");

        if(teamClass.IdGender != request.IdGender)
            return new EditGoalkeeperResponse(HttpStatusCode.UnprocessableEntity, "O goleiro deve ser do genêro do time");

        var genderExists = await _genderRepository.ExistsGenderById(request.IdGender);
        if(!genderExists)
            return new EditGoalkeeperResponse(HttpStatusCode.NotFound, "O genêro inserido não existe");

        goalkeeper.Edit(request.IdGender,request.IdTeamClass,request.Image, request.Image);
        await _goalkeeperRepository.EditGoalkeeper(goalkeeper);
        return new EditGoalkeeperResponse(goalkeeper.ToGoalkeeperDto());
    }

    public async Task<GetGoalkeeperResponse> GetAsync(long idGoalkeeper)
    {
        var goalkeeper = await _goalkeeperRepository.FindById(idGoalkeeper);
        if(goalkeeper is null)
            return new GetGoalkeeperResponse(HttpStatusCode.NotFound, "O goleiro inserido não existe");
        
        return new GetGoalkeeperResponse(goalkeeper.ToGoalkeeperDto());
    }

    public async Task<DeleteGoalkeeperResponse> DeleteAsync(long idGoalkeeper)
    {
        var goalkeeper = await _goalkeeperRepository.FindById(idGoalkeeper);
        if(goalkeeper is null)
            return new DeleteGoalkeeperResponse(HttpStatusCode.NotFound, "O goleiro inserido não existe");

        await _goalkeeperRepository.DeleteGoalkeeper(goalkeeper);
        return new DeleteGoalkeeperResponse();
    }
}