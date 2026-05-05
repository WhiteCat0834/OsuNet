namespace OsuNet.Models {
    /// <summary>
    /// Extension for <see cref="UserBest"/> model.
    /// </summary>
    public static class UserBestExtension {
        /// <summary>
        /// Gets the avatar URL for this user.
        /// </summary>
        /// <returns>A string representing the user's avatar URL.</returns>
        public static string GetAvatar(this UserBest userBest) => $"https://s.ppy.sh/a/{userBest.UserId}";

        /// <summary>
        /// Gets the URL of the user.
        /// </summary>
        /// <returns>A string representing the user's URL.</returns>
        public static string GetUrl(this UserBest userBest) => $"https://osu.ppy.sh/users/{userBest.UserId}";
    }
}
