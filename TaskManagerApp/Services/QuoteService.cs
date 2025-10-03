using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TaskManagerApp.Services
{
    public class QuoteDto
    {
        public string? text { get; set; }
        public string? author { get; set; }
    }


    public class QuoteService : IQuoteService
    {
        private readonly HttpClient _httpClient;

        public QuoteService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetMotivationalQuoteAsync()
        {
            try
            {
                var list = await _httpClient.GetFromJsonAsync<List<QuoteDto>>("https://type.fit/api/quotes");
                if (list == null || list.Count == 0)
                    return "Stay motivated!";

                var rnd = new Random();
                var pick = list[rnd.Next(list.Count)];
                return $"{pick.text} — {pick.author ?? "Unknown"}";
            }
            catch (Exception ex)
            {
                return "Stay motivated!";
            }
        }

    }

}
