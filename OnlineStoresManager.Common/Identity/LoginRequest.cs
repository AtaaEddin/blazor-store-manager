using System.ComponentModel.DataAnnotations;

namespace OnlineStoresManager.Identity
{
    public class LoginRequest
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
