namespace Discord;

public interface IInteractableComponent : IMessageComponent
{
    /// <summary>
    ///     Gets the custom id of the component if possible; otherwise <see langword="null"/>.
    /// </summary>
    string CustomId { get; }
}
