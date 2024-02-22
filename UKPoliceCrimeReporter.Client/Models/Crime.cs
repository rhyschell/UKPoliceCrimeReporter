using System.Text.Json.Serialization;

namespace UKPoliceCrimeReporter.Client.Models;

public class Crime
{
    [JsonPropertyName("category")]
    public string Category { get; set; }

    [JsonPropertyName("location_type")]
    public string LocationType { get; set; }

    [JsonPropertyName("location")]
    public Location Location { get; set; }

    [JsonPropertyName("context")]
    public string Context { get; set; }

    [JsonPropertyName("outcome_status")]
    public OutcomeStatus OutcomeStatus { get; set; }

    [JsonPropertyName("persistent_id")]
    public string PersistentId { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("location_subtype")]
    public string LocationSubtype { get; set; }

    [JsonPropertyName("month")]
    public string Month { get; set; }
}