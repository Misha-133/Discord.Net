using Discord.WebSocket.Cache;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Discord.WebSocket
{
    public sealed class SocketGuildEvent : SocketCacheableEntity<ulong, IGuildEventModel>, IGuildScheduledEvent
    {
        public GuildCacheable Guild { get; }
        public GuildChannelCacheable Channel { get; }
        public GuildUserCacheable Creator { get; }

        public string Name
            => _source.Name;

        public string? Description
            => _source.Description;

        public string? CoverImageId
            => _source.Image;

        public DateTimeOffset StartTime
            => _source.StartTime;

        public DateTimeOffset? EndTime
            => _source.EndTime;

        public GuildScheduledEventPrivacyLevel PrivacyLevel
            => _source.PrivacyLevel;

        public GuildScheduledEventStatus Status
            => _source.Status;

        public GuildScheduledEventType Type
            => _source.Type;

        public ulong? EntityId
            => _source.EntityId;

        public string? Location
            => _source.Location;

        public int? UserCount
            => _source.UserCount;

        protected override IGuildEventModel Model
            => _source;

        private IGuildEventModel _source;

        public SocketGuildEvent(DiscordSocketClient discord, IGuildEventModel model)
            : base(discord, model.Id)
        {
            Update(model);

            Guild = new(model.GuildId, discord, discord.State.Guilds.SourceSpecific(model.GuildId));
            Channel = new(() => model.ChannelId.ToOptional(), discord, discord.State.GuildChannels.SourceSpecific);
            Creator = new(model.CreatorId, discord, discord.State.Members.SourceSpecific(model.CreatorId));
        }

        [MemberNotNull(nameof(_source))]
        internal override void Update(IGuildEventModel model)
        {
            _source = model;
        }

        public Task DeleteAsync(RequestOptions? options = null) => throw new NotImplementedException();
        public Task EndAsync(RequestOptions? options = null) => throw new NotImplementedException();
        public string GetCoverImageUrl(ImageFormat format = ImageFormat.Auto, ushort size = 1024) => throw new NotImplementedException();
        public IAsyncEnumerable<IReadOnlyCollection<IUser>> GetUsersAsync(RequestOptions? options = null) => throw new NotImplementedException();
        public IAsyncEnumerable<IReadOnlyCollection<IUser>> GetUsersAsync(ulong fromUserId, Direction dir, int limit = 100, RequestOptions? options = null) => throw new NotImplementedException();
        public Task ModifyAsync(Action<GuildScheduledEventsProperties> func, RequestOptions? options = null) => throw new NotImplementedException();
        public Task StartAsync(RequestOptions? options = null) => throw new NotImplementedException();
        internal override object Clone() => throw new NotImplementedException();
        internal override void DisposeClone() => throw new NotImplementedException();

        IGuild? IGuildScheduledEvent.Guild => Guild.Value;

        ulong IGuildScheduledEvent.GuildId => Guild.Id.Value;

        ulong? IGuildScheduledEvent.ChannelId => Channel.Id.ToNullable();

        IUser? IGuildScheduledEvent.Creator => Creator.Value;
    }
}

