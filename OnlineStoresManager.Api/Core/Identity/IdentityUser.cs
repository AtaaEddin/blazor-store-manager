namespace OnlineStoresManager.API.Core.Identity
{
    internal class IdentityUser
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
