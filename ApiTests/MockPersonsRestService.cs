﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using MyApi.Domain;
using MyApi.Interfaces;
using MyApi.ResponseTypes;
using Newtonsoft.Json;

namespace ApiTests
{
    public class MockPersonsRestService : MockRestService
    {
        private readonly ILogService _logService = new MockLogService();

        public static string SampleJson { get; set; }

        public MockPersonsRestService()
        {
            SampleJson = BuildJson();
        }

        private static string BuildJson()
        {
            List<Person> persons = new List<Person>
            {
                new Person { FirstName = "Anthony" , LastName = "Harrison", Email = "anthony.harrison@xamtastic.com", WebAddress = "www.xamtastic.com", Id = "ad6dda4c-d25c-49f0-858f-3723c068d2a5" },
                new Person { FirstName = "Joe" , LastName = "Bloggs", Email = "joe@bloggs.net", WebAddress = "www.bloggs.net", Id = "ca0d9950-1a2d-47fd-a3da-3ee53e340b23" },
            };

            return JsonConvert.SerializeObject(persons);
        }

        public override IObservable<PersonsResponse> GetPersons()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(SampleJson, Encoding.UTF8, "application/json")
            };

            return Observable.Create<PersonsResponse>(
                observer => {
                    observer.OnNext(new PersonsResponse(response, _logService));
                    observer.OnCompleted();
                    return Disposable.Create(() => { });
                });
        }
    }
}