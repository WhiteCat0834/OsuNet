namespace OsuNet.Enums {
    /// <summary>
    /// Represents the approval or ranking status of a beatmap.
    /// </summary>
    public enum ApproveStatus {
        /// <summary>
        /// The beatmap is in the graveyard section (typically inactive or abandoned).
        /// </summary>
        Graveyard = -2,

        /// <summary>
        /// The beatmap is a work in progress (WIP).
        /// </summary>
        WIP,

        /// <summary>
        /// The beatmap is pending approval.
        /// </summary>
        Pending,

        /// <summary>
        /// The beatmap has been ranked.
        /// </summary>
        Ranked,

        /// <summary>
        /// The beatmap has been approved.
        /// </summary>
        Approved,

        /// <summary>
        /// The beatmap is qualified for ranking.
        /// </summary>
        Qualified,

        /// <summary>
        /// The beatmap has been loved.
        /// </summary>
        Loved
    }
}
