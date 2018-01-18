using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace SkillsetClient.Controllers
{
    public class WebApiAccess
    {
        private string _apiURL;
        private string _apiToken;
        private HttpClient _client;

        public WebApiAccess(string controller)
        {
            _apiURL = Startup.Configuration["WebApiServer:ApiURL"] ;
            _apiURL = _apiURL + "/" + controller;
            
            //instantiate client
            _client = new HttpClient();

        }

        public void AssignAuthorization(string token)
        {
            _apiToken = token;
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken);
        }


        public async Task<string> PostRequest(string body)
        {   
            var content = new StringContent(body, Encoding.UTF8, "application/json");
            var request = await _client.PostAsync(_apiURL, content);

            if (request.IsSuccessStatusCode)
            {
                var result = request.Content.ReadAsStringAsync().Result;
                return result;
            }

            return null;
        }

        public async Task<string> PutRequest(string id,HttpContent body)
        {
            var request = await _client.PutAsync(_apiURL+"/"+id, body);
            if (request.IsSuccessStatusCode)
            {
                var result = request.Content.ReadAsStringAsync().Result;
                return result;
            }

            return null;
        }

        public async Task<bool> DeleteRequest(string id)
        {
            var request = await _client.DeleteAsync(_apiURL+"/"+id);
            bool isSuccess = request.IsSuccessStatusCode;
            
            return isSuccess;
        }

        public async Task<string> GetRequest()
        {
            AssignAuthorization();
            var request = await _client.GetAsync(_apiURL);
            if (request.IsSuccessStatusCode)
            {
                var result = request.Content.ReadAsStringAsync().Result;
                return result;
            }

            return null;
        }

        public async Task<string> GetRequest(string id)
        {
            AssignAuthorization();
            var request = await _client.GetAsync(_apiURL+"/"+id);
            if (request.IsSuccessStatusCode)
            {
                var result = request.Content.ReadAsStringAsync().Result;
                return result;
            }

            return null;
        }
    }
}
