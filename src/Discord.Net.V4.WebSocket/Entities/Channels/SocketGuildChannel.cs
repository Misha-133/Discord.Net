using Discord.Net.V4.Core.API.Models.Channels;
using Discord.WebSocket.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.WebSocket
{
    public abstract class SocketGuildChannel : SocketChannel, ICacheableEntity<ulong, IGuildChannelModel>, IGuildChannel
    {
        public int Position
            => Model.Position;

        public GuildCacheable Guild { get; }

        public IReadOnlyCollection<Overwrite> PermissionOverwrites => throw new NotImplementedException(); // TODO

        protected abstract override IGuildChannelModel Model { get; }

        internal SocketGuildChannel(DiscordSocketClient discord, ulong guildId, ulong id, IGuildChannelModel model)
            : base(discord, id, model)
        {
            Guild = new(guildId, discord, discord.State.Guilds.SourceSpecific(guildId));
        }

        IGuildChannelModel ICacheableEntity<ulong, IGuildChannelModel>.GetModel()
            => Model;

        void ICacheableEntity<ulong, IGuildChannelModel>.Update(IGuildChannelModel model)
            => Update(model);

        public Task AddPermissionOverwriteAsync(IRole role, OverwritePermissions permissions, RequestOptions? options = null) => throw new NotImplementedException();
        public Task AddPermissionOverwriteAsync(IUser user, OverwritePermissions permissions, RequestOptions? options = null) => throw new NotImplementedException();
        public Task DeleteAsync(RequestOptions? options = null) => throw new NotImplementedException();
        public OverwritePermissions? GetPermissionOverwrite(IRole role) => throw new NotImplementedException();
        public OverwritePermissions? GetPermissionOverwrite(IUser user) => throw new NotImplementedException();
        public Task ModifyAsync(Action<GuildChannelProperties> func, RequestOptions? options = null) => throw new NotImplementedException();
        public Task RemovePermissionOverwriteAsync(IRole role, RequestOptions? options = null) => throw new NotImplementedException();
        public Task RemovePermissionOverwriteAsync(IUser user, RequestOptions? options = null) => throw new NotImplementedException();
        IAsyncEnumerable<IReadOnlyCollection<IGuildUser>> IGuildChannel.GetUsersAsync(CacheMode mode, RequestOptions options) => throw new NotImplementedException();
        Task<IGuildUser> IGuildChannel.GetUserAsync(ulong id, CacheMode mode, RequestOptions options) => throw new NotImplementedException();


        #region IGuild
        IGuild IGuildChannel.Guild => Guild.Value!;
        ulong IGuildChannel.GuildId => Guild.Id;
        #endregion
    }
}
