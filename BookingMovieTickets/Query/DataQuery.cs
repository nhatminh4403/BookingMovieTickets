using BookingMovieTickets.DataAccess;
using Newtonsoft.Json;

namespace BookingMovieTickets.Query
{
    public class TokenGoogle
    {
        //[JsonProperty(PropertyName = "error_description")]
        public string error_description { get; set; }
        //[JsonProperty(PropertyName = "name")]
        public string name { get; set; }
        //[JsonProperty(PropertyName = "email")]
        public string email { get; set; }
        public string phone { get; set; }
    }
    public class DataQuery
    {
        private static HttpClient httpClient = new HttpClient();
        private readonly BookingMovieTicketsDBContext? _context;
        public static string IDClientGoogle = "857345887326-nh7cfh5afo9t6cou3i1i9vcu5f760ocs.apps.googleusercontent.com";
        public static async Task<TokenGoogle> VerifyTokenGoogle(string token)
        {
            TokenGoogle json = new();
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"https://www.googleapis.com/oauth2/v3/tokeninfo?id_token={token}"))
            {
                requestMessage.Headers.Add("Accept", "application/json");
                HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
                if (response.IsSuccessStatusCode)
                {
                    var t = JsonConvert.DeserializeObject<TokenGoogle>(await response.Content.ReadAsStringAsync());
                    if (t.error_description == null)
                    {
                        json.name = t.name;
                        json.email = t.email;
                        json.phone = t.phone;
                    }
                    else json.error_description = t.error_description;
                }
            }
            return json;
        }
    }
}
