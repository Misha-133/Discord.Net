namespace Discord;

public class TextDisplayComponentBuilder
{
    public int? Id { get; set; }

    private string _content;
    public string Content
    {
        get => _content;
        set => _content = value;
    }

    public TextDisplayComponent Build()
    {
        return new(Id, _content);
    }
}
