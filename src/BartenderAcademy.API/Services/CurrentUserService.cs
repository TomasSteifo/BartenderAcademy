using System.Security.Claims;
using BartenderAcademy.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace BartenderAcademy.API.Services
{
    /// <summary>
    /// A simple implementation of ICurrentUserService that reads
    /// the current user’s ID and email from HttpContext.User claims.
    /// </summary>
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId
        {
            get
            {
                // “sub” or ClaimTypes.NameIdentifier is typically used for the user ID
                return _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                       ?? string.Empty;
            }
        }

        public string? Email
        {
            get
            {
                return _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;
            }
        }
    }
}
