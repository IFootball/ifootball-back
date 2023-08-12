using IFootball.Application.Contracts.Documents.Requests.StartDate;
using IFootball.Application.Contracts.Documents.Responses.StartDate;
using IFootball.Application.Contracts.Services;
using IFootball.Application.Implementations.Mappers.StartDateMappers;
using IFootball.Domain.Contracts.Repositories;

namespace IFootball.Application.Implementations.Services;

public class StartDateService : IStartDateService
{
    private readonly IStartDateRepository _startDateRepository;

    public StartDateService(IStartDateRepository startDateRepository)
    {
        _startDateRepository = startDateRepository;
    }

    public async Task<EditStartDateResponse> EditStartDate(EditStartDateRequest request)
    {
        var startDate = await _startDateRepository.FindStarDate();
        
        if (startDate is null)
        {
            startDate = request.ToStartDate();
            await _startDateRepository.Register(startDate);
        }
        else
        {
            startDate.StartDateOfMatches = request.StartDateOfMatches;
            await _startDateRepository.Edit(request.ToStartDate());
        }
        
        return new EditStartDateResponse(startDate.ToStartDateDto());
    }
}