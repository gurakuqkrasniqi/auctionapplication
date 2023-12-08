namespace AuctionApp.API.Dtos
{
    public sealed record CreateUserDto
    {
        public string FirstName { get; init; } = null!;
        public string LastName { get; init; } = null!;
        public string Username { get; init; } = null!;
        public string Password { get; init; } = null!;
    }
}
