﻿using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;

namespace IFootball.Application.Contracts.Services;

public interface IPlayerService
{
    Task<RegisterPlayerResponse> RegisterAsync(RegisterPlayerRequest request);
    Task<EditPlayerResponse> EditAsync(long idLinePlayer, EditPlayerRequest request);
    Task<GetLinePlayerResponse> GetAsync(long idLinePlayer);
    Task<DeletePlayerResponse> DeleteAsync(long idLinePlayer);

}