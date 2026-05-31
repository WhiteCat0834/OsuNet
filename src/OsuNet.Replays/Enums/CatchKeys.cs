namespace OsuNet.Replays.Enums {
    [Flags]
    public enum CatchKeys {
        None = 0,
        MoveLeft = 1 << 0,
        MoveRight = 1 << 1,
        Dash = 1 << 2
    }
}
