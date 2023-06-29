using System.Text.Json.Serialization;

namespace Discord.API;

internal class EmbedAuthor
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public Optional<string> Url { get; set; }

    [JsonPropertyName("icon_url")]
    public Optional<string> IconUrl { get; set; }

    [JsonPropertyName("proxy_icon_url")]
    public Optional<string> ProxyIconUrl { get; set; }
}
