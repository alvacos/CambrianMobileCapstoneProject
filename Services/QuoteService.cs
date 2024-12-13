using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CambrianMobileCapstoneProject.Services
{
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class QuoteService
    {
        private const string ApiUrl = "http://api.quotable.io/random";
        private readonly HttpClient _httpClient;

        public QuoteService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetRandomQuoteAsync()
        {
            
            try
            {
                var response = await _httpClient.GetStringAsync(ApiUrl);
                var quoteData = JsonSerializer.Deserialize<QuoteModel>(response);
                return quoteData?.Content ?? "Stay motivated!";
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return $"Error fetching quote: {e.Message}";
            }
            catch (Exception e)
            {
                return $"An unexpected error occurred: {e.Message}";
            }
        }

        private class QuoteModel
        {
            public string Content { get; set; }
            public string Author { get; set; }
        }
    }

}
