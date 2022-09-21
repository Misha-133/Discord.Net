using System;
using System.Linq;
using System.Threading.Tasks;
using Model = Discord.API.Channel;

namespace Discord.Rest;

internal static class ForumHelper
{
    public static async Task<Model> ModifyAsync(IForumChannel channel, BaseDiscordClient client,
        Action<ForumChannelProperties> func,
        RequestOptions options)
    {
        var args = new ForumChannelProperties();
        func(args);
        var apiArgs = new API.Rest.ModifyForumChannelParams()
        {
            Name = args.Name,
            Position = args.Position,
            CategoryId = args.CategoryId,
            Overwrites = args.PermissionOverwrites.IsSpecified
                ? args.PermissionOverwrites.Value.Select(overwrite => new API.Overwrite
                {
                    TargetId = overwrite.TargetId,
                    TargetType = overwrite.TargetType,
                    Allow = overwrite.Permissions.AllowValue.ToString(),
                    Deny = overwrite.Permissions.DenyValue.ToString()
                }).ToArray()
                : Optional.Create<API.Overwrite[]>(),
            DefaultSlowModeInterval = args.DefaultSlowModeInterval,
            ThreadCreationInterval = args.ThreadCreationInterval,
            Tags = args.Tags.IsSpecified
                ? args.Tags.Value.Select(tag => new API.ForumTagParams
                {
                    Name = tag.Name,
                    EmojiId = tag.Emoji is Emote emote
                        ? emote.Id
                        : Optional<ulong?>.Unspecified,
                    EmojiName = tag.Emoji is Emoji emoji
                        ? emoji.Name
                        : Optional<string>.Unspecified
                }).ToArray()
                : Optional.Create<API.ForumTagParams[]>(),
            Flags = args.Flags.GetValueOrDefault(),
            Topic = args.Topic,
        };
        return await client.ApiClient.ModifyGuildChannelAsync(channel.Id, apiArgs, options).ConfigureAwait(false);
    }
}