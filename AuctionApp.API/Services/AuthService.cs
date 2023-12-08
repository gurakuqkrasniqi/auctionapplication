using AuctionApp.API.Dtos;
using AuctionApp.API.Services.Interfaces;
using AuctionApp.Business;
using AuctionApp.Domain.Users;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private IMapper _mapper;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<string> Register(CreateUserDto createUserDto)
        {
            Check.IsNotNull(createUserDto);
            var user = _mapper.Map<ApplicationUser>(createUserDto);
            user.User = new User
            {

                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Username = createUserDto.Username,
                Password = createUserDto.Password,
                Amount = 1000
            };

            var result = await _userManager.CreateAsync(user, createUserDto.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }

            return createUserDto.Username;
        }

        public async Task<ApplicationUser> Login(LoginDto loginDto)
        {
            Check.IsNotNull(loginDto);

            var user = await _userManager.Users
                .Include(x => x.User)
                .Where(x => x.User.Username == loginDto.Username)
                .FirstOrDefaultAsync();
            var passwordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (user != null && passwordValid)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return user;
            }

            return null;
        }
    }
}
