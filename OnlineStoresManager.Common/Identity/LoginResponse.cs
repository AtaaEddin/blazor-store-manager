using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoresManager.Common.Identity
{
    public class LoginResponse
    {
        public bool IsSuccess => !string.IsNullOrEmpty(Token);
        public string? Token { get; set; }
    }
}
