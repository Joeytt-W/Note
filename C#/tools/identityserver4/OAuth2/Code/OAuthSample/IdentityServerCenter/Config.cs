using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Runtime.Intrinsics.Arm;

namespace IdentityServerCenter
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetResources()
        {
            return new List<ApiResource> 
            { 
                new ApiResource("api", "My Api")
                {
                    Scopes= new List<string> { "api"}
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username="test",
                    Password="123456"
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                //客户端模式
                new Client()
                {
                    ClientId="client",
                    AllowedGrantTypes=new string[]{ GrantType.ClientCredentials},
                    ClientSecrets = {new Secret("secret".Sha256()) },
                    AllowedScopes={"api"}
                },
                //用户密码
                new Client()
                {
                    ClientId="pwdClient",
                    AllowedGrantTypes=new string[]{ GrantType.ResourceOwnerPassword},
                    ClientSecrets = {new Secret("secret".Sha256()) },
                    AllowedScopes={"api"}
                }
            };
        }

        public static IEnumerable<ApiScope> GetScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope()
                {
                    Name="api"
                }
            };
        }
    }
}
