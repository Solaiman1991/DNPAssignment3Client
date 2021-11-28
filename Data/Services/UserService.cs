using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Assingment1.Data.Models;

namespace Assingment1.Data.Services
{
    public class UserService:IUserService
    {
        
        private IList<User> users = new List<User>();
        private string uri = "https://localhost:5000";
        public event Action onChange;


        // public UserService()
        // {
        //
        //     users = new[] {
        //         new User {
        //             UserName = "Student",
        //             Password = "123456",
        //             Role = "Teacher",
        //             SecurityLevel = 2
        //         },
        //         new User {
        //             UserName = "Admin",
        //             Password = "123456",
        //             Role = "Admin",
        //             SecurityLevel = 3
        //         }
        //     }.ToList();
        // }


        public async Task<User> AddUser(User user)
        {
            using HttpClient httpClient = new HttpClient();

            string userAsJson = JsonSerializer.Serialize(user);
            StringContent content = new StringContent(userAsJson, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await httpClient.PostAsync(uri + "/User", content);
            
            RequestCodeCheck(responseMessage);

            string createdAsJson = await responseMessage.Content.ReadAsStringAsync();

            User createdUser = JsonSerializer.Deserialize<User>(createdAsJson, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            return createdUser;
        }

        public async Task<User> ValidateUser(string userName, string password)
        {
            using HttpClient httpClient = new HttpClient();

            HttpResponseMessage responseMessage = await httpClient.GetAsync(uri + $"/User?userName={userName}&&password={password}");
            
            RequestCodeCheck(responseMessage);

            string responseFromServer = await responseMessage.Content.ReadAsStringAsync();

            User userFromServer = JsonSerializer.Deserialize<User>(responseFromServer,
                new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});

            return userFromServer;     
        }
        
        
        private static void RequestCodeCheck(HttpResponseMessage responseMessage)
        {
            Console.WriteLine("Checking request");
            if (!responseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine("Not good");
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
        }
    }
}
