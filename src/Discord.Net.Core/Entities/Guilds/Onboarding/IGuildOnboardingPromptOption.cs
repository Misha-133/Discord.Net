using System;

namespace Discord;

/// <summary>
///     
/// </summary>
public interface IGuildOnboardingPromptOption : ISnowflakeEntity
{
    /// <summary>
    /// 
    /// </summary>
    ulong[] ChannelIds { get; }

    /// <summary>
    /// 
    /// </summary>
    IGuildChannel[] Channels { get; }

    /// <summary>
    /// 
    /// </summary>
    ulong[] RoleIds { get; }

    /// <summary>
    /// 
    /// </summary>
    IRole[] Roles { get; }

    /// <summary>
    /// 
    /// </summary>
    public IEmote Emoji { get; }
}
