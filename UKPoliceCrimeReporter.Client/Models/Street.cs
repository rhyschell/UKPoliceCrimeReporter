using System.Text.Json.Serialization;

namespace UKPoliceCrimeReporter.Client.Models;

public class Street
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}