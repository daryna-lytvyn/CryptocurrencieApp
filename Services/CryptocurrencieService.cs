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
    public class CryptocurrencieService : ICryptocurrencieService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<CryptocurrencieOptions> _сryptocurrencieOptions;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public CryptocurrencieService(HttpClient httpClient, IOptions<CryptocurrencieOptions> сryptocurrencieOptions, JsonSerializerOptions jsonSerializerOptions)
        {
            _httpClient = httpClient;
            _сryptocurrencieOptions = сryptocurrencieOptions;
            _jsonSerializerOptions = jsonSerializerOptions;
        }

        public async Task<IReadOnlyList<Cryptocurrencie>> GetCryptocurrenciesAsync(CancellationToken cancellationToken = default)
        {
            var uri = _сryptocurrencieOptions.Value.BaseUri + "/v2/assets";
            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            var response = await _httpClient.SendAsync(request, cancellationToken)
                                            .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var cryptocurrencies = await response.Content.ReadFromJsonAsync<ResponseCryptocurrencie>(_jsonSerializerOptions, cancellationToken)
                                                .ConfigureAwait(false);
                                               
            return cryptocurrencies.Data!.AsReadOnly();
        }
    }
}
