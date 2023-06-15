using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFootball.Application.Contracts.Services
{
    public interface IUserService
    {
        Task<LoginUserResponse> AuthenticateAsync(LoginUserRequest loginUserRequest);
    }
}
