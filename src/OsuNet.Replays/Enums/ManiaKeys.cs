namespace OsuNet.Replays.Enums {
    /// <summary>
    /// Represents the input keys pressed during an osu!mania replay.
    /// </summary>
    [Flags]
    public enum ManiaKeys {
        /// <summary>No keys pressed.</summary>
        None = 0,
        /// <summary>Column 1 key pressed.</summary>
        K1 = 1 << 0,
        /// <summary>Column 2 key pressed.</summary>
        K2 = 1 << 1,
        /// <summary>Column 3 key pressed.</summary>
        K3 = 1 << 2,
        /// <summary>Column 4 key pressed.</summary>
        K4 = 1 << 3,
        /// <summary>Column 5 key pressed.</summary>
        K5 = 1 << 4,
        /// <summary>Column 6 key pressed.</summary>
        K6 = 1 << 5,
        /// <summary>Column 7 key pressed.</summary>
        K7 = 1 << 6,
        /// <summary>Column 8 key pressed.</summary>
        K8 = 1 << 7,
        /// <summary>Column 9 key pressed.</summary>
        K9 = 1 << 8,
        /// <summary>Column 10 key pressed.</summary>
        K10 = 1 << 9
    }
}
