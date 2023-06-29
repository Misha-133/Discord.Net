using System.Text.Json.Serialization;

namespace Discord.API;

internal class AutoModAction
{
    [JsonPropertyName("type")]
    public AutoModActionType Type { get; set; }

    [JsonPropertyName("metadata")]
    public Optional<ActionMetadata> Metadata { get; set; }
}