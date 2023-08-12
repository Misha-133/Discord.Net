using Newtonsoft.Json;
using System;
namespace Discord.WebSocket.Cache
{
    public interface IGuildEventModel : IEntityModel<ulong>
    {
        ulong GuildId { get; }
        ulong? ChannelId { get; }
        ulong CreatorId { get; }
        string Name { get; }
        string? Description { get; }
        DateTimeOffset StartTime { get; }
        DateTimeOffset? EndTime { get; }
        GuildScheduledEventPrivacyLevel PrivacyLevel { get; }
        GuildScheduledEventStatus Status { get; }
        GuildScheduledEventType Type { get; }
        ulong? EntityId { get; }
        int? UserCount { get; }
        string? Image { get; }

        // metadata
        string? Location { get; }
    }
}

