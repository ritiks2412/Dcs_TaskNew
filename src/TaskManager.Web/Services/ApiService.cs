using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace TaskManager.Web.Services
{
    public class ApiService
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _accessor;

        public ApiService(HttpClient client, IHttpContextAccessor accessor)
        {
            _client = client;
            _accessor = accessor;
        }


        public void SetToken()
        {
            var token = _accessor.HttpContext.Session.GetString("JWTToken");
            if (!string.IsNullOrEmpty(token))
            {
                _client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
        }
        public async Task<HttpResponseMessage> Post(string url, object data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _client.PostAsync(url, content);
        }

        public async Task<HttpResponseMessage> Get(string url)
        {
            SetToken();
            return await _client.GetAsync(url);
        }
        
        public async Task<HttpResponseMessage> Put(string url, object data)
        {
            SetToken();

            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _client.PutAsync(url, content);
        }
    }
}
