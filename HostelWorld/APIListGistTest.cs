using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NUnit.Framework;

namespace HostelWorld
{
    class APIListGistTest
    {
   
        
        [Test]
        public async Task ValidateListGists()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();
            var githubusername = config["githubusername"];
            var githubuserpublictoken = config["githubuserpublictoken"];
            var gistbaseurl = config["gistbaseurl"];
            var CreateAPIGistUrl = config["createapigisturl"];

            HttpClient _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(gistbaseurl);
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "request");
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + $"{githubusername}:{githubuserpublictoken}");

            HttpResponseMessage content = await _httpClient.GetAsync($"/users/{githubusername}/gists");
            var responseBody = await content.Content.ReadAsStringAsync();

            var gistResults = (List<Gist>)JsonConvert.DeserializeObject<IEnumerable<Gist>>(responseBody);

            Assert.AreEqual(HttpStatusCode.OK, content.StatusCode);
            Assert.IsNotNull(gistResults);

            foreach (var gist in gistResults)
            {
                Assert.IsNotNull(gist.Files);
                Assert.IsNotNull(gist.Description);
                Assert.IsTrue(gist.Public);
                Assert.IsNotNull(gist.Owner.Login);
            }            
        }
    }
}
