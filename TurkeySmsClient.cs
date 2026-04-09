using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace TurkeySms
{
    public class TurkeySmsClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _baseUrl = "https://api.turkeysms.com.tr/";

        public TurkeySmsClient(string apiKey)
        {
            _apiKey = apiKey;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        private async Task<string> PostAsync(string endpoint, object data)
        {
            try
            {
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                dictionary["api_key"] = _apiKey;

                var json = JsonConvert.SerializeObject(dictionary);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(_baseUrl + endpoint, content);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return $"{{\"status\":\"error\", \"result_message\":\"{ex.Message}\"}}";
            }
        }

        public async Task<string> SendSmsAsync(string title, string mobile, string text, int lang = 0)
        {
            return await PostAsync("sms/send", new { title, mobile, text, sms_lang = lang });
        }

        public async Task<string> SendOtpAsync(string mobile, int lang = 2, int digits = 4)
        {
            return await PostAsync("otp/send", new { mobile, lang, digits });
        }

        public async Task<string> SendDetailedOtpAsync(string title, string mobile, string text, int lang = 2)
        {
            return await PostAsync("otp/detailed", new { title, mobile, text, lang });
        }

        public async Task<string> GetBalanceAsync()
        {
            return await PostAsync("balance/", new { });
        }

        public async Task<string> AddToBlacklistAsync(string number)
        {
            return await PostAsync("blacklist/add", new { number });
        }

        public async Task<string> GetSmsStatusAsync(object sms_id)
        {
            return await PostAsync("sms/status", new { sms_id });
        }
    }
}
