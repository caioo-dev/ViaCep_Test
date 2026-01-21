using Microsoft.AspNetCore.Mvc;
using ViaCEP_Test.Interfaces;

namespace ViaCEP_Test.Controllers
{
    [Route("api/cep")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly ICepService _cepService;
        public CepController(ICepService cepService)
        {
            _cepService = cepService;
        }

        [HttpGet("{cep}")]
        public async Task<IActionResult> GetAddressByCep(string cep)
        {
            var address = await _cepService.GetAddressByCepAsync(cep);
            if (address == null)
            {
                return NotFound(new { Message = "CEP not found or invalid." });
            }
            return Ok(address);
        }
    }
}
