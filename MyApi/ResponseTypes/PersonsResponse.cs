using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MyApi.Domain;
using MyApi.Interfaces;
using Newtonsoft.Json;

namespace MyApi.ResponseTypes
{
    public class PersonsResponse : BaseResponse
    {
        public List<Person> Persons { get; private set; }

        public PersonsResponse()
        {
            
        }

        public PersonsResponse(HttpResponseMessage response, ILogService logService) : base(response, logService)
        {
        }

        protected override void AssignFromHttpResponseContent(HttpContent responseContent)
        {
            if (Success)
            {
                Persons = JsonConvert.DeserializeObject<List<Person>>((string)Content);
            }
            else {
                LogService.Error($"Persons returned an Error Response");
            }

        }
    }
}
