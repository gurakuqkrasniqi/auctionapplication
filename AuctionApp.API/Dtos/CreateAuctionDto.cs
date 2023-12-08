namespace AuctionApp.API.Dtos
{
    public sealed record CreateAuctionDto
    {
        public string Title { get; init; } = null!;
        public double InitialBid { get; init; }
        public string Description { get; init; } = null!;
        public int? BidderId { get; init; }
        public int UserId { get; init; }
        public DateTime EndDate { get; init; }
        public double HighestBid { get; init; }
    }
}
