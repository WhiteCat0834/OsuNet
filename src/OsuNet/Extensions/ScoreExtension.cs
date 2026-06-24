namespace OsuNet.Models {
    /// <summary>
    /// Extension for <see cref="Score"/> model.
    /// </summary>
    public static class ScoreExtension {

        /// <summary>
        /// Gets the avatar URL for this user.
        /// </summary>
        /// <returns>A string representing the user's avatar URL.</returns>
        public static string GetAvatar(this Score score) => $"https://s.ppy.sh/a/{score.UserId}";

        /// <summary>
        /// Gets the URL of the user.
        /// </summary>
        /// <returns>A string representing the user's URL.</returns>
        public static string GetUrl(this Score score) => $"https://osu.ppy.sh/users/{score.UserId}";
    }
}
