using System.Collections.Immutable;
using System.Linq;

namespace Discord.Rest;

internal static class MessageComponentExtension
{
    internal static IMessageComponent ToModel(this IMessageComponent component)
    {
        switch (component)
        {
            case ButtonComponent btn:
                return new API.ButtonComponent(btn);

            case SelectMenuComponent select:
                return new API.SelectMenuComponent(select);

            case TextInputComponent textInput:
                return new API.TextInputComponent(textInput);

            case TextDisplayComponent textDisplay:
                return new API.TextDisplayComponent(textDisplay);
        }

        return null;
    }

    internal static IMessageComponent ToEntity(this IMessageComponent component)
    {
        switch (component.Type)
        {
            case ComponentType.ActionRow:
            {
                var parsed = (API.ActionRowComponent)component;
                return new ActionRowComponent()
                {
                    Id = component.Id,
                    Components = parsed.Components.Select(x => x.ToEntity()).ToImmutableArray()
                };
            }

            case ComponentType.Button:
            {
                var parsed = (API.ButtonComponent)component;
                return new ButtonComponent(
                    parsed.Style,
                    parsed.Label.GetValueOrDefault(),
                    parsed.Emote.IsSpecified
                        ? parsed.Emote.Value.Id.HasValue
                            ? new Emote(parsed.Emote.Value.Id.Value, parsed.Emote.Value.Name, parsed.Emote.Value.Animated.GetValueOrDefault())
                            : new Emoji(parsed.Emote.Value.Name)
                        : null,
                    parsed.CustomId.GetValueOrDefault(),
                    parsed.Url.GetValueOrDefault(),
                    parsed.Disabled.GetValueOrDefault(),
                    parsed.SkuId.ToNullable(),
                    parsed.Id.ToNullable());
            }

            case ComponentType.SelectMenu or ComponentType.ChannelSelect or ComponentType.RoleSelect or ComponentType.MentionableSelect or ComponentType.UserSelect:
            {
                var parsed = (API.SelectMenuComponent)component;
                return new SelectMenuComponent(
                    parsed.CustomId,
                    parsed.Options?.Select(z => new SelectMenuOption(
                        z.Label,
                        z.Value,
                        z.Description.GetValueOrDefault(),
                        z.Emoji.IsSpecified
                            ? z.Emoji.Value.Id.HasValue
                                ? new Emote(z.Emoji.Value.Id.Value, z.Emoji.Value.Name, z.Emoji.Value.Animated.GetValueOrDefault())
                                : new Emoji(z.Emoji.Value.Name)
                            : null,
                        z.Default.ToNullable())).ToList(),
                    parsed.Placeholder.GetValueOrDefault(),
                    parsed.MinValues,
                    parsed.MaxValues,
                    parsed.Disabled,
                    parsed.Type,
                    parsed.Id.ToNullable(),
                    parsed.ChannelTypes.GetValueOrDefault(),
                    parsed.DefaultValues.IsSpecified
                        ? parsed.DefaultValues.Value.Select(x => new SelectMenuDefaultValue(x.Id, x.Type))
                        : []
                );
            }

            case ComponentType.TextDisplay:
            {
                var parsed = (API.TextDisplayComponent)component;
                return new TextDisplayComponent(parsed.Id.ToNullable(), parsed.Content);
            }

            default:
                return null;
        }
    }
}
