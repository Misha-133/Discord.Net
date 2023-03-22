using Discord.API.AuditLogs;

using EntryModel = Discord.API.AuditLogEntry;
using Model = Discord.API.AuditLog;

namespace Discord.Rest;

/// <summary>
///     Contains a piece of audit log data related to a scheduled event updates.
/// </summary>
public class ScheduledEventUpdateAuditLogData : IAuditLogData
{
    private ScheduledEventUpdateAuditLogData(ulong id, ScheduledEventInfo before, ScheduledEventInfo after)
    {
        Id = id;
        Before = before;
        After = after;
    }

    internal static ScheduledEventUpdateAuditLogData Create(BaseDiscordClient discord, EntryModel entry, Model log)
    {
        var changes = entry.Changes;

        var (before, after) = AuditLogHelper.CreateAuditLogEntityInfo<ScheduledEventInfoAuditLogModel>(changes, discord);

        return new ScheduledEventUpdateAuditLogData(entry.TargetId!.Value, new(before), new(after));
    }

    // Doc Note: Corresponds to the *current* data

    /// <summary>
    ///     Gets the snowflake id of the event.
    /// </summary>
    public ulong Id { get; }

    /// <summary>
    ///     Gets the state before the change.
    /// </summary>
    public ScheduledEventInfo Before { get; }

    /// <summary>
    ///     Gets the state after the change.
    /// </summary>
    public ScheduledEventInfo After { get; }
}
