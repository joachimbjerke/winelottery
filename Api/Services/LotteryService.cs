using Api.Data.Entities;
using Api.DataContext;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Common.Models;

namespace Api.Services
{
    public class LotteryService : ILotteryService
    {
        private readonly LotteryDbContext _dbContext;
        public LotteryService(LotteryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserModel> GetUser(int id)
        {
            var user = await _dbContext.User.FindAsync(id);
            if(user != null)
            {
                var result = new UserModel { Id = user.Id, Name = user.Name };
                return result;
            }

            return null;
            
        }

        public async Task<int> CreateUser(string name)
        {
            var user = new User
            {
                Name = name
            };
            _dbContext.User.Add(user);
            await _dbContext.SaveChangesAsync();

            return user.Id;
        }

        public async Task<IEnumerable<LotteryModel>> GetLotteries()
        {
            var lotteries = await _dbContext.Lottery
                .Include(req => req.Prizes).ToListAsync();

            var result = lotteries.Select(x => new LotteryModel
            {
                Id = x.Id,
                OwnerId = x.OwnerId,
                PayNumber = x.PayNumber,
                TotalTickets = x.TotalTickets,
                TicketPrice = x.TicketPrice,
                StartDate = x.StartDate,
                Prizes = x.Prizes.Select(y => new LotteryPrizeModel
                {
                    Name = y.Name,
                    Price = y.Price
                }).ToList()
            });

            return result;
        }

        public async Task<LotteryModel> GetLottery(int id)
        {
            var lottery = await _dbContext.Lottery.Where(x => x.Id == id)
                .Include(req => req.Prizes).FirstOrDefaultAsync();

            var result = lottery.ToLotteryModel();

            return result;
        }

        public async Task<int> CreateLottery(LotteryModel lottery)
        {
            var entity = new Lottery
            {
                OwnerId = lottery.OwnerId,
                PayNumber = lottery.PayNumber,
                TicketPrice = lottery.TicketPrice,
                TotalTickets = lottery.TotalTickets,
                Prizes = lottery.Prizes.Select(x => new LotteryPrize { Name = x.Name, Price = x.Price }).ToList(),
                StartDate = lottery.StartDate,
            };



            _dbContext.Lottery.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }
    }
}
