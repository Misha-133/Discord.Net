using Discord.Audio;
using Discord.Net.V4.Core.API.Models;
using Discord.Net.V4.Core.API.Models.Channels;
using Discord.Net.V4.Core.API.Models.Guilds;
using Discord.WebSocket.Cache;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.WebSocket
{
    public class SocketGuild : SocketCacheableEntity<ulong, IGuildModel>, IGuild
    {
        internal record FactoryArgs(
            IEnumerable<IChannelModel>? Channels = null,
            IEnumerable<IRoleModel>? Roles = null,
            IEnumerable<IEmojiModel>? Emotes = null,
            IEnumerable<IStickerModel>? Stickers = null
        );

        public IAudioClient AudioClient => throw new NotImplementedException(); // TODO

        public IRole EveryoneRole => throw new NotImplementedException(); // TODO

        public IReadOnlyCollection<GuildEmote> Emotes => throw new NotImplementedException(); // TODO

        public IReadOnlyCollection<ICustomSticker> Stickers => throw new NotImplementedException(); // TODO

        public IReadOnlyCollection<IRole> Roles => throw new NotImplementedException(); // TODO

        public string Name
            => _source.Name;

        public int AFKTimeout
            => _source.AFKTimeout;

        public bool IsWidgetEnabled
            => _source.WidgetEnabled;

        public DefaultMessageNotifications DefaultMessageNotifications
            => _source.DefaultMessageNotification;

        public MfaLevel MfaLevel
            => _source.MFALevel;

        public VerificationLevel VerificationLevel
            => _source.VerificationLevel;

        public ExplicitContentFilterLevel ExplicitContentFilter
            => _source.ExplicitContentFilter;

        public string? IconId
            => _source.Icon;

        public string? IconUrl
            => CDN.GetGuildIconUrl(Id, IconId);

        public string? SplashId
            => _source.Splash;

        public string? SplashUrl
            => CDN.GetGuildSplashUrl(Id, SplashId);

        public string? DiscoverySplashId
            => _source.DiscoverySplash;

        public string? DiscoverySplashUrl
            => CDN.GetGuildDiscoverySplashUrl(Id, DiscoverySplashId);

        public ulong? AFKChannelId
            => _source.AFKChannel;

        public ulong? WidgetChannelId
            => _source.WidgetChannel;

        public ulong? SystemChannelId
            => _source.SystemChannel;

        public ulong? RulesChannelId
            => _source.RulesChannel;

        public ulong? PublicUpdatesChannelId
            => _source.PublicUpdatesChannel;

        public ulong OwnerId
            => _source.OwnerId;

        public ulong? ApplicationId
            => _source.ApplicationId;

        [Obsolete("Deprecated in API")]
        public string? VoiceRegionId
            => null;

        public GuildFeatures Features
            => _features;

        public PremiumTier PremiumTier
            => _source.PremiumTier;

        public string? BannerId
            => _source.Banner;

        public string? BannerUrl
            => CDN.GetGuildBannerUrl(Id, BannerId, ImageFormat.Auto);

        public string? VanityURLCode
            => _source.Vanity;

        public SystemChannelMessageDeny SystemChannelFlags
            => _source.SystemChannelFlags;

        public string? Description
            => _source.Description;

        public int PremiumSubscriptionCount
            => _source.PremiumSubscriptionCount;

        public int? MaxPresences
            => _source.MaxPresense;

        public int? MaxMembers
            => _source.MaxMembers;

        public int? MaxVideoChannelUsers
            => _source.MaxVideoChannelUsers;

        public int? ApproximateMemberCount
            => _source.ApproximateMemberCount;

        public int? ApproximatePresenceCount
            => _source.ApproximateMemberCount;

        public int MaxBitrate
        {
            get
            {
                return PremiumTier switch
                {
                    PremiumTier.Tier1 => 128000,
                    PremiumTier.Tier2 => 256000,
                    PremiumTier.Tier3 => 384000,
                    _ => 96000,
                };
            }
        }

        public string PreferredLocale
            => _source.PreferredLocale;

        public NsfwLevel NsfwLevel
            => _source.NsfwLevel;

        public CultureInfo PreferredCulture
            => new(PreferredLocale);

        public bool IsBoostProgressBarEnabled
            => _source.PremiumProgressBarEnabled.GetValueOrDefault(false);

        public ulong MaxUploadLimit
            => 0; // TODO: GuildHelper.GetUploadLimit(this);

        public DateTimeOffset CreatedAt => SnowflakeUtils.FromSnowflake(Id);

        public bool Available { get; internal set; }

        private IGuildModel _source;
        private GuildFeatures _features;

        internal SocketGuild(DiscordSocketClient discord, ulong id, IGuildModel model, FactoryArgs args) : base(discord, id)
        {
            _source = model;
            _features = new GuildFeatures(model.Features, model.ExperimentalFeatures);
        }

        internal override object Clone() => throw new NotImplementedException();
        internal override void DisposeClone() => throw new NotImplementedException();

        internal override IGuildModel GetModel()
            => _source;

        internal override void Update(IGuildModel model)
        {
            if(_source.Features != model.Features || !_source.ExperimentalFeatures.SequenceEqual(model.ExperimentalFeatures))
            {
                _features = new GuildFeatures(model.Features, model.ExperimentalFeatures);
            }

            _source = model;
        }

        public Task AddBanAsync(IUser user, int pruneDays = 0, string? reason = null, RequestOptions? options = null) => throw new NotImplementedException();
        public Task AddBanAsync(ulong userId, int pruneDays = 0, string? reason = null, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IGuildUser> AddGuildUserAsync(ulong userId, string accessToken, Action<AddGuildUserProperties>? func = null, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IReadOnlyCollection<IApplicationCommand>> BulkOverwriteApplicationCommandsAsync(ApplicationCommandProperties[] properties, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IApplicationCommand> CreateApplicationCommandAsync(ApplicationCommandProperties properties, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<ICategoryChannel> CreateCategoryAsync(string name, Action<GuildChannelProperties>? func = null, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<GuildEmote> CreateEmoteAsync(string name, Image image, Optional<IEnumerable<IRole>> roles = default(Optional<IEnumerable<IRole>>), RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IGuildScheduledEvent> CreateEventAsync(string name, DateTimeOffset startTime, GuildScheduledEventType type, GuildScheduledEventPrivacyLevel privacyLevel = GuildScheduledEventPrivacyLevel.Private, string? description = null, DateTimeOffset? endTime = null, ulong? channelId = null, string? location = null, Image? coverImage = null, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IRole> CreateRoleAsync(string name, GuildPermissions? permissions = null, Color? color = null, bool isHoisted = false, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IRole> CreateRoleAsync(string name, GuildPermissions? permissions = null, Color? color = null, bool isHoisted = false, bool isMentionable = false, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IStageChannel> CreateStageChannelAsync(string name, Action<VoiceChannelProperties>? func = null, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<ICustomSticker> CreateStickerAsync(string name, string description, IEnumerable<string> tags, Image image, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<ICustomSticker> CreateStickerAsync(string name, string description, IEnumerable<string> tags, string path, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<ICustomSticker> CreateStickerAsync(string name, string description, IEnumerable<string> tags, Stream stream, string filename, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<ITextChannel> CreateTextChannelAsync(string name, Action<TextChannelProperties>? func = null, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IVoiceChannel> CreateVoiceChannelAsync(string name, Action<VoiceChannelProperties>? func = null, RequestOptions? options = null) => throw new NotImplementedException();
        public Task DeleteAsync(RequestOptions? options = null) => throw new NotImplementedException();
        public Task DeleteEmoteAsync(GuildEmote emote, RequestOptions? options = null) => throw new NotImplementedException();
        public Task DeleteIntegrationAsync(ulong id, RequestOptions? options = null) => throw new NotImplementedException();
        public Task DeleteStickerAsync(ICustomSticker sticker, RequestOptions? options = null) => throw new NotImplementedException();
        public Task DisconnectAsync(IGuildUser user) => throw new NotImplementedException();
        public Task DownloadUsersAsync() => throw new NotImplementedException();
        public Task<IVoiceChannel> GetAFKChannelAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IApplicationCommand> GetApplicationCommandAsync(ulong id, CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IReadOnlyCollection<IApplicationCommand>> GetApplicationCommandsAsync(RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IReadOnlyCollection<IAuditLogEntry>> GetAuditLogsAsync(int limit = 100, CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null, ulong? beforeId = null, ulong? userId = null, ActionType? actionType = null) => throw new NotImplementedException();
        public Task<IBan> GetBanAsync(IUser user, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IBan> GetBanAsync(ulong userId, RequestOptions? options = null) => throw new NotImplementedException();
        public IAsyncEnumerable<IReadOnlyCollection<IBan>> GetBansAsync(int limit = 1000, RequestOptions? options = null) => throw new NotImplementedException();
        public IAsyncEnumerable<IReadOnlyCollection<IBan>> GetBansAsync(ulong fromUserId, Direction dir, int limit = 1000, RequestOptions? options = null) => throw new NotImplementedException();
        public IAsyncEnumerable<IReadOnlyCollection<IBan>> GetBansAsync(IUser fromUser, Direction dir, int limit = 1000, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IReadOnlyCollection<ICategoryChannel>> GetCategoriesAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IGuildChannel> GetChannelAsync(ulong id, CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IReadOnlyCollection<IGuildChannel>> GetChannelsAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IGuildUser> GetCurrentUserAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<ITextChannel> GetDefaultChannelAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<GuildEmote> GetEmoteAsync(ulong id, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IReadOnlyCollection<GuildEmote>> GetEmotesAsync(RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IGuildScheduledEvent> GetEventAsync(ulong id, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IReadOnlyCollection<IGuildScheduledEvent>> GetEventsAsync(RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IReadOnlyCollection<IIntegration>> GetIntegrationsAsync(RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IReadOnlyCollection<IInviteMetadata>> GetInvitesAsync(RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IGuildUser> GetOwnerAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<ITextChannel> GetPublicUpdatesChannelAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) => throw new NotImplementedException();
        public IRole GetRole(ulong id) => throw new NotImplementedException();
        public Task<ITextChannel> GetRulesChannelAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IStageChannel> GetStageChannelAsync(ulong id, CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IReadOnlyCollection<IStageChannel>> GetStageChannelsAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<ICustomSticker> GetStickerAsync(ulong id, CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IReadOnlyCollection<ICustomSticker>> GetStickersAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<ITextChannel> GetSystemChannelAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<ITextChannel> GetTextChannelAsync(ulong id, CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IReadOnlyCollection<ITextChannel>> GetTextChannelsAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IThreadChannel> GetThreadChannelAsync(ulong id, CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IReadOnlyCollection<IThreadChannel>> GetThreadChannelsAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IGuildUser> GetUserAsync(ulong id, CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IReadOnlyCollection<IGuildUser>> GetUsersAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IInviteMetadata> GetVanityInviteAsync(RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IVoiceChannel> GetVoiceChannelAsync(ulong id, CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IReadOnlyCollection<IVoiceChannel>> GetVoiceChannelsAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IReadOnlyCollection<IVoiceRegion>> GetVoiceRegionsAsync(RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IWebhook> GetWebhookAsync(ulong id, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IReadOnlyCollection<IWebhook>> GetWebhooksAsync(RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IGuildChannel> GetWidgetChannelAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) => throw new NotImplementedException();
        public Task LeaveAsync(RequestOptions? options = null) => throw new NotImplementedException();
        public Task ModifyAsync(Action<GuildProperties> func, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<GuildEmote> ModifyEmoteAsync(GuildEmote emote, Action<EmoteProperties> func, RequestOptions? options = null) => throw new NotImplementedException();
        public Task ModifyWidgetAsync(Action<GuildWidgetProperties> func, RequestOptions? options = null) => throw new NotImplementedException();
        public Task MoveAsync(IGuildUser user, IVoiceChannel targetChannel) => throw new NotImplementedException();
        public Task<int> PruneUsersAsync(int days = 30, bool simulate = false, RequestOptions? options = null, IEnumerable<ulong>? includeRoleIds = null) => throw new NotImplementedException();
        public Task RemoveBanAsync(IUser user, RequestOptions? options = null) => throw new NotImplementedException();
        public Task RemoveBanAsync(ulong userId, RequestOptions? options = null) => throw new NotImplementedException();
        public Task ReorderChannelsAsync(IEnumerable<ReorderChannelProperties> args, RequestOptions? options = null) => throw new NotImplementedException();
        public Task ReorderRolesAsync(IEnumerable<ReorderRoleProperties> args, RequestOptions? options = null) => throw new NotImplementedException();
        public Task<IReadOnlyCollection<IGuildUser>> SearchUsersAsync(string query, int limit = 1000, CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) => throw new NotImplementedException();
        
    }
}
