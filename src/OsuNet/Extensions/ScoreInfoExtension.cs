namespace OsuNet.Models.Info {
    /// <summary>
    /// Extension for <see cref="ScoreInfo"/> model.
    /// </summary>
    public static class ScoreInfoExtension {
        /// <summary>
        /// Gets the avatar URL for this user.
        /// </summary>
        /// <returns>A string representing the user's avatar URL.</returns>
        public static string GetAvatar(this ScoreInfo score) => $"https://s.ppy.sh/a/{score.UserId}";

        /// <summary>
        /// Gets the URL of the user.
        /// </summary>
        /// <returns>A string representing the user's URL.</returns>
        public static string GetUrl(this ScoreInfo score) => $"https://osu.ppy.sh/users/{score.UserId}";
    }
}
