using System;
using System.Collections.Generic;

using Model = Discord.API.AuditLog;
using EntryModel = Discord.API.AuditLogEntry;

namespace Discord.WebSocket
{
    internal static class AuditLogHelper
    {
        private static readonly Dictionary<ActionType, Func<DiscordSocketClient, EntryModel,  IAuditLogData>> CreateMapping
            = new ()
        {
            [ActionType.GuildUpdated] = GuildUpdateAuditLogData.Create, // log

            // [ActionType.ChannelCreated] = ChannelCreateAuditLogData.Create,
            // [ActionType.ChannelUpdated] = ChannelUpdateAuditLogData.Create,
            // [ActionType.ChannelDeleted] = ChannelDeleteAuditLogData.Create,
            //
            // [ActionType.OverwriteCreated] = OverwriteCreateAuditLogData.Create,
            // [ActionType.OverwriteUpdated] = OverwriteUpdateAuditLogData.Create,
            // [ActionType.OverwriteDeleted] = OverwriteDeleteAuditLogData.Create,
            //
            // [ActionType.Kick] = KickAuditLogData.Create,
            // [ActionType.Prune] = PruneAuditLogData.Create,
            // [ActionType.Ban] = BanAuditLogData.Create,
            // [ActionType.Unban] = UnbanAuditLogData.Create,
            // [ActionType.MemberUpdated] = MemberUpdateAuditLogData.Create,
            // [ActionType.MemberRoleUpdated] = MemberRoleAuditLogData.Create,
            // [ActionType.MemberMoved] = MemberMoveAuditLogData.Create,
            // [ActionType.MemberDisconnected] = MemberDisconnectAuditLogData.Create,
            // [ActionType.BotAdded] = BotAddAuditLogData.Create,
            //
            // [ActionType.RoleCreated] = RoleCreateAuditLogData.Create,
            // [ActionType.RoleUpdated] = RoleUpdateAuditLogData.Create,
            // [ActionType.RoleDeleted] = RoleDeleteAuditLogData.Create,
            //
            // [ActionType.InviteCreated] = InviteCreateAuditLogData.Create,
            // [ActionType.InviteUpdated] = InviteUpdateAuditLogData.Create,
            // [ActionType.InviteDeleted] = InviteDeleteAuditLogData.Create,
            //
            // [ActionType.WebhookCreated] = WebhookCreateAuditLogData.Create,
            // [ActionType.WebhookUpdated] = WebhookUpdateAuditLogData.Create,
            // [ActionType.WebhookDeleted] = WebhookDeleteAuditLogData.Create,
            //
            // [ActionType.EmojiCreated] = EmoteCreateAuditLogData.Create,
            // [ActionType.EmojiUpdated] = EmoteUpdateAuditLogData.Create,
            // [ActionType.EmojiDeleted] = EmoteDeleteAuditLogData.Create,
            //
            // [ActionType.MessageDeleted] = MessageDeleteAuditLogData.Create,
            // [ActionType.MessageBulkDeleted] = MessageBulkDeleteAuditLogData.Create,
            // [ActionType.MessagePinned] = MessagePinAuditLogData.Create,
            // [ActionType.MessageUnpinned] = MessageUnpinAuditLogData.Create,
            //
            // [ActionType.EventCreate] = ScheduledEventCreateAuditLogData.Create,
            // [ActionType.EventUpdate] = ScheduledEventUpdateAuditLogData.Create,
            // [ActionType.EventDelete] = ScheduledEventDeleteAuditLogData.Create,
            //
            // [ActionType.ThreadCreate] = ThreadCreateAuditLogData.Create,
            // [ActionType.ThreadUpdate] = ThreadUpdateAuditLogData.Create,
            // [ActionType.ThreadDelete] = ThreadDeleteAuditLogData.Create,
        };

        public static IAuditLogData CreateData(DiscordSocketClient discord, EntryModel entry)
        {
            if (CreateMapping.TryGetValue(entry.Action, out var func))
                return func(discord, entry);

            return null;
        }
    }
}
