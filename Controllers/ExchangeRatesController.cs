using Microsoft.AspNetCore.Mvc;
using Testx.Services;

namespace Testx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRatesController : ControllerBase
    {
        private readonly NbpService _nbpService; //wstrzykujemy serwis NbpService do kontrolera

        public ExchangeRatesController(NbpService nbpService) //konstruktor
        {
            _nbpService = nbpService;
        }

        [HttpGet("eur")]
        public async Task<ActionResult<decimal>> GetEurRate() //endpoint do pobierania kursu 
        {
            var rate = await _nbpService.GetEurExchangeRateAsync();
            return Ok(rate); //http 200 
        }
    }
}