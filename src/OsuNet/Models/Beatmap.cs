using OsuNet.Enums;
using System.Text.Json.Serialization;

namespace OsuNet.Models {
    /// <summary>
    /// Represents beatmap information from the osu! API, containing metadata and difficulty settings.
    /// </summary>
    public record Beatmap(
        /// <summary>
        /// Unique beatmap SET ID (used to identify an album).
        /// </summary>
        [property: JsonPropertyName("beatmapset_id")] ulong BeatmapSetId,

        /// <summary>
        /// Unique beatmap ID (used to identify the beatmap).
        /// </summary>
        [property: JsonPropertyName("beatmap_id")] ulong BeatmapId,

        /// <summary>
        /// Map status.
        /// </summary>
        [property: JsonPropertyName("approved")] ApproveStatus Approved,

        /// <summary>
        /// The duration of the map in seconds.
        /// </summary>
        [property: JsonPropertyName("total_length")] ulong TotalLength,

        /// <summary>
        /// Seconds from first note to last note (not including breaks).
        /// </summary>
        [property: JsonPropertyName("hit_length")] ulong HitLength,

        /// <summary>
        /// Difficulty name.
        /// </summary>
        [property: JsonPropertyName("version")] string Version,

        /// <summary>
        /// MD5 hash of the beatmap.
        /// </summary>
        [property: JsonPropertyName("file_md5")] string FileMD5,

        /// <summary>
        /// Circle size value (CS).
        /// </summary>
        [property: JsonPropertyName("diff_size")] float DiffSize,

        /// <summary>
        /// Overall difficulty (OD).
        /// </summary>
        [property: JsonPropertyName("diff_overall")] float DiffOverall,

        /// <summary>
        /// Approach rate (AR).
        /// </summary>
        [property: JsonPropertyName("diff_approach")] float DiffApproach,

        /// <summary>
        /// Health drain (HP).
        /// </summary>
        [property: JsonPropertyName("diff_drain")] float DiffDrain,

        /// <summary>
        /// Game mode.
        /// </summary>
        [property: JsonPropertyName("mode")] BeatmapMode Mode,

        /// <summary>
        /// Count of notes on the map.
        /// </summary>
        [property: JsonPropertyName("count_normal")] ulong CountNormal,

        /// <summary>
        /// Count of sliders on the map.
        /// </summary>
        [property: JsonPropertyName("count_slider")] ulong CountSlider,

        /// <summary>
        /// Count of spinners on the map.
        /// </summary>
        [property: JsonPropertyName("count_spinner")] ulong CountSpinner,

        /// <summary>
        /// Date submitted.
        /// </summary>
        [property: JsonPropertyName("submit_date")] DateTime? SubmitDate,

        /// <summary>
        /// Date ranked.
        /// </summary>
        [property: JsonPropertyName("approved_date")] DateTime? ApprovedDate,

        /// <summary>
        /// Last update date, in UTC. May be after approved_date if map was unranked and reranked.
        /// </summary>
        [property: JsonPropertyName("last_update")] DateTime? LastUpdate,

        /// <summary>
        /// Song artist.
        /// </summary>
        [property: JsonPropertyName("artist")] string Artist,

        /// <summary>
        /// Song artist in Unicode.
        /// </summary>
        [property: JsonPropertyName("artist_unicode")] string ArtistUnicode,

        /// <summary>
        /// Song name.
        /// </summary>
        [property: JsonPropertyName("title")] string Title,

        /// <summary>
        /// Song name in Unicode.
        /// </summary>
        [property: JsonPropertyName("title_unicode")] string TitleUnicode,

        /// <summary>
        /// Creator nickname.
        /// </summary>
        [property: JsonPropertyName("creator")] string Creator,

        /// <summary>
        /// Creator ID.
        /// </summary>
        [property: JsonPropertyName("creator_id")] ulong CreatorId,

        /// <summary>
        /// The BPM of this beatmap.
        /// </summary>
        [property: JsonPropertyName("bpm")] float? BPM,

        /// <summary>
        /// Source of the beatmap.
        /// </summary>
        [property: JsonPropertyName("source")] string Source,

        /// <summary>
        /// Beatmap tags separated by spaces.
        /// </summary>
        [property: JsonPropertyName("tags")] string Tags,

        /// <summary>
        /// Song genre.
        /// </summary>
        [property: JsonPropertyName("genre_id")] Genre GenreId,

        /// <summary>
        /// Map language.
        /// </summary>
        [property: JsonPropertyName("language_id")] Language LanguageId,

        /// <summary>
        /// Number of times the beatmap was favourited.
        /// </summary>
        [property: JsonPropertyName("favourite_count")] ulong FavouriteCount,

        /// <summary>
        /// The rating of this beatmap.
        /// </summary>
        [property: JsonPropertyName("rating")] float Rating,

        /// <summary>
        /// If this beatmap has a storyboard.
        /// </summary>
        [property: JsonPropertyName("storyboard")] bool Storyboard,

        /// <summary>
        /// If this beatmap has a video.
        /// </summary>
        [property: JsonPropertyName("video")] bool Video,

        /// <summary>
        /// If the download for this beatmap is unavailable.
        /// </summary>
        [property: JsonPropertyName("download_unavailable")] bool DownloadUnavailable,

        /// <summary>
        /// If the audio for this beatmap is unavailable.
        /// </summary>
        [property: JsonPropertyName("audio_unavailable")] bool AudioUnavailable,

        /// <summary>
        /// Number of times the beatmap was played.
        /// </summary>
        [property: JsonPropertyName("playcount")] ulong PlayCount,

        /// <summary>
        /// Number of times the beatmap was passed.
        /// </summary>
        [property: JsonPropertyName("passcount")] ulong PassCount,

        /// <summary>
        /// Packs that contain this beatmap.
        /// </summary>
        [property: JsonPropertyName("packs")] string Packs,

        /// <summary>
        /// The maximum combo a user can reach playing this beatmap.
        /// </summary>
        [property: JsonPropertyName("max_combo")] ulong? MaxCombo,

        /// <summary>
        /// The aim difficulty of this beatmap.
        /// </summary>
        [property: JsonPropertyName("diff_aim")] float? DiffAim,

        /// <summary>
        /// The speed difficulty of this beatmap.
        /// </summary>
        [property: JsonPropertyName("diff_speed")] float? DiffSpeed,

        /// <summary>
        /// The number of stars the map would have in-game and on the website.
        /// </summary>
        [property: JsonPropertyName("difficultyrating")] float DifficultyRating
    );
}