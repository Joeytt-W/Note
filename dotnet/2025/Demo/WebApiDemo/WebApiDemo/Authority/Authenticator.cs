using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace WebApiDemo.Authority
{
    public static class Authenticator
    {
        public static bool Authenticate(string clientId, string secret)
        {
            var app = AppRepository.GetByClientId(clientId);
            if (app == null) return false;

            return app.ClientId == clientId && app.Secret == secret;
        }

        public static string CreateTOken(string clientId, DateTime expiresIn,string securityKey)
        {
            //安全算法 Algo
            //Signing key
            var signingCredential = new SigningCredentials(
                new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(securityKey)), SecurityAlgorithms.HmacSha256Signature);

            //Payload(claims) 负载
            var app = AppRepository.GetByClientId(clientId);
            var claims = new Dictionary<string, object>
            {
                { "AppName", app?.AppName ?? string.Empty}
            };

            var scopes = app?.Scopes?.Split(',') ?? Array.Empty<string>();
            if(scopes.Length > 0)
            {
                foreach (var scope in scopes)
                {
                    claims.Add(scope.Trim().ToLower(), "true");
                }
            }

            var tokenDescripter = new SecurityTokenDescriptor
            {
                SigningCredentials = signingCredential,
                Claims = claims,
                Expires = expiresIn,
                NotBefore = DateTime.UtcNow
            };
            var tokenHandler = new JsonWebTokenHandler();
            return tokenHandler.CreateToken(tokenDescripter);
        }

        /// <summary>
        /// Asynchronously verifies the validity of a JSON Web Token (JWT) using the specified security key.
        /// </summary>
        /// <remarks>The method checks the token's signature and expiration, but does not validate the
        /// issuer or audience. Returns <see langword="false"/> if the token is malformed, expired, has an invalid
        /// signature, or if either parameter is null or whitespace.</remarks>
        /// <param name="tokenString">The JWT string to validate. Cannot be null, empty, or whitespace.</param>
        /// <param name="securityKey">The symmetric security key used to validate the token's signature. Cannot be null, empty, or whitespace.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is <see langword="true"/> if the token is
        /// valid and not expired; otherwise, <see langword="false"/>.</returns>
        public static async Task<IEnumerable<Claim>?> VerifyTokenAsync(string tokenString, string securityKey)
        {
            if(string.IsNullOrWhiteSpace(tokenString) || string.IsNullOrWhiteSpace(securityKey))
            {
                return null;
            }

            var keyBytes = Encoding.UTF8.GetBytes(securityKey);
            var tokenHandler = new JsonWebTokenHandler();

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero // No clock skew
            };

            try
            {
                var result = await tokenHandler.ValidateTokenAsync(tokenString, validationParameters);

                if (result.SecurityToken != null)
                {
                    var tokenObj = tokenHandler.ReadJsonWebToken(tokenString);
                    return tokenObj.Claims ?? Enumerable.Empty<Claim>();
                }
                else
                {
                    return null;
                }
            }
            catch (SecurityTokenMalformedException)
            {
                return null;
            }
            catch (SecurityTokenExpiredException)
            {
                return null;
            }
            catch (SecurityTokenInvalidSignatureException)
            {
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
