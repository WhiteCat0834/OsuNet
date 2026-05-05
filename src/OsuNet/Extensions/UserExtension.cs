namespace OsuNet.Models {
    /// <summary>
    /// Extension for <see cref="User"/> model.
    /// </summary>
    public static class UserExtension {
        /// <summary>
        /// Gets the avatar URL for this user.
        /// </summary>
        /// <returns>A string representing the user's avatar URL.</returns>
        public static string GetAvatar(this User user) => $"https://s.ppy.sh/a/{user.UserId}";

        /// <summary>
        /// Gets the URL of the user.
        /// </summary>
        /// <returns>A string representing the user's URL.</returns>
        public static string GetUrl(this User user) => $"https://osu.ppy.sh/users/{user.UserId}";
    }
}
