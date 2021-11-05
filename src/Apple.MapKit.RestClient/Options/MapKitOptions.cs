using Microsoft.Extensions.Options;

namespace Apple.MapKit.RestClient.Options
{
    /// <summary>
    ///     Configuration options for <see cref="MapKitClient" />
    /// </summary>
    public class MapKitOptions : IOptions<MapKitOptions>
    {
        /// <summary>
        ///     10-character Team ID obtained from your Apple Developer account.
        /// </summary>
        public string TeamId { get; set; }

        /// <summary>
        ///     10-character key identifier that provides the ID of the private key that you obtain from your Apple Developer account.
        /// </summary>
        public string KeyId { get; set; }

        /// <summary>
        ///     Content of the Private Key file.
        /// </summary>
        public string PrivateKeyContent { get; set; }

        MapKitOptions IOptions<MapKitOptions>.Value => this;
    }
}