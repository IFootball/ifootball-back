﻿using System.Net;
using FluentValidation;
using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Application.Contracts.Documents.Dtos.TeamClass;
using IFootball.Application.Contracts.Documents.Requests.TeamClass;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Contracts.Documents.Responses.Player;
using IFootball.Application.Contracts.Services;
using IFootball.Application.Implementations.Mappers;
using IFootball.Application.Implementations.Mappers.TeamClassMappers;
using IFootball.Application.Implementations.Validators;
using IFootball.Domain.Contracts;
using IFootball.Domain.Contracts.Repositories;

namespace IFootball.Application.Implementations.Services;

public class TeamClassService : ITeamClassService
{
    private readonly ITeamClassRepository _teamClassRepository;
    private readonly IClassRepository _classRepository;
    private readonly IGenderRepository _genderRepository;
    private readonly IPlayerRepository _playerRepository;

    public TeamClassService(ITeamClassRepository teamClassRepository, IClassRepository classRepository, IGenderRepository genderRepository, IPlayerRepository playerRepository)
    {
        _teamClassRepository = teamClassRepository;
        _classRepository = classRepository;
        _genderRepository = genderRepository;
        _playerRepository = playerRepository;
    }

    public async Task<RegisterTeamClassResponse> RegisterAsync(RegisterTeamClassRequest request)
    {
        var genderExists = await _genderRepository.ExistsGenderById(request.IdGender);
        if(!genderExists)
            return new RegisterTeamClassResponse(HttpStatusCode.NotFound, "O genêro inserido não existe");

        var classExists = await _classRepository.ClassExistsById(request.IdClass);
        if(!classExists)
            return new RegisterTeamClassResponse(HttpStatusCode.NotFound, "A turma inserida não existe");

        var teamClass = request.ToTeamClass();
        await _teamClassRepository.Register(teamClass);
        return new RegisterTeamClassResponse(teamClass.ToCompleteTeamClassDto());
    }

    public async Task<DeleteTeamClassResponse> DeleteAsync(long idTeamClass)
    {
        var teamClass = await _teamClassRepository.FindById(idTeamClass);
        if(teamClass is null)
            return new DeleteTeamClassResponse(HttpStatusCode.NotFound, "O time  inserido não existe");

        await _teamClassRepository.Delete(teamClass);
        return new DeleteTeamClassResponse();
    }

    public async Task<EditTeamClassResponse> EditAsync(long idTeamClass, EditTeamClassRequest request)
    {
        var teamClass = await _teamClassRepository.FindById(idTeamClass);
        if(teamClass is null)
            return new EditTeamClassResponse(HttpStatusCode.NotFound, "O time  inserido não existe");
        
        var genderExists = await _genderRepository.ExistsGenderById(request.IdGender);
        if(!genderExists)
            return new EditTeamClassResponse(HttpStatusCode.NotFound, "O genêro inserido não existe");

        var classExists = await _classRepository.ClassExistsById(request.IdClass);
        if(!classExists)
            return new EditTeamClassResponse(HttpStatusCode.NotFound, "A turma inserida não existe");

        teamClass.Edit(request.IdGender, request.IdClass);
        await _teamClassRepository.Edit(teamClass);
        return new EditTeamClassResponse(teamClass.ToCompleteTeamClassDto());
    }

    public async Task<GetTeamClassResponse> GetAsync(long idTeamClass)
    {
        var teamClass = await _teamClassRepository.FindCompleteById(idTeamClass);
        if(teamClass is null)
            return new GetTeamClassResponse(HttpStatusCode.NotFound, "O time  inserido não existe");

        return new GetTeamClassResponse(teamClass.ToCompleteTeamClassDto());
    }

    public async Task<PagedResponse<SimpleTeamClassDto>> ListAsync(Pageable pageable)
    {
        var teamClasses = await _teamClassRepository.ListAsync(pageable);
        return teamClasses.Map(x => x.ToSimpleTeamClassDto());
    }

    public async Task<PagedResponse<TeamClassPlayerDto>> ListPlayersAsync(long idTeamClass, Pageable pageable)
    {
        var players = await _playerRepository.ListTeamClass(idTeamClass, pageable);
        return players.Map(x => x.ToTeamClassPlayerDto());
        
    }
}