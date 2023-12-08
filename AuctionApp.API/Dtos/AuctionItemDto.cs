namespace AuctionApp.API.Dtos
{
    public sealed record AuctionItemDto
    {
        public string Title { get; init; }
        public double InitialBid { get; init; }
        public string Description { get; init; }
        public double HighestBid { get; init; }
        public DateTime EndDate { get; init; }
    }
}
