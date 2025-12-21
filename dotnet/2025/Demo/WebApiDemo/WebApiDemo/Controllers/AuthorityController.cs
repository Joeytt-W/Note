using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApiDemo.Authority;

namespace WebApiDemo.Controllers
{
    [ApiController]
    public class AuthorityController:ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthorityController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("auth")]
        public IActionResult Authenticate([FromBody]AppCredential credential)
        {
            var isAuthenticated = Authenticator.Authenticate(credential.ClientId, credential.Secret);
            var expires_in = DateTime.UtcNow.AddMinutes(10);
            if (isAuthenticated)
            {
                return Ok(new
                {
                    access_token = Authenticator.CreateTOken(credential.ClientId, expires_in, _configuration["SecurityKey"] ?? string.Empty),
                    expires_in = expires_in
                });
            }
            else
            {
                ModelState.AddModelError("Unauthorized", "Invalid client credentials.");
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status401Unauthorized
                };
                return new UnauthorizedObjectResult(problemDetails);
            }
        }

        
    }
}
