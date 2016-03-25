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
        // GET api/<controller>
        public List<Person> Get()
        {
            return new List<Person>
            {
                new Person { FirstName = "Anthony", LastName = "Harrison", Email = "anthony.harrison@xamtastic.com", WebAddress = "http://www.xamtastic.com", Id = Guid.NewGuid().ToString()},
                new Person { FirstName = "Joe", LastName = "Blogs", Email = "joe.bloggs@xamtastic.com", WebAddress = "http://www.xamtastic.com", Id = Guid.NewGuid().ToString()},
            };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}