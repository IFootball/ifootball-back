
using IFootball.Application.Contracts.Services.Core;
using Microsoft.AspNetCore.Http;

namespace IFootball.Application.Implementations.Services.Core
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAcessor;
        public CurrentUserService( IHttpContextAccessor httpcontextAccessor)
        {
            _httpContextAcessor = httpcontextAccessor;
        }
        public long GetCurrentUserId()
        {
            return long.Parse(_httpContextAcessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Id")).Value);
        }
    }
}
