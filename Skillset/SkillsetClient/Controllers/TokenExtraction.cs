using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsetClient.Controllers
{
    public class TokenExtraction
    {
        public void extractToken(String token)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("jjshfkhfkghbvcviutlnvunnksjknvkfjbkrtygbdfg545678566jdkhiufh"));
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidAudiences = new string[]
                {   "http://mycodecamp.orf"
                },
                ValidIssuers = new string[]
                {
                    "http://mycodecamp.orf"
                },
                IssuerSigningKey = key

            };
        }
    }
}
