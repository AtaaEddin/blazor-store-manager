using Microsoft.AspNetCore.Mvc;

namespace OnlineStoresManager.API.Controllers
{
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IdentityService _identityService;

        public IdentityController(IdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("api/identity/login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            LoginResponse response = await _identityService.Login(request);

            return Ok(response);
        }
    }
}
