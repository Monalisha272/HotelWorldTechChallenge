using System;
using System.IO;
using System.Net;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NUnit.Framework;

namespace HostelWorld
{
    class APICreateGistTest
    {
        [Test]

        public void CreateGist()
        {
            Gist gistResult;
            HttpWebResponse httpResponse;
            //Read the parameter values from the appSettings file
            var config = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();
            var githubusername = config["githubusername"];            
            var githubuserpublictoken = config["githubuserpublictoken"];
            var gistbaseurl = config["gistbaseurl"];
            var createapigisturl = config["createapigisturl"];
            var @public = config["public"];
            var filename = config["filename"];
            var content = config["content"];
            var description = config["description"];

            HttpWebRequest requestObjPost = (HttpWebRequest)WebRequest.Create(gistbaseurl + createapigisturl);
            requestObjPost.UserAgent = "request";
            requestObjPost.Method = "POST";
            requestObjPost.ContentType = "application/json";

            string authInfo = githubusername + ":" + githubuserpublictoken;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            requestObjPost.Headers.Add("Authorization", "Basic " + authInfo);

            var requestInfo = "{ \"description\": "+'"' +description +'"'+ ",  \"public\": "+ @public + ","
                   + "\"files\": {   " + '"' + filename + '"' + ": {"
                   + "\"content\":" + '"' + content + '"' + " } }}";


            using (var streamWriter = new StreamWriter(requestObjPost.GetRequestStream()))
            {
                System.Diagnostics.Debug.WriteLine(requestInfo);
                streamWriter.Write(requestInfo);
                streamWriter.Flush();
                streamWriter.Close();

                httpResponse = (HttpWebResponse)requestObjPost.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var ResponseResult = streamReader.ReadToEnd();

                    var setting = new JsonSerializerSettings() { Formatting = Formatting.Indented, NullValueHandling = NullValueHandling.Ignore };
                    gistResult = JsonConvert.DeserializeObject<Gist>(ResponseResult.ToString(), setting);
                    Console.WriteLine(ResponseResult);
                    
                }
            }

            //Assert
            Assert.IsNotNull(gistResult);
            Assert.AreEqual(HttpStatusCode.Created, httpResponse.StatusCode);
            Assert.IsNotNull(gistResult.Files);
            Assert.AreEqual(description, gistResult.Description);
            Assert.IsTrue(gistResult.Public);
            Assert.AreEqual(githubusername, gistResult.Owner.Login);
        }

    }
}
