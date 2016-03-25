using Newtonsoft.Json;

namespace MyApi.Domain
{
    public class Person
    {
        [JsonProperty(PropertyName = "id")]
        public string Id;
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName;
        [JsonProperty(PropertyName = "lastName")]
        public string LastName;
        [JsonProperty(PropertyName = "email")]
        public string Email;
        [JsonProperty(PropertyName = "webAddress")]
        public string WebAddress;
    }
}