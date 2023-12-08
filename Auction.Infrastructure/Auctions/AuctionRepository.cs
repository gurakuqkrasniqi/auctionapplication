using AuctionApp.Domain.Auction;
using AuctionApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Infrastructure.Auctions
{
    public class AuctionRepository : GenericRepository<Auction>
    {
        public AuctionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
