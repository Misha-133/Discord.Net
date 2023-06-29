using System.Text.Json.Serialization;

namespace Discord.API;

internal class ActivityParty
{
    [JsonPropertyName("id")]
    public Optional<string> Id { get; set; }

    [JsonPropertyName("size")]
    public Optional<long[]> Size { get; set; }
}
