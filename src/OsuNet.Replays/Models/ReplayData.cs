namespace OsuNet.Replays.Models {
    /// <summary>
    /// Represents the parsed data of an osu! replay file.
    /// </summary>
    public record ReplayData(int Seed, IReadOnlyList<ReplayFrame> ReplayFrames);
}