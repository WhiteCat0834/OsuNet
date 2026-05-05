namespace OsuNet.Models {
    /// <summary>
    /// Extension for <see cref="UserRecent"/> model.
    /// </summary>
    public static class UserRecentExtension {
        /// <summary>
        /// Gets the avatar URL for this user.
        /// </summary>
        /// <returns>A string representing the user's avatar URL.</returns>
        public static string GetAvatar(this UserRecent userRecent) => $"https://s.ppy.sh/a/{userRecent.UserId}";

        /// <summary>
        /// Gets the URL of the user.
        /// </summary>
        /// <returns>A string representing the user's URL.</returns>
        public static string GetUrl(this UserRecent userRecent) => $"https://osu.ppy.sh/users/{userRecent.UserId}";
    }
}
