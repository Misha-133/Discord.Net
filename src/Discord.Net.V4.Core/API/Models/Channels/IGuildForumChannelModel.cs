namespace Discord.Models
{
    public interface IGuildForumChannelModel : IGuildChannelModel
    {
        bool IsNsfw { get; }
        string? Topic { get; }
        ThreadArchiveDuration DefaultAutoArchiveDuration { get; }
        IForumTagModel[] Tags { get; }
    }

    public interface IForumTagModel
    {
        ulong Id { get; }
        string Name { get; }
        IEmojiModel? Emote { get; }
    }
}
