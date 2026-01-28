using Microsoft.AspNetCore.Mvc;
using ViaCEP_Test.Interfaces;
using ViaCEP_Test.Models;

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
            CepResponse? address = await _cepService.GetAddressByCepAsync(cep);
            if (address is null)
                return NotFound("CEP não encontrado");

            return Ok(address);
        }
    }
}
