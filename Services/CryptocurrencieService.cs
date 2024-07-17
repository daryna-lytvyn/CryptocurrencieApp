using CryptocurrencieApp.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;


namespace CryptocurrencieApp.Services
{
    internal class CryptocurrencieService : ICryptocurrencieService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<CryptocurrencieOptions> _сryptocurrencieOptions;

        public CryptocurrencieService(HttpClient httpClient, IOptions<CryptocurrencieOptions> сryptocurrencieOptions)
        {
            _httpClient = httpClient;
            _сryptocurrencieOptions = сryptocurrencieOptions;
        }

        public async Task<IReadOnlyList<Cryptocurrencie>> GetCryptocurrenciesAsync(CancellationToken cancellationToken = default)
        {
            var uri = _сryptocurrencieOptions.Value.BaseUri + "/v2/assets";
            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            var response = await _httpClient.SendAsync(request, cancellationToken)
                                            .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString
            };

            var cryptocurrencies = await response.Content.ReadFromJsonAsync<ResponseCryptocurrencie>(options, cancellationToken)
                                                .ConfigureAwait(false);
                                               
            return cryptocurrencies.Data!.AsReadOnly();
        }
    }
}
