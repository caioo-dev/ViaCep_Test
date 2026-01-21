using ViaCEP_Test.Models;

namespace ViaCEP_Test.Interfaces
{
    public interface ICepService
    {
        Task<CepResponse?> GetAddressByCepAsync(string cep);
    }
}
