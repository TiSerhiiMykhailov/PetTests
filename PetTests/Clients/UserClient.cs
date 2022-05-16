using Newtonsoft.Json;
using PetTests.Models.Requests;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PetTests.Clients
{
    public class UserClient
    {
        public async Task<CommonResponse<int>> CreateUser(string firstName, string lastName)
        {
            var request1 = new PostUserRequest
            {
                FirstName = firstName,
                LastName = lastName
            };

            var httpClient1 = new HttpClient();

            var requestContent1 = new StringContent(JsonConvert.SerializeObject(request1), Encoding.UTF8, "application/json");
            var response1 = await httpClient1.PostAsync("https://userserviceuat.azurewebsites.net/Register/RegisterNewUser", requestContent1);

            return await response1.ToCommonResponse<int>();
        }

        public async Task<CommonResponse<bool>> GetUserIsActiveStatus(int userId)
        {
            var httpClient2 = new HttpClient();

            var response2 = await httpClient2.GetAsync($"https://userserviceuat.azurewebsites.net/UserManagement/GetUserStatus?userId={userId}");

            return await response2.ToCommonResponse<bool>();
        }
    }
}
