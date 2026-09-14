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
        public OsuApi(string accessToken) {
            this.apiRequester = new OsuApiRequester(accessToken);
            
            this.Beatmaps = new BeatmapsModule(this.apiRequester);
            this.User = new UserModule(this.apiRequester);
            this.Scores = new ScoresModule(this.apiRequester);
            this.Multiplayer = new MultiplayerModule(this.apiRequester);
            this.Replay = new ReplayModule(this.apiRequester);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OsuApi"/> class with a custom requester.
        /// </summary>
        /// <param name="requester">A custom implementation of <see cref="IApiRequester"/>.</param>
        public OsuApi(IApiRequester requester) {
            this.apiRequester = requester ?? throw new ArgumentNullException(nameof(requester));
            
            this.Beatmaps = new BeatmapsModule(this.apiRequester);
            this.User = new UserModule(this.apiRequester);
            this.Scores = new ScoresModule(this.apiRequester);
            this.Multiplayer = new MultiplayerModule(this.apiRequester);
            this.Replay = new ReplayModule(this.apiRequester);
        }
    }
}
