using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace PetTests.Clients
{
    public static class HttpResponseMessageExtension
    {
        public static async Task<CommonResponse<T>> ToCommonResponse<T>(this HttpResponseMessage httpResponseMessage)
        {
            var responseContent2 = await httpResponseMessage.Content.ReadAsStringAsync();

            var commonResponse = new CommonResponse<T>
            {
                Status = httpResponseMessage.StatusCode,
                Content = responseContent2
            };

            try
            {
                commonResponse.Body = JsonConvert.DeserializeObject<T>(responseContent2);
            }
            catch (JsonReaderException e)
            {

            }

            return commonResponse;
        }
    }
}
