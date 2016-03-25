using System;

namespace MyApi.Interfaces
{
    public interface IRestService
    {
        IObservable<PersonsResponse> GetPersons(HttpMessageHandler messageHandler);
    }
}