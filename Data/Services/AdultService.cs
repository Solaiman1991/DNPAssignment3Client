using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Assingment1.Data.Models;

namespace Assingment1.Data.Services
{
    public class AdultService : IAdultService
    {
        private IList<Adult> adults = new List<Adult>();
        private readonly string adultFile;
        private string uri = "https://localhost:5001";
        public event Action onChange;

        public AdultService()
        {
        }

        public async Task<IList<Adult>> GetAdults()
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync(uri + "/Adult");
            RequestCodeCheck(responseMessage);
            if (!responseMessage.IsSuccessStatusCode)

            {
                throw new Exception(@"Error:{responseMessage.StatusCode},{responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            IList<Adult> adults = JsonSerializer.Deserialize<IList<Adult>>(result,
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            Console.WriteLine(adults);
            return adults;
        }

        public async Task<Adult> AddAdult(Adult adult)
        {            
            using HttpClient httpClient = new HttpClient();

            string adultAsJson = JsonSerializer.Serialize(adult);
            StringContent content = new StringContent(adultAsJson, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await httpClient.PostAsync(uri + "/adult", content);
            
            RequestCodeCheck(responseMessage);

            string createdAsJson = await responseMessage.Content.ReadAsStringAsync();

            Adult createdAdult = JsonSerializer.Deserialize<Adult>(createdAsJson, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            return createdAdult;
        }

     

        public async Task RemoveAdult(Adult adult)
        {
            using HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.DeleteAsync(uri+"/adult?Id="+adult.Id);
                if (!response.IsSuccessStatusCode)
                    throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
        }

        public Adult GetByAdultId(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditAdult(Adult adult)
        {
            throw new NotImplementedException();
        }

        public void UpdateAdult(Adult adultToUpdate)
        {
            throw new NotImplementedException();
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