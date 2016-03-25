using System.Collections.Generic;
using MyApi.Domain;

namespace MyApi.RequestTypes
{
    public class PersonData : BaseRequestType
    {
        public Person Person { get; set; }

        public override IDictionary<string, object> JsonContent
        {
            get
            {
                return new Dictionary<string, object> {
                    { ApiKeys.Id, Person.Id },
                    { ApiKeys.Id, Person.FirstName },
                    { ApiKeys.Id, Person.LastName },
                    { ApiKeys.EmailAddress, Person.Email },
                    { ApiKeys.WebAddress, Person.WebAddress },                    
                };
            }
        }
    }
}