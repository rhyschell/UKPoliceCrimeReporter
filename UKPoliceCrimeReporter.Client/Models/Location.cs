using System.Text.Json.Serialization;

namespace UKPoliceCrimeReporter.Client.Models;

public class Location
{
    [JsonPropertyName("latitude")]
    public string Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public string Longitude { get; set; }

    [JsonPropertyName("street")]
    public Street Street { get; set; }
}