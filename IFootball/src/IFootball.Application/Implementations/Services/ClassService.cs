using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Contracts.Services;
using IFootball.Application.Contracts.Services.Core;
using IFootball.Application.Implementations.Mappers;
using IFootball.Application.Implementations.Validators;
using IFootball.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Http;
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

        public async Task<RegisterClassResponse> RegisterAsync(RegisterClassRequest request)
        {
            var validationDto = new RegisterClassRequestValidator().Validate(request);
            if(!validationDto.IsValid)
                return new RegisterClassResponse(HttpStatusCode.BadRequest, validationDto.Errors.Select(e => e.ErrorMessage).FirstOrDefault());

            var found = await _classRepository.ClassExistsByName(request.Name);

            if (found)
                return new RegisterClassResponse(HttpStatusCode.Conflict, "Já existe uma turma com este nome!");

            var newClass = request.ToClass();
            await _classRepository.CreateClassAsync(newClass);
            return new RegisterClassResponse(newClass.ToClassDto());
        }

        public async Task<IEnumerable<ClassDto>> ListAsync()
        {
            var classes = await _classRepository.GetAllAsync();

            return classes.Select(x => x.ToClassDto());
        }
    }
}
