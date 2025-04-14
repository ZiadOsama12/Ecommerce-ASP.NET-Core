using Microsoft.AspNetCore.Identity;
using Shared.DTOs;

namespace Api.Services.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<TokenDto> CreateToken(bool populateExp);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
        //Task<TokenDto> RefreshToken(TokenDto tokenDto);

    }
}
