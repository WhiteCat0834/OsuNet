namespace OsuNet.Enums {
    /// <summary>
    /// Represents the scoring type for a multiplayer match.
    /// </summary>
    public enum Scoring {
        /// <summary>Score-based ranking.</summary>
        Score = 0,
        /// <summary>Accuracy-based ranking.</summary>
        Accuracy = 1,
        /// <summary>Combo-based ranking.</summary>
        Combo = 2,
        /// <summary>ComboV2-based ranking (ScoreV2).</summary>
        ComboV2 = 3
    }
}
