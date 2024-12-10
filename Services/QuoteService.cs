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
        private const string ApiUrl = "https://api.quotable.io/random";
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
            catch
            {
                return "Unable to fetch a quote at this moment. Please try again.";
            }
        }

        private class QuoteModel
        {
            public string Content { get; set; }
            public string Author { get; set; }
        }
    }

}
