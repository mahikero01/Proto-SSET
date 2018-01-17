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
        private TokenFactory _tokenFactory;

        public HomeController(
            ILogger<HomeController> logger,
            IConfiguration config)
        {
            _tokenFactory = new TokenFactory();
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
            //this is used to gather information about the client's identity
            var authenticationToken = HttpContext.Session.GetString("authToken");

            if (authenticationToken != null)
            {
                //1)Extracttoken is used to extract all details required before generating an authorization token
                //2)GenerateAuthorizationToken is used to generate Authorization token
                var authorizationToken = _tokenFactory.GenerateAuthorizationToken(_tokenFactory.ExtractToken(authenticationToken));

                //save to session
                HttpContext.Session.SetString("apiToken", authorizationToken);
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
