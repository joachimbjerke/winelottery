
using Common.Models;

namespace Api.Data.Entities
{
    public class Lottery
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int? PayNumber { get; set; }
        public int? TicketPrice { get; set; }
        public int? TotalTickets { get; set; } = 100;
        public ICollection<LotteryPrize> Prizes { get; set; } = new List<LotteryPrize>();
        public DateTime StartDate { get; set; } = DateTime.Now;

        public LotteryModel ToLotteryModel()
        {
            return new LotteryModel
            {
                Id = Id,
                PayNumber = PayNumber,
                TicketPrice = TicketPrice,
                TotalTickets = TotalTickets,
                StartDate = StartDate,
                Prizes = Prizes.Select(x => new LotteryPrizeModel
                {
                    Name = x.Name,
                    Price = x.Price
                }).ToList()
            };
        }
    }
}
