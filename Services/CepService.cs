using System.Text.Json;
using ViaCEP_Test.Interfaces;
using ViaCEP_Test.Models;
using Microsoft.Extensions.Caching.Memory;

namespace ViaCEP_Test.Services
{
    public class CepService : ICepService
    {
        private readonly HttpClient _http;
        private readonly IMemoryCache _cache;

        public CepService(HttpClient httpClient, IMemoryCache cache)
        {
            _http = httpClient;
            _cache = cache;
        }

        public async Task<CepResponse?> GetAddressByCepAsync(string cep)
        {
            if (_cache.TryGetValue(cep, out CepResponse cached))
                return cached;

            string relativeUri = $"ws/{cep}/json/";
            try
            {
                CepResponse? address = await _http.GetFromJsonAsync<CepResponse>(relativeUri, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                _cache.Set(cep, address, TimeSpan.FromHours(6));
                return address;
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
    }
}
