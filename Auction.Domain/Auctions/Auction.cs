using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Domain.Auction
{
    public class Auction
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double InitialBid { get; set; }
        public string Description { get; set; }
        public int? BidderId { get; set; }
        public int UserId { get; set; }
        public DateTime EndDate { get; set; }
        public double HighestBid { get; set; }
        public int Status { get; set; }
    }
}
