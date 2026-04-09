using Microsoft.AspNetCore.Mvc;
using Testx.Services;

namespace Testx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRatesController : ControllerBase
    {
        private readonly NbpService _nbpService;

        public ExchangeRatesController(NbpService nbpService)
        {
            _nbpService = nbpService;
        }

        [HttpGet("eur")]
        public async Task<ActionResult<decimal>> GetEurRate()
        {
            var rate = await _nbpService.GetEurExchangeRateAsync();
            return Ok(rate);
        }
    }
}