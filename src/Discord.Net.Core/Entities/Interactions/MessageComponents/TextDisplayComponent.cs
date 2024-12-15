namespace Discord;

public class TextDisplayComponent : IMessageComponent
{
    public ComponentType Type => ComponentType.TextDisplay;

    public int? Id { get; }

    public string Content { get; }

    internal TextDisplayComponent(int? id, string content)
    {
        Id = id;
        Content = content;
    }
}
