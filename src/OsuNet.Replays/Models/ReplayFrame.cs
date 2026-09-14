using OsuNet.Replays.Enums;

namespace OsuNet.Replays.Models {
    /// <summary>
    /// Represents a single frame (snapshot in time) within an osu! replay, capturing cursor position and key states.
    /// </summary>
    /// <remarks>
    /// The osu! replay format compresses data using delta encoding. Therefore, the raw file contains <see cref="TimeDiff"/> (time since the last frame), 
    /// and the absolute <see cref="Time"/> is typically calculated by accumulating these differences during parsing.
    /// <para>
    /// Depending on the game mode of the replay, you should use the corresponding strongly-typed keys property 
    /// (<see cref="OsuKeys"/>, <see cref="TaikoKeys"/>, <see cref="ManiaKeys"/>, or <see cref="CatchKeys"/>).
    /// </para>
    /// </remarks>
    public class ReplayFrame {
        /// <summary>
        /// Gets or sets the time difference in milliseconds since the previous frame.
        /// </summary>
        public int TimeDiff { get; set; }

        /// <summary>
        /// Gets or sets the absolute time in milliseconds from the beginning of the beatmap's audio.
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        /// Gets or sets the X-coordinate of the cursor on the screen. 
        /// In osu!catch, this represents the horizontal position of the catcher.
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Gets or sets the Y-coordinate of the cursor on the screen.
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Gets or sets the raw integer value representing the bitwise flags of the keys pressed during this frame.
        /// </summary>
        public int RawKeys { get; set; }

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
