using Common.Models;

namespace Client.Services
{
    public interface ILotteryService
    {
        Task<int> CreateLottery(LotteryModel lottery);
        Task<int> CreateUser(string name);
        Task<LotteryModel> GetLottery(int lotteryId);
    }
}
