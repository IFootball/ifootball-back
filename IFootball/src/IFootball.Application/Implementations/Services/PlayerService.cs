﻿using System.Net;
using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Contracts.Services;
using IFootball.Application.Implementations.Mappers;
using IFootball.Domain.Contracts.Repositories;
using IFootball.Domain.Models;
using IFootball.Domain.Models.enums;

namespace IFootball.Application.Implementations.Services;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IGoalkeeperRepository _goalkeeperRepository;
    private readonly ITeamClassRepository _teamClassRepository;
    private readonly IGenderRepository _genderRepository;

    public PlayerService(IPlayerRepository linePlayerRepository, ITeamClassRepository teamClassRepository, IGenderRepository genderRepository, IGoalkeeperRepository goalkeeperRepository)
    {
        _playerRepository = linePlayerRepository;
        _teamClassRepository = teamClassRepository;
        _genderRepository = genderRepository;
        _goalkeeperRepository = goalkeeperRepository;
    }

    public async Task<RegisterPlayerResponse> RegisterAsync(RegisterPlayerRequest request)
    {
        var teamClass = await _teamClassRepository.FindById(request.IdTeamClass);
        if (teamClass is null)
            return new RegisterPlayerResponse(HttpStatusCode.NotFound, "O time inserido não existe");

        if(teamClass.IdGender != request.IdGender)
            return new RegisterPlayerResponse(HttpStatusCode.UnprocessableEntity, "O jogador deve ser do genêro do time");

        var genderExists = await _genderRepository.ExistsGenderById(request.IdGender);
        if(!genderExists)
            return new RegisterPlayerResponse(HttpStatusCode.NotFound, "O genêro inserido não existe");
        
        var player = request.ToPlayer();
        await _playerRepository.CreatePlayer(player);

        if (request.PlayerType.Equals(PlayerType.Goalkeeper))
        {
            await _goalkeeperRepository.CreateGoalkeeper(new Goalkeeper(player.Id));
        }

        return new RegisterPlayerResponse(player.ToSimplePlayerDto());    
    }

    public async Task<EditPlayerResponse> EditAsync(long idPlayer, EditPlayerRequest request)
    {
        var player = await _playerRepository.FindById(idPlayer);
        if(player is null)
            return new EditPlayerResponse(HttpStatusCode.NotFound, "O jogador inserido não existe");

        var teamClass = await _teamClassRepository.FindById(request.IdTeamClass);
        if (teamClass is null)
            return new EditPlayerResponse(HttpStatusCode.NotFound, "O time inserido não existe");

        if(teamClass.IdGender != request.IdGender)
            return new EditPlayerResponse(HttpStatusCode.UnprocessableEntity, "O jogador deve ser do genêro do time");

        var genderExists = await _genderRepository.ExistsGenderById(request.IdGender);
        if(!genderExists)
            return new EditPlayerResponse(HttpStatusCode.NotFound, "O genêro inserido não existe");

        player.Edit(request.IdGender, request.IdTeamClass, request.Name, request.Image);
        await _playerRepository.EditPlayer(player);
        return new EditPlayerResponse(player.ToSimplePlayerDto());      
    }

    public async Task<GetPlayerResponse> GetAsync(long idLinePlayer)
    {
        var player = await _playerRepository.FindById(idLinePlayer);
        if(player is null)
            return new GetPlayerResponse(HttpStatusCode.NotFound, "O jogador inserido não existe");

        return new GetPlayerResponse(player.ToCompletePlayerDto());
    }

    public async Task<DeleteLinePlayerResponse> DeleteAsync(long idLinePlayer)
    {
        var linePlayer = await _playerRepository.FindById(idLinePlayer);
        if(linePlayer is null)
            return new DeleteLinePlayerResponse(HttpStatusCode.NotFound, "O jogador inserido não existe");

        await _playerRepository.DeletePlayer(linePlayer);
        return new DeleteLinePlayerResponse();
    }
}