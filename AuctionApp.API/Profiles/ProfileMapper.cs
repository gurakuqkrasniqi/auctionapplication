using AuctionApp.API.Dtos;
using AuctionApp.Domain.Users;
using AutoMapper;

namespace AuctionApp.API.Mapster
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<CreateUserDto, ApplicationUser>().ReverseMap();
        }
    }
}
