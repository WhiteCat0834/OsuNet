using Newtonsoft.Json;
using OsuNet.Enums;

namespace OsuNet.Models {
    /// <summary>
    /// Represents beatmap information from the osu! API, containing metadata and difficulty settings.
    /// </summary>
    public record Beatmap(
        /// <summary>
        /// Unique beatmap SET ID (used to identify an album).
        /// </summary>
        [JsonProperty("beatmapset_id")] ulong BeatmapSetId,

        /// <summary>
        /// Unique beatmap ID (used to identify the beatmap).
        /// </summary>
        [JsonProperty("beatmap_id")] ulong BeatmapId,

        /// <summary>
        /// Map status.
        /// </summary>
        [JsonProperty("approved")] ApproveStatus Approved,

        /// <summary>
        /// The duration of the map in seconds.
        /// </summary>
        [JsonProperty("total_length")] ulong TotalLength,

        /// <summary>
        /// Seconds from first note to last note (not including breaks).
        /// </summary>
        [JsonProperty("hit_length")] ulong HitLength,

        /// <summary>
        /// Difficulty name.
        /// </summary>
        [JsonProperty("version")] string Version,

        /// <summary>
        /// MD5 hash of the beatmap.
        /// </summary>
        [JsonProperty("file_md5")] string FileMD5,

        /// <summary>
        /// Circle size value (CS).
        /// </summary>
        [JsonProperty("diff_size")] float DiffSize,

        /// <summary>
        /// Overall difficulty (OD).
        /// </summary>
        [JsonProperty("diff_overall")] float DiffOverall,

        /// <summary>
        /// Approach rate (AR).
        /// </summary>
        [JsonProperty("diff_approach")] float DiffApproach,

        /// <summary>
        /// Health drain (HP).
        /// </summary>
        [JsonProperty("diff_drain")] float DiffDrain,

        /// <summary>
        /// Game mode.
        /// </summary>
        [JsonProperty("mode")] BeatmapMode Mode,

        /// <summary>
        /// Count of notes on the map.
        /// </summary>
        [JsonProperty("count_normal")] ulong CountNormal,

        /// <summary>
        /// Count of sliders on the map.
        /// </summary>
        [JsonProperty("count_slider")] ulong CountSlider,

        /// <summary>
        /// Count of spinners on the map.
        /// </summary>
        [JsonProperty("count_spinner")] ulong CountSpinner,

        /// <summary>
        /// Date submitted.
        /// </summary>
        [JsonProperty("submit_date")] DateTime? SubmitDate,

        /// <summary>
        /// Date ranked.
        /// </summary>
        [JsonProperty("approved_date")] DateTime? ApprovedDate,

        /// <summary>
        /// Last update date, in UTC. May be after approved_date if map was unranked and reranked.
        /// </summary>
        [JsonProperty("last_update")] DateTime? LastUpdate,

        /// <summary>
        /// Song artist.
        /// </summary>
        [JsonProperty("artist")] string Artist,

        /// <summary>
        /// Song artist in Unicode.
        /// </summary>
        [JsonProperty("artist_unicode")] string ArtistUnicode,

        /// <summary>
        /// Song name.
        /// </summary>
        [JsonProperty("title")] string Title,

        /// <summary>
        /// Song name in Unicode.
        /// </summary>
        [JsonProperty("title_unicode")] string TitleUnicode,

        /// <summary>
        /// Creator nickname.
        /// </summary>
        [JsonProperty("creator")] string Creator,

        /// <summary>
        /// Creator ID.
        /// </summary>
        [JsonProperty("creator_id")] ulong CreatorId,

        /// <summary>
        /// The BPM of this beatmap.
        /// </summary>
        [JsonProperty("bpm")] float? BPM,

        /// <summary>
        /// Source of the beatmap.
        /// </summary>
        [JsonProperty("source")] string Source,

        /// <summary>
        /// Beatmap tags separated by spaces.
        /// </summary>
        [JsonProperty("tags")] string Tags,

        /// <summary>
        /// Song genre.
        /// </summary>
        [JsonProperty("genre_id")] Genre GenreId,

        /// <summary>
        /// Map language.
        /// </summary>
        [JsonProperty("language_id")] Language LanguageId,

        /// <summary>
        /// Number of times the beatmap was favourited.
        /// </summary>
        [JsonProperty("favourite_count")] ulong FavouriteCount,

        /// <summary>
        /// The rating of this beatmap.
        /// </summary>
        [JsonProperty("rating")] float Rating,

        /// <summary>
        /// If this beatmap has a storyboard.
        /// </summary>
        [JsonProperty("storyboard")] bool Storyboard,

        /// <summary>
        /// If this beatmap has a video.
        /// </summary>
        [JsonProperty("video")] bool Video,

        /// <summary>
        /// If the download for this beatmap is unavailable.
        /// </summary>
        [JsonProperty("download_unavailable")] bool DownloadUnavailable,

        /// <summary>
        /// If the audio for this beatmap is unavailable.
        /// </summary>
        [JsonProperty("audio_unavailable")] bool AudioUnavailable,

        /// <summary>
        /// Number of times the beatmap was played.
        /// </summary>
        [JsonProperty("playcount")] ulong PlayCount,

        /// <summary>
        /// Number of times the beatmap was passed.
        /// </summary>
        [JsonProperty("passcount")] ulong PassCount,

        /// <summary>
        /// Packs that contain this beatmap.
        /// </summary>
        [JsonProperty("packs")] string Packs,

        /// <summary>
        /// The maximum combo a user can reach playing this beatmap.
        /// </summary>
        [JsonProperty("max_combo")] ulong? MaxCombo,

        /// <summary>
        /// The aim difficulty of this beatmap.
        /// </summary>
        [JsonProperty("diff_aim")] float? DiffAim,

        /// <summary>
        /// The speed difficulty of this beatmap.
        /// </summary>
        [JsonProperty("diff_speed")] float? DiffSpeed,

        /// <summary>
        /// The number of stars the map would have in-game and on the website.
        /// </summary>
        [JsonProperty("difficultyrating")] float DifficultyRating
    );
}