namespace OsuNet.Replays.Enums {
    /// <summary>
    /// Represents the input keys pressed during an osu!catch replay.
    /// </summary>
    [Flags]
    public enum CatchKeys {
        /// <summary>No keys pressed.</summary>
        None = 0,
        /// <summary>Dash key pressed.</summary>
        Dash = 1
    }
}
