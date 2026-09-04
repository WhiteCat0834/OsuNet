namespace OsuNet.Enums {
    /// <summary>
    /// Represents the gameplay modifiers (mods) that can be applied to a score or beatmap.
    /// </summary>
    [Flags]
    public enum Mods {
        /// <summary>No mods applied.</summary>
        None = 0,
        /// <summary>NoFail (NF): You can't fail. No matter what.</summary>
        NoFail = 1,
        /// <summary>Easy (EZ): Larger circles, more forgiving HP drain, less accuracy required.</summary>
        Easy = 2,
        /// <summary>TouchDevice (TD): Indicates the score was set using a touch screen device.</summary>
        TouchDevice = 4,
        /// <summary>Hidden (HD): Circles fade out before they are hit.</summary>
        Hidden = 8,
        /// <summary>HardRock (HR): Everything just got a bit harder...</summary>
        HardRock = 16,
        /// <summary>SuddenDeath (SD): Miss a note and fail.</summary>
        SuddenDeath = 32,
        /// <summary>DoubleTime (DT): ZOOM.</summary>
        DoubleTime = 64,
        /// <summary>Relax (RX): You don't need to click. Give your clicking/tapping fingers a break.</summary>
        Relax = 128,
        /// <summary>HalfTime (HT): Less zoom.</summary>
        HalfTime = 256,
        /// <summary>Nightcore (NC): Ugguhh. (DoubleTime with a pitch increase). Value includes DoubleTime (512 + 64).</summary>
        Nightcore = 576,
        /// <summary>Flashlight (FL): Restricted view area that follows your cursor.</summary>
        Flashlight = 1024,
        /// <summary>Autoplay (AT): Watch a perfect automated play through the song.</summary>
        Autoplay = 2048,
        /// <summary>SpunOut (SO): Automatically spin the spinners.</summary>
        SpunOut = 4096,
        /// <summary>Autopilot (AP / Relax2): Automatic cursor movement.</summary>
        Relax2 = 8192,
        /// <summary>Perfect (PF): SS or quit. Value includes SuddenDeath (16384 + 32).</summary>
        Perfect = 16416,
        /// <summary>4K (osu!mania).</summary>
        Key4 = 32768,
        /// <summary>5K (osu!mania).</summary>
        Key5 = 65536,
        /// <summary>6K (osu!mania).</summary>
        Key6 = 131072,
        /// <summary>7K (osu!mania).</summary>
        Key7 = 262144,
        /// <summary>8K (osu!mania).</summary>
        Key8 = 524288,
        /// <summary>FadeIn (FI): Keys appear later (osu!mania).</summary>
        FadeIn = 1048576,
        /// <summary>Random (RD): Randomizes the note positions (osu!mania).</summary>
        Random = 2097152,
        /// <summary>Cinema (CN): Watch the video with an automatic play.</summary>
        Cinema = 4194304,
        /// <summary>Target (TP): Target practice.</summary>
        Target = 8388608,
        /// <summary>9K (osu!mania).</summary>
        Key9 = 16777216,
        /// <summary>Co-op (osu!mania).</summary>
        KeyCoop = 33554432,
        /// <summary>1K (osu!mania).</summary>
        Key1 = 67108864,
        /// <summary>3K (osu!mania).</summary>
        Key3 = 134217728,
        /// <summary>2K (osu!mania).</summary>
        Key2 = 268435456,
        /// <summary>ScoreV2 (V2): New score calculation.</summary>
        ScoreV2 = 536870912,
        /// <summary>Mirror (MR): Flips the beatmap horizontally (osu!mania / osu!catch).</summary>
        Mirror = 1073741824,
        /// <summary>Combination of all osu!mania key mods.</summary>
        KeyMod = Key1 | Key2 | Key3 | Key4 | Key5 | Key6 | Key7 | Key8 | Key9 | KeyCoop,
        /// <summary>Combination of mods that are allowed in FreeMod.</summary>
        FreeModAllowed = NoFail | Easy | Hidden | HardRock | SuddenDeath | Flashlight | FadeIn | Relax | Relax2 | SpunOut | KeyMod,
        /// <summary>Combination of mods that increase the score multiplier.</summary>
        ScoreIncreaseMods = Hidden | HardRock | DoubleTime | Flashlight | FadeIn
    }
}
