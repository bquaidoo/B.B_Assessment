using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;

namespace BetBullAssessment.ApiFolder
{
    public class ApiTestModule
    {
        private const string url = "https://reqres.in/api/";
        IRestClient client;
        IRestRequest request;

        [Test]
        [System.Obsolete]
        public void SuccessfullRegistration()
        {
            string endpoint = "register";
            client = new RestClient();
            request = new RestRequest(url+endpoint, Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            //string payload = @"{""email"":""eve.holt@reqres.in"", ""password"":""pistol""}";
            //request.AddJsonBody(payload);
            request.AddJsonBody(new Data() {email="eve.holt@reqres.in", password="pistol" });
            

            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                Assert.AreEqual(200, (int)response.StatusCode);
            }
        }

        [Test]
        [System.Obsolete]
        public void UnSuccessfullRegistration()
        {
            string endpoint = "register";
            client = new RestClient();
            request = new RestRequest(url + endpoint, Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(new Data() { email = "eve.holt@reqres.in"});

            var response = client.Execute(request);
            if (response != null)
            {
                Assert.AreEqual(400, (int)response.StatusCode);
                Assert.IsTrue(response.Content.Contains("Missing password"));
            }
        }

        [Test]
        public void GetAllUsers()
        {
            string endpoint = "users";
            client = new RestClient();
            request = new RestRequest(url + endpoint, Method.GET);

            var response = client.Execute<Application>(request);
            //Application data = JsonConvert.DeserializeObject<Application>(response.Content);

            if (response.Content != null && response.IsSuccessful)
            {
                Assert.AreEqual(200, (int)response.StatusCode);
                Assert.AreEqual(6, response.Data.data.Count);
                Assert.AreEqual("George", response.Data.data[0].first_name);
            }
        }

       
    }
}
