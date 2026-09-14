using OsuNet.Replays.Enums;

namespace OsuNet.Replays.Models {
    /// <summary>
    /// Represents a single frame (snapshot in time) within an osu! replay, 
    /// capturing cursor position, timing, and key states.
    /// </summary>
    /// <remarks>
    /// This is a <c>readonly record struct</c> to ensure immutability and 
    /// zero heap allocations when stored in collections like <see cref="List{T}"/>.
    /// </remarks>
    public readonly record struct ReplayFrame(
        int TimeDiff,
        int Time,
        float X,
        float Y,
        int RawKeys
    ) {
        /// <summary>
        /// Gets the keys pressed during this frame, parsed as osu!standard inputs (Mouse/Keyboard buttons, Smoke).
        /// </summary>
        public OsuKeys OsuKeys => (OsuKeys)RawKeys;

        /// <summary>
        /// Gets the keys pressed during this frame, parsed as osu!taiko inputs (Don/Kat drum hits).
        /// </summary>
        public TaikoKeys TaikoKeys => (TaikoKeys)RawKeys;

        /// <summary>
        /// Gets the keys pressed during this frame, parsed as osu!mania inputs (Column keys K1-K10).
        /// </summary>
        public ManiaKeys ManiaKeys => (ManiaKeys)RawKeys;

        /// <summary>
        /// Gets the keys pressed during this frame, parsed as osu!catch inputs (Dash).
        /// </summary>
        public CatchKeys CatchKeys => (CatchKeys)RawKeys;
    }
}