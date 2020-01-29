using System.Collections.Generic;
using Codescu.IDP.Admin.Configuration.Identity;

namespace Codescu.IDP.Admin.Configuration.IdentityServer
{
    public class Client : global::IdentityServer4.Models.Client
    {
        public List<Claim> ClientClaims { get; set; } = new List<Claim>();
    }
}






