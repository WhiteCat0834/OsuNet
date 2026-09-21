using OsuNet.Abstractions;
using OsuNet.Modules;

namespace OsuNet {
    /// <summary>
    /// The main class of this library.
    /// </summary>
    public partial class OsuApi : IOsuApi {        
        private readonly IApiRequester apiRequester;

        /// <summary>
        /// Gets or sets the Osu!API token. 
        /// </summary>
        public string AccessToken {
            get => apiRequester.AccessToken;
            set => apiRequester.AccessToken = value;
        }

        /// <summary>
        /// Represents a module for interacting with beatmap-related endpoints in the osu! API.
        /// </summary>
        public IBeatmapModule Beatmaps { get; }

        /// <summary>
        /// Represents a module for interacting with user-related endpoints in the osu! API.
        /// </summary>
        public IUserModule User { get; }

        /// <summary>
        /// Represents a module for interacting with score-related endpoints in the osu! API.
        /// </summary>
        public IScoresModule Scores { get; }

        /// <summary>
        /// Represents a module for interacting with multiplayer-related endpoints in the osu! API.
        /// </summary>
        public IMultiplayerModule Multiplayer { get; }

        /// <summary>
        /// Represents a module for interacting with replay-related endpoints in the osu! API.
        /// </summary>
        public IReplayModule Replay { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OsuApi"/> class with a default HTTP requester.
        /// </summary>
        /// <param name="accessToken">Your Osu!API token.</param>
        public OsuApi(string accessToken) : this(accessToken, null) {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OsuApi"/> class with a custom requester.
        /// </summary>
        /// <param name="accessToken">Your Osu!API token.</param>
        /// <param name="requester">A custom implementation of <see cref="IApiRequester"/>.</param>
        /// <param name="beatmaps">A custom implementation of <see cref="IBeatmapModule"/>.</param>
        /// <param name="user">A custom implementation of <see cref="IUserModule"/>.</param>
        /// <param name="scores">A custom implementation of <see cref="IScoresModule"/>.</param>
        /// <param name="multiplayer">A custom implementation of <see cref="IMultiplayerModule"/>.</param>
        /// <param name="replay">A custom implementation of <see cref="IReplayModule"/>.</param>

        public OsuApi(
            string accessToken,
            IApiRequester? requester = null,
            IBeatmapModule? beatmaps = null,
            IUserModule? user = null,
            IScoresModule? scores = null,
            IMultiplayerModule? multiplayer = null,
            IReplayModule? replay = null) {
            this.apiRequester = requester ?? new OsuApiRequester(accessToken);

            this.Beatmaps = beatmaps ?? new BeatmapsModule(this.apiRequester);
            this.User = user ?? new UserModule(this.apiRequester);
            this.Scores = scores ?? new ScoresModule(this.apiRequester);
            this.Multiplayer = multiplayer ?? new MultiplayerModule(this.apiRequester);
            this.Replay = replay ?? new ReplayModule(this.apiRequester);
        }
    }
}
