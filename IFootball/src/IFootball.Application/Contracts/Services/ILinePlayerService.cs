﻿using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;

namespace IFootball.Application.Contracts.Services;

public interface ILinePlayerService
{
    Task<RegisterLinePlayerResponse> RegisterAsync(RegisterLinePlayerRequest request);
    Task<DeleteLinePlayerResponse> DeleteAsync(long idLinePlayer);

}