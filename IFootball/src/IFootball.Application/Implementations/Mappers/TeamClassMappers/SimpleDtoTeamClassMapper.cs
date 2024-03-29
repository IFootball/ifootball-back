﻿using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Application.Contracts.Documents.Dtos.TeamClass;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers;

public static class SimpleDtoTeamClassMapper
{
    public static SimpleTeamClassDto ToSimpleTeamClassDto(this TeamClass teamClass)
    {
        return new SimpleTeamClassDto
        {
            Id = teamClass.Id,
            IdGender = teamClass.IdGender,
            IdClass = teamClass.IdClass,
            ClassName = teamClass.Class.Name
        };
    }
}