using System.Text.Json.Serialization;

namespace UKPoliceCrimeReporter.Client.Models;

public class CrimeLastUpdatedResponse
{
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }
}