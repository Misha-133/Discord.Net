using System.Text.Json.Serialization;

namespace Discord.API;

internal class ActivityTimestamps
{
    [JsonPropertyName("start")]
    public Optional<long> Start { get; set; }

    [JsonPropertyName("end")]
    public Optional<long> End { get; set; }
}
