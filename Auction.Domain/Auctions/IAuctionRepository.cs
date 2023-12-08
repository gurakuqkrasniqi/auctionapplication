using AuctionApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Domain.Auction
{
    public interface IAuctionRepository : IGenericRepository<Auction>
    {
        Task<List<Auction>> GetAllAuctions();
        Task<List<Auction>> GetUserAuctions(int id);
    }
}
