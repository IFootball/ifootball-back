﻿using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Contracts.Services;
using IFootball.Application.Implementations.Mappers;
using IFootball.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace IFootball.Application.Implementations.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;
        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }
        //[Authorize]
        public async Task<RegisterClassResponse> RegisterAsync(RegisterClassRequest resgiterClassRequest)
        {
            if (string.IsNullOrEmpty(resgiterClassRequest.Name))
                return new RegisterClassResponse(HttpStatusCode.BadRequest, "O nome da turma deve ser preenchido!");

            var found = await _classRepository.ClassExists(resgiterClassRequest.Name);

            if (found)
                return new RegisterClassResponse(HttpStatusCode.Conflict, "Já existe uma turma com este nome!");

            var newClass = resgiterClassRequest.toClass();
            await _classRepository.CreateClassAsync(newClass);
            return new RegisterClassResponse(newClass.toClassDto());
        }

    }
}