using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NUnit.Framework;


namespace HostelWorld
{
    class APIDeleteGist
    {
        [Test]

        public void DeleteGist()
        {
            HttpWebResponse httpResponse;
            //Read the parameter values from the appSettings file
            var config = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();
            var githubUserName = config["githubUserName"];
            var githubuserpublictoken = config["githubuserpublictoken"];
            var gistbaseurl = config["gistbaseurl"];
            var createapigisturl = config["createapigisturl"];
            var gistidtodelete = config["gistidtodelete"];

            HttpWebRequest requestObjPost = (HttpWebRequest)WebRequest.Create(gistbaseurl + createapigisturl + "/"+gistidtodelete);
            requestObjPost.UserAgent = "request";
            requestObjPost.Method = "DELETE";
            //requestObjPost.ContentType = "application/json";

            string authInfo = githubUserName + ":" + githubuserpublictoken;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            requestObjPost.Headers.Add("Authorization", "Basic " + authInfo);


            using (var streamWriter = new StreamWriter(requestObjPost.GetRequestStream()))
            {
                
                httpResponse = (HttpWebResponse)requestObjPost.GetResponse();


            }

            
            //Assert
           
           Assert.AreEqual("NoContent", httpResponse.StatusCode.ToString());
           Assert.AreEqual(gistbaseurl + createapigisturl + "/" + gistidtodelete, httpResponse.ResponseUri.ToString().Replace("<","").Replace(">",""));
           Assert.AreEqual(requestObjPost.Method, httpResponse.Method);
        }
    }
}
