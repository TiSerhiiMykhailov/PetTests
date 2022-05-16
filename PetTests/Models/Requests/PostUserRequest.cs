using Newtonsoft.Json;

namespace PetTests.Models.Requests
{
    public class PostUserRequest
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }
    }
}
