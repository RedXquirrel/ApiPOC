using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyApi.Domain;
using Newtonsoft.Json;

namespace ApiServer.Controllers
{
    public class PersonsController : ApiController
    {
        readonly List<Person> _persons = new List<Person>
            {
                new Person { FirstName = "Anthony" , LastName = "Harrison", Email = "anthony.harrison@xamtastic.com", WebAddress = "www.xamtastic.com", Id = "ad6dda4c-d25c-49f0-858f-3723c068d2a5" },
                new Person { FirstName = "Joe" , LastName = "Bloggs", Email = "joe@bloggs.net", WebAddress = "www.bloggs.net", Id = "ca0d9950-1a2d-47fd-a3da-3ee53e340b23" },
            };

        // GET api/Persons
        public List<Person> Get()
        {
            return _persons;
        }

        // GET api/Persons/{id}
        public Person Get(string id)
        {
            return Get().FirstOrDefault(persons => persons.Id.Equals(id));
        }

        // POST api/Persons
        public void Post([FromBody]string value)
        {
        }

        // PUT api/Persons/{id}
        public void Put(string id, [FromBody]string value)
        {
        }

        // DELETE api/Persons/{id}
        public void Delete(string id)
        {
        }
    }
}