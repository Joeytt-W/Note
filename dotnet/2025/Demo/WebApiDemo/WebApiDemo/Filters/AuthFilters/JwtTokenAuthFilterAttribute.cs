using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using WebApiDemo.Attributes;
using WebApiDemo.Authority;

namespace WebApiDemo.Filters.AuthFilters
{
    public class JwtTokenAuthFilterAttribute : Attribute, IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            //1. Get Authorization header from the request
            //var authHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out var authHeaderValue))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            string tokenString = authHeaderValue.ToString();
            //2.Get rid of the Bearer prefix
            if (tokenString.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                tokenString = tokenString.Substring("Bearer ".Length).Trim();
            }
            else
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            //3. Get Configuration and the Secret Key
            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var securityKey = configuration?["SecurityKey"] ?? string.Empty;

            //4. Verify the token and extract claims
            //var tokenHandler = new Microsoft.IdentityModel.JsonWebTokens.JsonWebTokenHandler();
            //if (await Authenticator.VerifyTokenAsync(tokenString, securityKey))
            //{
            //    // Token is valid, continue with the request
            //    return;
            //}
            //else
            //{
            //    context.Result = new UnauthorizedResult();
            //    return;
            //}
            var claims = await Authenticator.VerifyTokenAsync(tokenString, securityKey);
            if(claims == null)
            {
                context.Result = new UnauthorizedResult();// 401 Unauthorized
                return;
            }
            else
            {
                var requiredClaims = context.ActionDescriptor.EndpointMetadata.OfType<RequiredClaimAttribute>().ToList();

                if(requiredClaims != null && !requiredClaims.All(rc => claims.Any(c => 
                    string.Equals(c.Type, rc.ClaimType, StringComparison.OrdinalIgnoreCase) 
                                   && string.Equals(c.Value, rc.ClaimValue, StringComparison.OrdinalIgnoreCase))))
                {
                    context.Result = new StatusCodeResult(403); // 403 Forbidden
                }
            }
        }
    }
}
