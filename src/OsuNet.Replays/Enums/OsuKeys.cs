namespace OsuNet.Replays.Enums {
    /// <summary>
    /// Represents the input keys pressed during an osu!standard replay.
    /// </summary>
    [Flags]
    public enum OsuKeys {
        /// <summary>No keys pressed.</summary>
        None = 0,
        /// <summary>Mouse button 1 (usually left click) pressed.</summary>
        M1 = 1 << 0,
        /// <summary>Mouse button 2 (usually right click) pressed.</summary>
        M2 = 1 << 1,
        /// <summary>Keyboard key 1 pressed (combined with M1 for certain actions).</summary>
        K1 = (1 << 2) + M1,
        /// <summary>Keyboard key 2 pressed (combined with M2 for certain actions).</summary>
        K2 = (1 << 3) + M2,
        /// <summary>Smoke key pressed.</summary>
        Smoke = 1 << 4
    }
}
