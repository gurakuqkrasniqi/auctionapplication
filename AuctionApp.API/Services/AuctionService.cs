using AuctionApp.API.Dtos;
using AuctionApp.API.Services.Interfaces;
using AuctionApp.Business.Enums;
using AuctionApp.Domain.Auction;
using AuctionApp.Domain.Users;
using AutoMapper;

namespace AuctionApp.API.Services
{
    public class AuctionService : IAuctionService
    {
        public readonly IAuctionRepository _auctionRepository;
        public readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;
        public AuctionService(IAuctionRepository auctionRepository, IMapper mapper, IUserRepository userRepository)
        {
            _auctionRepository = auctionRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<AuctionItemDto> AuctionBid(int userId, int auctionId, double amount)
        {
            var auction = await _auctionRepository.FindAsync(x => x.Id == auctionId);
            var user = await _userRepository.FindAsync(x => x.Id == userId);
            if (auction == null || user == null)
            {
                return null;
            }

            if (!IsValidBid(auction, user, amount))
            {
                return null;
            }

            UpdateAuctionWithBid(auction, userId, amount);

            return _mapper.Map<AuctionItemDto>(auction);
        }

        private void UpdateAuctionWithBid(Auction auction, int userId, double amount)
        {
            auction.BidderId = userId;
            auction.HighestBid = amount;
            _auctionRepository.Update(auction);
        }

        private bool IsValidBid(Auction auction, User user, double amount)
        {
            return auction.InitialBid < amount
                && user.Amount >= amount
                && user.Id != auction.UserId;
        }

        public async Task CompleteAuctions()
        {
            throw new NotImplementedException();
        }

        public async Task<AuctionItemDto> CreateAuction(CreateAuctionDto createAuctionDto)
        {
            var mappedAuction = _mapper.Map<Auction>(createAuctionDto);
            mappedAuction.Status = (int)AuctionStatus.Created;
            await _auctionRepository.AddAsync(mappedAuction);
            return _mapper.Map<AuctionItemDto>(mappedAuction);
        }

        public void DeleteAuction(int id)
        {
            _auctionRepository.Delete(id);
        }

        public async Task<List<AuctionItemDto>> GetAllAuctions()
        {
            var auction = await _auctionRepository.FindListAsync(x => x.EndDate > DateTime.UtcNow);
            return _mapper.Map<List<AuctionItemDto>>(auction);
        }

        public async Task<AuctionItemDto> GetAuctionById(int auctionId)
        {
            var auction = await _auctionRepository.FindAsync(x => x.Id > auctionId);
            return _mapper.Map<AuctionItemDto>(auction);
        }

        public async Task<List<AuctionItemDto>> GetUserAuctions(int userId)
        {
            var auction = await _auctionRepository.FindListAsync(x => x.UserId == userId);
            return _mapper.Map<List<AuctionItemDto>>(auction);
        }
    }
}
