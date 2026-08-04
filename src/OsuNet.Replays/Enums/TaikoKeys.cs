namespace OsuNet.Replays.Enums {
    /// <summary>
    /// Represents the input keys pressed during an osu!taiko replay.
    /// </summary>
    [Flags]
    public enum TaikoKeys {
        /// <summary>No keys pressed.</summary>
        None = 0,
        /// <summary>Left red (Don) key pressed.</summary>
        LeftRed = 1 << 0,
        /// <summary>Left blue (Kat) key pressed.</summary>
        LeftBlue = 1 << 1,
        /// <summary>Right red (Don) key pressed.</summary>
        RightRed = 1 << 2,
        /// <summary>Right blue (Kat) key pressed.</summary>
        RightBlue = 1 << 3
    }
}
