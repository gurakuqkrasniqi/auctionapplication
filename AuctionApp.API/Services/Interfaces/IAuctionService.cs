using AuctionApp.API.Dtos;
using AuctionApp.Domain.Auction;

namespace AuctionApp.API.Services.Interfaces
{
    public interface IAuctionService
    {
        Task<AuctionItemDto> CreateAuction(CreateAuctionDto createAuctionDto);
        Task<AuctionItemDto> AuctionBid(int userId, int auctionId, double amount);
        Task<List<AuctionItemDto>> GetAllAuctions();
        Task<AuctionItemDto> GetAuctionById(int id);
        Task<List<AuctionItemDto>> GetUserAuctions(int id);
        Task CompleteAuctions();
        void DeleteAuction(int id);
    }
}
