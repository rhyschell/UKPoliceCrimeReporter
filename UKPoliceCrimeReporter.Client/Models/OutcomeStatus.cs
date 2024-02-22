using System.Text.Json.Serialization;

namespace UKPoliceCrimeReporter.Client.Models;

public class OutcomeStatus
{
    [JsonPropertyName("category")]
    public string Category { get; set; }

    [JsonPropertyName("date")]
    public string Date { get; set; }
}