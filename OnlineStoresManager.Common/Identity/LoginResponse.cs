namespace OnlineStoresManager.Identity
{
    public class LoginResponse
    {
        public bool IsSuccess => !string.IsNullOrEmpty(Token);
        public string? Token { get; set; }
    }
}
