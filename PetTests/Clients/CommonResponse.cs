using System.Net;

namespace PetTests.Clients
{
    public class CommonResponse<T>
    {
        public T Body { get; set; }
        public string Content { get; set; }
        public HttpStatusCode Status { get; set; }
    }
}
