using System;
using System.Net.Http;
using MyApi.ResponseTypes;

namespace MyApi.Interfaces
{
    public interface IRestService
    {
        IObservable<PersonsResponse> GetPersons(HttpMessageHandler messageHandler);
        IObservable<PersonsResponse> GetPersons();
    }
}