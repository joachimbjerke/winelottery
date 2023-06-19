using Common.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace Client.Services
{
    public class LotteryService : ILotteryService
    {
        private readonly HttpClient _httpClient;
        public LotteryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<int> CreateUser(string name)
        {
            var s = await _httpClient.PostAsync($"api/Lottery/User?name={name}", null);
            var resp = await s.Content.ReadAsStringAsync();
            return int.Parse(resp);
        }

        public async Task<int> CreateLottery(LotteryModel lottery)
        {
            var json = JsonSerializer.Serialize(lottery);
            var s = await _httpClient.PostAsync("api/Lottery", new StringContent(json, new MediaTypeHeaderValue("application/json")));
            var resp = await s.Content.ReadAsStringAsync();
            return int.Parse(resp);
        }

        public async Task<LotteryModel> GetLottery(int lotteryId)
        {
            var respMessage = await _httpClient.GetAsync($"api/Lottery/{lotteryId}");
            var resp = await respMessage.Content.ReadFromJsonAsync<LotteryModel>();
            return resp;
        }
    }
}
