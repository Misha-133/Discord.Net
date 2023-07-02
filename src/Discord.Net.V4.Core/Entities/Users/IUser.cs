using System.Threading.Tasks;

namespace Discord;

/// <summary>
///     Represents a generic user.
/// </summary>
public interface IUser : ISnowflakeEntity, IMentionable, IPresence
{
    /// <summary>
    ///     Gets the identifier of this user's avatar.
    /// </summary>
    string? AvatarId { get; }

    /// <summary>
    ///     Gets the avatar URL for this user.
    /// </summary>
    /// <remarks>
    ///     This property retrieves a URL for this user's avatar. In event that the user does not have a valid avatar
    ///     (i.e. their avatar identifier is not set), this method will return <see langword="null"/>. If you wish to
    ///     retrieve the default avatar for this user, consider using <see cref="IUser.GetDefaultAvatarUrl"/> (see
    ///     example).
    /// </remarks>
    /// <example>
    ///     <para
    ///         >The following example attempts to retrieve the user's current avatar and send it to a channel; if one is
    ///         not set, a default avatar for this user will be returned instead.</para>
    ///     <code language="cs" region="GetAvatarUrl"
    ///           source="..\..\..\Discord.Net.Examples\Core\Entities\Users\IUser.Examples.cs"/>
    /// </example>
    /// <param name="format">The format to return.</param>
    /// <param name="size">The size of the image to return in. This can be any power of two between 16 and 2048.
    /// </param>
    /// <returns>
    ///     A string representing the user's avatar URL; <see langword="null"/> if the user does not have an avatar in place.
    /// </returns>
    string GetAvatarUrl(ImageFormat format = ImageFormat.Auto, ushort size = 128);

    /// <summary>
    ///     Gets the default avatar URL for this user.
    /// </summary>
    /// <remarks>
    ///     This property retrieves a URL for this user's default avatar generated by Discord (Discord logo followed
    ///     by a random color as its background). This property will always return a value as it is calculated based
    ///     on the user's <see cref="IUser.DiscriminatorValue"/> (<c>discriminator % 5</c>).
    /// </remarks>
    /// <returns>
    ///     A string representing the user's avatar URL.
    /// </returns>
    string GetDefaultAvatarUrl();

    /// <summary>
    ///     Gets the per-username unique ID for this user.
    /// </summary>
    string Discriminator { get; }

    /// <summary>
    ///     Gets the per-username unique ID for this user.
    /// </summary>
    ushort DiscriminatorValue { get; }

    /// <summary>
    ///     Gets a value that indicates whether this user is identified as a bot.
    /// </summary>
    /// <remarks>
    ///     This property retrieves a value that indicates whether this user is a registered bot application
    ///     (indicated by the blue BOT tag within the official chat client).
    /// </remarks>
    /// <returns>
    ///     <see langword="true"/> if the user is a bot application; otherwise <see langword="false"/>.
    /// </returns>
    bool IsBot { get; }

    /// <summary>
    ///     Gets a value that indicates whether this user is a webhook user.
    /// </summary>
    /// <returns>
    ///     <see langword="true"/> if the user is a webhook; otherwise <see langword="false"/>.
    /// </returns>
    bool IsWebhook { get; }

    /// <summary>
    ///     Gets the username for this user.
    /// </summary>
    string Username { get; }

    /// <summary>
    ///     Gets the public flags that are applied to this user's account.
    /// </summary>
    /// <remarks>
    ///     This value is determined by bitwise OR-ing <see cref="UserProperties"/> values together.
    /// </remarks>
    /// <returns>
    ///     The value of public flags for this user.
    /// </returns>
    UserProperties? PublicFlags { get; }

    /// <summary>
    ///     Creates the direct message channel of this user.
    /// </summary>
    /// <remarks>
    ///     This method is used to obtain or create a channel used to send a direct message.
    ///     <note type="warning">
    ///          In event that the current user cannot send a message to the target user, a channel can and will
    ///          still be created by Discord. However, attempting to send a message will yield a
    ///          <see cref="Discord.Net.HttpException"/> with a 403 as its
    ///          <see cref="Discord.Net.HttpException.HttpCode"/>. There are currently no official workarounds by
    ///          Discord.
    ///     </note>
    /// </remarks>
    /// <example>
    ///     <para>The following example attempts to send a direct message to the target user and logs the incident should
    ///     it fail.</para>
    ///     <code region="CreateDMChannelAsync" language="cs"
    ///           source="../../../Discord.Net.Examples/Core/Entities/Users/IUser.Examples.cs"/>
    /// </example>
    /// <param name="options">The options to be used when sending the request.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation for getting or creating a DM channel. The task result
    ///     contains the DM channel associated with this user.
    /// </returns>
    Task<IDMChannel> CreateDMChannelAsync(RequestOptions? options = null);
}
