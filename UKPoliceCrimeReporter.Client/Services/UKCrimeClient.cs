using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;
using UKPoliceCrimeReporter.Client.Interfaces;
using UKPoliceCrimeReporter.Client.Models;
using UKPoliceCrimeReporter.Client.Options;
using static UKPoliceCrimeReporter.Client.Constants;

namespace UKPoliceCrimeReporter.Client.Services;

//NOTE: category "enum" can be found here - https://data.police.uk/docs/method/crime-street/
//if I've got time, I could have a category clean name mapping routine

public class UKCrimeClient : IUKCrimeClient
{
    private readonly ILogger<UKCrimeClient> _logger;
    private readonly HttpClient _httpClient;

    public UKCrimeClient(ILogger<UKCrimeClient> logger, IOptions<UKCrimeClientOptions> settings)
    {
        _logger = logger;

        //guard - make sure we got settings
        if (settings == null || settings.Value == null) throw new ArgumentNullException(nameof(settings));
        if (string.IsNullOrEmpty(settings.Value.BaseAddress)) throw new ArgumentNullException(nameof(settings.Value.BaseAddress));

        //must have a / at the end to work properly with HttpClient
        //TODO: Create a string helper to ensure this is the case, might do at the end if have time - ultimately we are in control of the URL being set in the config
        string baseUrl = settings.Value.BaseAddress;

        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(baseUrl)
        };
    }

    public async Task<List<Crime>?> GetAllCrimesForLocationAsync(double latitude, double longitude, DateTime date)
    {
        // - crimes-street/all-crime
        string endpoint = $"{API_ENDPOINT_CRIMES_STREET}/{API_ENDPOINT_ALL_CRIMES}";

        string dateString = $"{date.Year}-{date.Month}";

        //there might be a use case for moving this a shared method, but given that this is the only endpoint we're implementing, fine for now
        List<string> queryParameters = new List<string>()
        {
            $"{API_QUERY_PARAMETER_LATITUDE}={latitude}",
            $"{API_QUERY_PARAMETER_LONGITUTE}={longitude}",
            $"{API_QUERY_PARAMETER_DATE}={dateString}",
        };

        //build the query and final endpoint we'll use in the API
        string queryString = string.Join("&", queryParameters);
        string finalEndpoint = endpoint + $"?{queryString}";

        var response = await _httpClient.GetAsync(finalEndpoint);
        _logger.LogInformation($"{nameof(GetAllCrimesForLocationAsync)} - endpoint: {finalEndpoint} | response code: {(int)response.StatusCode}");

        //make sure we have a successful call - if not just throw an exception to be caught by the caller of this method
        response.EnsureSuccessStatusCode();

        //fall through - valid response
        string responseString = await response.Content.ReadAsStringAsync();
        List<Crime>? crimes = JsonSerializer.Deserialize<List<Crime>>(responseString);
        return crimes;
    }

    public async Task<DateTime?> GetCrimeLastUpdatedDateAsync()
    {
        // - crime-last-updated
        string endpoint = $"{API_ENDPOINT_CRIME_LAST_UPDATED}";

        var response = await _httpClient.GetAsync(endpoint);
        _logger.LogInformation($"{nameof(GetCrimeLastUpdatedDateAsync)} - endpoint: {endpoint} | response code: {(int)response.StatusCode}");

        //make sure we have a successful call - if not just throw an exception to be caught by the caller of this method
        response.EnsureSuccessStatusCode();

        //fall through - valid response
        string responseString = await response.Content.ReadAsStringAsync();
        CrimeLastUpdatedResponse? responseModel = JsonSerializer.Deserialize<CrimeLastUpdatedResponse>(responseString);
        return responseModel?.Date;
    }

    public void Dispose()
    {
        //we only need to dispose of the client for now
        _httpClient.Dispose();
    }
}