using L2code.Domain.Models;
using L2code.Domain.Responses;

namespace L2code.Domain.Interfaces
{
    public interface IAuthenticationService
    {
        TokenResponse GenerateToken(User user);
    }
}