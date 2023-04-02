namespace Discord.Rest
{
    /// <summary>
    ///     Represents information for a member.
    /// </summary>
    public struct MemberInfo
    {
        internal MemberInfo(string nick, bool? deaf, bool? mute)
        {
            Nickname = nick;
            Deaf = deaf;
            Mute = mute;
        }

        /// <summary>
        ///     Gets the nickname of the updated member.
        /// </summary>
        /// <returns>
        ///     A string representing the nickname of the updated member; <see langword="null" /> if none is set.
        /// </returns>
        public string Nickname { get; }
        /// <summary>
        ///     Gets a value that indicates whether the updated member is deafened by the guild.
        /// </summary>
        /// <returns>
        ///     <see langword="true" /> if the updated member is deafened (i.e. not permitted to listen to or speak to others) by the guild;
        ///     otherwise <see langword="false" />.
        ///     <see langword="null" /> if this is not mentioned in this entry.
        /// </returns>
        public bool? Deaf { get; }
        /// <summary>
        ///     Gets a value that indicates whether the updated member is muted (i.e. not permitted to speak via voice) by the
        ///     guild.
        /// </summary>
        /// <returns>
        ///     <see langword="true" /> if the updated member is muted by the guild; otherwise <see langword="false" />.
        ///     <see langword="null" /> if this is not mentioned in this entry.
        /// </returns>
        public bool? Mute { get; }
    }
}
