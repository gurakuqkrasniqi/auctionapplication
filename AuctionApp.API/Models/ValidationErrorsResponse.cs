namespace AuctionApp.API.Models
{
    public sealed record ValidationErrorsResponse
    {
        public IReadOnlyCollection<string> Messages { get; init; } = null!;
    }
}
