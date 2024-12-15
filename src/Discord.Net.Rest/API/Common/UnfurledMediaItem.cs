using Newtonsoft.Json;

namespace Discord.API;

public class UnfurledMediaItem
{
    [JsonProperty("url")]
    public string Url { get; set; }
}
