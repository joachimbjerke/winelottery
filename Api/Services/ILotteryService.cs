
using Api.Data.Entities;
using Common.Models;

namespace Api.Services
{
    public interface ILotteryService
    {
        Task<UserModel> GetUser(int id);
        Task<int> CreateUser(string name);
        Task<IEnumerable<LotteryModel>> GetLotteries();
        Task<LotteryModel> GetLottery(int id);
        Task<int> CreateLottery(LotteryModel lottery);
    }
}
