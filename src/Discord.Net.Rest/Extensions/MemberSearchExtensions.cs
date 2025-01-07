using System.Collections.Generic;

namespace Discord.Rest;

internal static class MemberSearchExtensions
{
    internal static API.Rest.SearchQueryProperties ToModel(this IMemberSearchQuery props)
        => new ()
        {
            Range = props.Range.HasValue
                ? new API.Rest.SearchRangeProperties
                {
                    GreaterThanOrEqual = props.Range.Value.GreaterThanOrEqual.HasValue ? props.Range.Value.GreaterThanOrEqual.Value : Optional<long>.Unspecified,
                    LessThanOrEqual = props.Range.Value.LessThanOrEqual.HasValue ? props.Range.Value.LessThanOrEqual.Value : Optional<long>.Unspecified
                }
                : Optional<API.Rest.SearchRangeProperties>.Unspecified,
            AndQuery = props.AndQuery is not null ? new Optional<IEnumerable<object>>(props.AndQuery) : Optional<IEnumerable<object>>.Unspecified,
            OrQuery = props.OrQuery is not null ? new Optional<IEnumerable<object>>(props.OrQuery) : Optional<IEnumerable<object>>.Unspecified
        };

    internal static API.Rest.SafetySignalsProperties ToModel(this MemberSearchV2SafetySignalsProperties props)
        => new()
        {
            AutomodQuarantinedUsername = props.AutomodQuarantinedUsername ?? Optional<bool>.Unspecified,
            UnusualAccountActivity = props.UnusualAccountActivity ?? Optional<bool>.Unspecified,
            CommunicationDisabledUntil = props.CommunicationDisabledUntil?.ToModel() ?? Optional<API.Rest.SearchQueryProperties>.Unspecified,
            UnusualDMActivityUntil = props.UnusualDmActivityUntil?.ToModel() ?? Optional<API.Rest.SearchQueryProperties>.Unspecified,
        };

    internal static API.Rest.MemberSearchFilter ToModel(this MemberSearchFilter props)
        => new()
        {
            DidRejoin = props.DidRejoin ?? Optional<bool>.Unspecified,
            IsPending = props.IsPending ?? Optional<bool>.Unspecified,
            JoinSourceType = props.JoinSourceType?.ToModel() ?? Optional<API.Rest.SearchQueryProperties>.Unspecified,
            GuildJoinedAt = props.GuildJoinedAt?.ToModel() ?? Optional<API.Rest.SearchQueryProperties>.Unspecified,
            RoleIds = props.RoleIds?.ToModel() ?? Optional<API.Rest.SearchQueryProperties>.Unspecified,
            SourceInviteCode = props.SourceInviteCode?.ToModel() ?? Optional<API.Rest.SearchQueryProperties>.Unspecified,
            SafetySignals = props.SafetySignals?.ToModel() ?? Optional<API.Rest.SafetySignalsProperties>.Unspecified,
            UserId = props.UserId?.ToModel() ?? Optional<API.Rest.SearchQueryProperties>.Unspecified,
            Usernames = props.Usernames?.ToModel() ?? Optional<API.Rest.SearchQueryProperties>.Unspecified
        };
}
