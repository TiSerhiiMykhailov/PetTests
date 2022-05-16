using Newtonsoft.Json;
using NUnit.Framework;
using PetTests.Clients;
using PetTests.Models.Requests;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PetTests
{
    public class Tests
    {
        private readonly UserClient _userClient = new UserClient();

        [Test]
        public async Task PostUser_PostUser_IdIsIncremented()
        {
            // Precondition

            var userId1 = await _userClient.CreateUser("serhii", "mykhailov");

            // Action

            var userId2 = await _userClient.CreateUser("serhii", "mykhailov");

            // Assert

            Assert.Greater(userId2.Body, userId1.Body);
        }

        [Test]
        public async Task PostUser_GetStatus_StatusIsFalse()
        {
            // Precondition

            var userId = await _userClient.CreateUser("serhii", "mykhailov");

            // Action

            var responseModel2 = await _userClient.GetUserIsActiveStatus(userId.Body);

            // Assert

            Assert.AreEqual(false, responseModel2.Body);
            Assert.AreEqual(HttpStatusCode.OK, responseModel2.Status);
        }

        [Test]
        public async Task NotExistingUser_GetStatus_Return500()
        {
            // Precondition

            var userId = 42000;

            // Action

            var responseModel2 = await _userClient.GetUserIsActiveStatus(userId);

            // Assert

            Assert.AreEqual(HttpStatusCode.InternalServerError, responseModel2.Status);
            Assert.AreEqual("Sequence contains no elements", responseModel2.Content);
        }
    }
}