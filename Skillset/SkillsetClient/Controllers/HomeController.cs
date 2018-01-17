using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SkillsetClient.Models;

namespace SkillsetClient.Controllers
{
    public class HomeController : Controller
    {
        private string _authToken;
        private string _apiToken;
        private ILogger<HomeController> _logger;
        private IConfiguration _config;
        private HttpClient _client;

        public HomeController(
            ILogger<HomeController> logger,
            IConfiguration config)
        {
            _client = new HttpClient();
            _logger = logger;
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SignIn()
        {
            //request a post to IDP server to gain an AuthToken
            await getAuthentication();
            ProvideAuthorization();

            return View();
        }

        public async Task<IActionResult> getAuthentication()
        {
            //var idpToken = await _client.PostAsync("http://localhost:60818/api/auth/token", null);
            var idpToken = await _client.PostAsync(_config["IDPServer:TokenRequestURL"], null);
            if (idpToken.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var authToken = JsonConvert.DeserializeObject<AppToken>(idpToken.Content.ReadAsStringAsync().Result);
                HttpContext.Session.SetString("authToken", authToken.Token.ToString());
            }

            return Ok();
        }

        //this method generates its authorization token that will consumed by web api server only
        public void ProvideAuthorization()
        {
            var user = "mahikero";

            var claims = new[]
            {
                 new Claim(ClaimTypes.Name, user),
                 new Claim(ClaimTypes.Actor, "CocoM")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("03fb1760-a45f-4473-bed4-aab1e8d7e87a"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "http://localhost:60812",
                audience: "http://localhost:60822",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds
            );


            var myToken = new JwtSecurityTokenHandler().WriteToken(token);
            JwtSecurityToken ax = new JwtSecurityToken();
            HttpContext.Session.SetString("apiToken", myToken);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
