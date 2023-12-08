namespace AuctionApp.API.Dtos
{
    public sealed record LoginDto
    {
        public string Username { get; init; } = null!;
        public string Password { get; set; } = null!;
    }
}
