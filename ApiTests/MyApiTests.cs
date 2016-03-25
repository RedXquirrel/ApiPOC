using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MyApi;
using MyApi.Domain;
using MyApi.Interfaces;
using MyApi.ResponseTypes;
using MyApi.Services;
using Newtonsoft.Json;
using NUnit.Framework;

namespace ApiTests
{
    [TestFixture]
    public class MyApiTests
    {
        private IRestService RestService;
        private ILogService LogService;

        [SetUp]
        public void Init()
        {
            RestService = new MockPersonsRestService();
            LogService = new MockLogService();
        }

        [Test]
        public async Task PersonsTest()
        {
            var persons = JsonConvert.DeserializeObject<List<Person>>(MockPersonsRestService.SampleJson);

            var api = new MyApiService(RestService, LogService);
            var response = await api.GetPersonsAsync();

            Assert.IsTrue(response.Success);
            Assert.IsTrue(response.Persons.Count == 2);
            Assert.IsTrue(response.Persons[0].Id == persons[0].Id);

            Assert.IsTrue(response.Persons[0].FirstName == persons[0].FirstName);
            Assert.IsTrue(response.Persons[0].LastName == persons[0].LastName);
            Assert.IsTrue(response.Persons[0].Email == persons[0].Email);
            Assert.IsTrue(response.Persons[0].WebAddress == persons[0].WebAddress);

            Assert.IsTrue(response.Persons[1].FirstName == persons[1].FirstName);
            Assert.IsTrue(response.Persons[1].LastName == persons[1].LastName);
            Assert.IsTrue(response.Persons[1].Email == persons[1].Email);
            Assert.IsTrue(response.Persons[1].WebAddress == persons[1].WebAddress);

        }

    }
}