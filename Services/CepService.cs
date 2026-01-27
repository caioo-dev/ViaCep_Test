using System.Text.Json;
using ViaCEP_Test.Interfaces;
using ViaCEP_Test.Models;

namespace ViaCEP_Test.Services
{
    public class CepService : ICepService
    {
        private readonly HttpClient _http;

        public CepService(HttpClient httpClient)
        {
            _http = httpClient;
        }

        public async Task<CepResponse?> GetAddressByCepAsync(string cep)
        {
            // Usa caminho relativo porque BaseAddress foi configurada no Program.cs
            string relativeUri = $"ws/{cep}/json/";
            try
            {
                CepResponse? address = await _http.GetFromJsonAsync<CepResponse>(relativeUri, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return address;
            }
            catch (HttpRequestException)
            {
                // tratar exceções de rede se necessário
                return null;
            }
        }
    }
}
