using IFootball.Application.Contracts.Documents.Requests.StartDate;
using IFootball.Application.Contracts.Documents.Responses.StartDate;

namespace IFootball.Application.Contracts.Services;

public interface IStartDateService
{
    Task<EditStartDateResponse> EditStartDate(EditStartDateRequest request);

    Task<GetStartDateResponse> GetStartDate();
}