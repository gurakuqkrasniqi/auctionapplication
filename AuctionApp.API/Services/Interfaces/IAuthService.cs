using AuctionApp.API.Dtos;
using AuctionApp.Domain.Users;

namespace AuctionApp.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ApplicationUser> Login(LoginDto loginDto);

        Task<string> Register(CreateUserDto createUserDto);
    }
}
