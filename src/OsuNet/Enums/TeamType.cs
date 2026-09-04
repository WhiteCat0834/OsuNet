namespace OsuNet.Enums {
    /// <summary>
    /// Represents the team type (game type) for a multiplayer match.
    /// </summary>
    public enum TeamType {
        /// <summary>Head-to-head (free for all).</summary>
        HeadToHead = 0,
        /// <summary>Tag (players take turns).</summary>
        Tag = 1,
        /// <summary>Team VS (two teams competing).</summary>
        Team = 2,
        /// <summary>Tag Team VS (teams taking turns).</summary>
        TagTeam = 3
    }
}
