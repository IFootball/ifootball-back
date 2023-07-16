using System.Net;
using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Contracts.Services;
using IFootball.Application.Implementations.Mappers;
using IFootball.Domain.Contracts.Repositories;
using IFootball.Domain.Models;

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
        var teamClassExists = await _teamClassRepository.ExistsTeamClassById(request.IdTeamClass);
        if (!teamClassExists)
            return new RegisterGoalkeeperResponse(HttpStatusCode.NotFound, "O time inserido não existe");

        var genderExists = await _genderRepository.ExistsGenderById(request.IdGender);
        if(!genderExists)
            return new RegisterGoalkeeperResponse(HttpStatusCode.NotFound, "O genêro inserido não existe");

        var goalkeeper = request.ToGoalkeeper();
        await _goalkeeperRepository.CreateGoalkeeper(goalkeeper);
        return new RegisterGoalkeeperResponse(goalkeeper.ToGoalkeeperDto());
    }
}