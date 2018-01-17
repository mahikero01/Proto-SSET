using Microsoft.IdentityModel.Tokens;
using SkillsetClient.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SkillsetClient.Controllers
{
    public class TokenExtraction
    {
        private List<Claim> _claims;
        public void extractToken(String token)
        {
            _claims= new List<Claim>();
            var jwtToken = new JwtSecurityToken(token);
            
            var names = jwtToken.Claims.
                Where(x => x.Type==ClaimTypes.Name);
            
            var roles = jwtToken.Claims.
                Where(x => x.Type == ClaimTypes.Role);

            var urls = jwtToken.Claims.
                Where(x => x.Type == ClaimTypes.Uri);

            addToClaim(names);
            addToClaim(roles);
            addToClaim(urls);

        }

        private void addToClaim(IEnumerable<Claim> claims)
        {
            foreach(var claim in claims)
            {
                _claims.Add(claim);
            }
        }
    }
}
