using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApi.Interfaces;

namespace ApiTests
{
    public class MockApiEndpointService : IApiConfigurationService
    {
        private string _baseUrl = "http://localhost:54555/";

        public string GetBaseUrl()
        {
            return _baseUrl;
        }
    }
}
