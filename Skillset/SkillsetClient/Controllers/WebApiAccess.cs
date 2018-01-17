﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SkillsetClient.Controllers
{
    public class WebApiAccess
    {
        private string _apiURL;
        private HttpClient _client;

        public WebApiAccess(string controller)
        {
            _apiURL = Startup.Configuration["WebApiServer:ApiURL"] ;
            _apiURL = _apiURL + "/" + controller;

            //instantiate client
            _client = new HttpClient();
        }

        public async Task<string> PostRequest(HttpContent body)
        {
            var request = await _client.PostAsync(_apiURL, body);
            if (request.IsSuccessStatusCode)
            {
                var result = request.Content.ReadAsStringAsync().Result;
                return result;
            }

            return null;
        }

        public async Task<string> PutRequest(HttpContent body)
        {
            var request = await _client.PutAsync(_apiURL, body);
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
