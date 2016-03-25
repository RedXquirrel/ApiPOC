using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApi.Interfaces;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using MyApi.ResponseTypes;

namespace MyApi.Services
{
    public class MyApiService : IMyApiService
    {
        private readonly IRestService _restService;
        private readonly ILogService _logService;
        private const string _getPersonsErrorKey = "GetPersonsErrorKey";

        public MyApiService(IRestService restService, ILogService logService)
        {
            _restService = restService;
            _logService = logService;
        }

        public async Task<PersonsResponse> GetPersonsAsync()
        {
            return await Observable.Create<PersonsResponse>(
                observer => _restService.GetPersons().Subscribe(
                    (PersonsResponse response) => {
                        observer.OnNext(response);
                    },
                    (Exception ex) => {
                        observer.OnNext(new PersonsResponse() { Success = false, ErrorKey = _getPersonsErrorKey, ErrorMessage = $"Rest Error, Error Key {_getPersonsErrorKey} (GetPersonsAsync) {ex.Message}"});
                        observer.OnCompleted();
                    },
                    () => observer.OnCompleted()
                )
            );
        }
    }
}
