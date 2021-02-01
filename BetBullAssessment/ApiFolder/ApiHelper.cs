using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace BetBullAssessment.ApiFolder
{
    public class ApiHelper<T>
    {
        private string Baseurl = "https://reqres.in/api/";
        private HttpClient Client = new HttpClient();
        public RestClient restClient;
        public RestRequest restRequest;
        public Data users;

        public async Task<T> GetRequest<T>(string endpoint)
        {
            var builder = new UriBuilder(Baseurl+endpoint);
            var request = await Client.GetAsync(builder.Uri);
            var content = await request.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<T>(content);
            return response;
        }

        public async Task<string> PostRequest(string endpoint, HttpContent content)
        {
            var builder = new UriBuilder(Baseurl + endpoint);
            var request = await Client.PostAsync(builder.Uri, content);
            var context = await request.Content.ReadAsStringAsync();
            var response = JsonConvert.SerializeObject(context);
            return response;
        }

        public RestClient SetUrl(string endpoint)
        {
            var url = Path.Combine(Baseurl, endpoint);
            var restClient = new RestClient(url);
            return restClient;
        }

        public RestRequest CreateGetRequest()
        {
            var restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Accept", "Application/json");
            return restRequest;
        }

        public RestRequest CreateDeleteRequest()
        {
            var restRequest = new RestRequest(Method.DELETE);
            restRequest.AddHeader("Accept", "Application/json");
            return restRequest;
        }

        public RestRequest CreatePostRequest(Data payload)
        {
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "Application/json");
            restRequest.AddParameter("application/json", restRequest.AddJsonBody(payload), ParameterType.RequestBody);
            return restRequest;
        }

        public RestRequest CreatePutRequest(Data payload)
        {
            var restRequest = new RestRequest(Method.PUT);
            restRequest.AddHeader("Accept", "Application/json");
            restRequest.AddParameter("application/json", restRequest.AddJsonBody(payload), ParameterType.RequestBody);
            return restRequest;
        }

        public IRestResponse GetResponse(RestClient client, RestRequest request)
        {
            return client.Execute(request);
        }

        public DTO GetContent<DTO>(IRestResponse response)
        {
            var content = response.Content;
            DTO contentObject = JsonConvert.DeserializeObject<DTO>(content);
            return contentObject;
        }

        public string Serialize(dynamic content)
        {
            string serializeObject = JsonConvert.SerializeObject(content, Formatting.Indented);
            return serializeObject;
        }

    }
}
