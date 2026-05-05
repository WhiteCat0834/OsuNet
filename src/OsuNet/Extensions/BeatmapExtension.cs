namespace OsuNet.Models {
    /// <summary>
    /// Extension for <see cref="Beatmap"/> model.
    /// </summary>
    public static class BeatmapExtension {
        /// <summary>
        /// Gets the cover URL for this Beatmap.
        /// </summary>
        /// <returns>A string representing the beatmaps cover URL</returns>
        public static string GetCover(this Beatmap beatmap) => $"https://assets.ppy.sh/beatmaps/{beatmap.BeatmapSetId}/covers/cover.jpg";

        /// <summary>
        /// Gets the thumbnail URL for this Beatmap.
        /// </summary>
        /// <returns>A string representing the beatmaps thumbnail URL</returns>
        public static string GetThumbnail(this Beatmap beatmap) => $"https://b.ppy.sh/thumb/{beatmap.BeatmapSetId}l.jpg";

        /// <summary>
        /// Gets the URL of this beatmap creator.
        /// </summary>
        /// <returns>A string representing the URL of the map creator.</returns>
        public static string GetCreatorUrl(this Beatmap beatmap) => $"https://osu.ppy.sh/users/{beatmap.CreatorId}";

        /// <summary>
        /// Gets the URL of this beatmap creator's avatar.
        /// </summary>
        /// <returns>A string representing the URL of the map creator's avatar.</returns>
        public static string GetCreatorAvatar(this Beatmap beatmap) => $"https://s.ppy.sh/a/{beatmap.CreatorId}";

        /// <summary>
        /// Gets the URL of the beatmap.
        /// </summary>
        /// <returns>A string representing the URL of the beatmap.</returns>
        public static string GetUrl(this Beatmap beatmap) => $"https://osu.ppy.sh/beatmapsets/{beatmap.BeatmapSetId}#" +
            $"{beatmap.Mode.ToString().ToLower()}/{beatmap.BeatmapId}";
    }
}
