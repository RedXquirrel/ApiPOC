using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MyApi.Interfaces;
using MyApi.RequestTypes;
using MyApi.ResponseTypes;
using Newtonsoft.Json;

namespace MyApi.Services
{
    public class RestService : IRestService
    {
        private const string BaseUri = "https://www.xamtastic.com";
        private string _accessToken;

        public IObservable<PersonsResponse> GetPersons()
        {
            throw new NotImplementedException();
        }

        public IObservable<PersonsResponse> GetPersons(HttpMessageHandler messageHandler)
        {
            throw new NotImplementedException();
        }


        private string PostPersonsEndpoint()
        {
            var builder = new UriBuilder(BaseUri);
            builder.Path = "api/Persons";

            return builder.ToString();
        }

        private HttpClient ConfigureHttpClient(HttpMessageHandler messageHandler)
        {
            var httpClient = new HttpClient(messageHandler);
            httpClient.Timeout = TimeSpan.FromSeconds(20);
            httpClient.DefaultRequestHeaders.Clear();
            if (!String.IsNullOrEmpty(_accessToken))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_accessToken);
            }

            return httpClient;
        }

        private StringContent SerialisedContent(IDictionary<string, object> contentDictionary)
        {
            var serialisedContent = JsonConvert.SerializeObject(contentDictionary);
            var stringContent = new StringContent(serialisedContent, Encoding.UTF8, "application/json");
            return stringContent;
        }

        private Task<HttpResponseMessage> Post(string endPoint, BaseRequestType sendContent, HttpMessageHandler messageHandler)
        {
            var httpClient = ConfigureHttpClient(messageHandler);
            return httpClient.PostAsync(endPoint, SerialisedContent(sendContent.JsonContent));
        }

        private Task<HttpResponseMessage> Get(string endPoint, HttpMessageHandler messageHandler)
        {
            var httpClient = ConfigureHttpClient(messageHandler);
            return httpClient.GetAsync(endPoint);
        }
    }
}