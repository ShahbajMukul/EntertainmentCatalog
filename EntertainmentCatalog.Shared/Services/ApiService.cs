using EntertainmentCatalog.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EntertainmentCatalog.Shared.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public ApiService(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
        }

        public async Task<ItemDetails> GetItemDetailsAsync(string title)
        {
            // Ensure the title is properly URL encoded
            string encodedTitle = Uri.EscapeDataString(title);

            // Construct the endpoint with the encoded title and API key
            string endpoint = $"https://www.omdbapi.com/?t={encodedTitle}&apikey={_apiKey}";

            try
            {
                // Log the endpoint for debugging purposes
                Console.WriteLine($"Requesting: {endpoint}");

                // Make the HTTP request
                var response = await _httpClient.GetFromJsonAsync<ItemDetails>(endpoint);
                return response ?? new ItemDetails();
            }
            catch (HttpRequestException e)
            {
                // Log the exception and rethrow it
                Console.WriteLine($"Request error: {e.Message}");
                throw;
            }
        }
    }
}
