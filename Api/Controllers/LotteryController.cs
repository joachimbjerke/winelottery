using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotteryController : ControllerBase
    {
        private readonly ILotteryService _service;
        public LotteryController(ILotteryService service)
        {
            _service = service;
        }


        [HttpGet("User/{id}")]
        public async Task<UserModel> GetUser(int id)
        {
            return await _service.GetUser(id);
        }

        [HttpPost("User")]
        public async Task<int> CreateUser(string name)
        {
            return await _service.CreateUser(name);
        }

        [HttpGet]
        public async Task<IEnumerable<LotteryModel>> Get()
        {
            var result = await _service.GetLotteries();
            return result;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<LotteryModel> Get(int id)
        {
            var result = await _service.GetLottery(id);
            return result;
        }

        [HttpPost]
        public async Task<int> Post(LotteryModel lottery)
        {
            var lotteryId = await _service.CreateLottery(lottery);
            return lotteryId;
        }


        [HttpGet("{lotteryId}/Tickets")]
        public async Task<JsonResult> GetLotteryTickets(int lotteryId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{lotteryId}/Tickets")]
        public async Task<JsonResult> CreateLotteryTickets(LotteryModel lottery)
        {
            throw new NotImplementedException();
        }
    }
}
