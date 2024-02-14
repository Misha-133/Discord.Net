using EntryModel = Discord.API.AuditLogEntry;

namespace Discord.WebSocket;

/// <summary>
///     Contains a piece of audit log data related to message getting flagged by automod.
/// </summary>
public class SocketAutoModFlaggedMessageAuditLogData : ISocketAuditLogData
{
    internal SocketAutoModFlaggedMessageAuditLogData(ulong? channelId, string autoModRuleName, AutoModTriggerType autoModRuleTriggerType)
    {
        ChannelId = channelId;
        AutoModRuleName = autoModRuleName;
        AutoModRuleTriggerType = autoModRuleTriggerType;
    }

    internal static SocketAutoModFlaggedMessageAuditLogData Create(DiscordSocketClient discord, EntryModel entry)
    {
        return new(entry.Options.ChannelId, entry.Options.AutoModRuleName,
            entry.Options.AutoModRuleTriggerType!.Value);
    }

    /// <summary>
    ///     Gets the channel the message was sent in. May be <see langword="null"/> if a user profile was flagged.
    /// </summary>
    public ulong? ChannelId { get; set; }

    /// <summary>
    ///     Gets the name of the auto moderation rule that got triggered.
    /// </summary>
    public string AutoModRuleName { get; set; }

    /// <summary>
    ///     Gets the trigger type of the auto moderation rule that got triggered.
    /// </summary>
    public AutoModTriggerType AutoModRuleTriggerType { get; set; }
}
