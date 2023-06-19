using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class LotteryModel
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int? PayNumber { get; set; }
        public int? TicketPrice { get; set; }
        public int? TotalTickets { get; set; } = 100;
        public List<LotteryPrizeModel>? Prizes { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;

        

    }
}
