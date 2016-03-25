using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MyApi.Interfaces;
using MyApi.ResponseTypes;

namespace ApiTests
{
    public class MockRestService : IRestService
    {
        public class MockRestException : Exception
        {

        }

        public virtual IObservable<PersonsResponse> GetPersons(HttpMessageHandler messageHandler)
        {
            throw new MockRestException();
        }

        public virtual IObservable<PersonsResponse> GetPersons()
        {
            throw new MockRestException();
        }


    }
}
