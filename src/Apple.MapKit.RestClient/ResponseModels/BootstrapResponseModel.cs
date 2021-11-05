using System;
using System.Collections.Generic;

namespace Apple.MapKit.RestClient.ResponseModels
{
    public class BootstrapResponseModel
    {
        public BootstrapResponseModel()
        {
            authInfo = new AuthInfo();
            tileSources = new List<TileSource>();
            analytics = new Analytics();
            modes = new Modes();
            attributions = new List<Attribution>();
        }

        public string region { get; set; }
        public List<Attribution> attributions { get; set; }
        public Modes modes { get; set; }
        public string mapEngine { get; set; }
        public string environment { get; set; }
        public Analytics analytics { get; set; }
        public List<string> madabaDomains { get; set; }
        public string apiBaseUrl { get; set; }
        public string analyticsBaseUrl { get; set; }
        public string madabaBaseUrl { get; set; }
        public List<TileSource> tileSources { get; set; }
        public bool disableCsr { get; set; }
        public string accessKey { get; set; }
        public int expiresInSeconds { get; set; }
        public bool showWordmarkLogo { get; set; }
        public AuthInfo authInfo { get; set; }
        public string countryCode { get; set; }
    }

    public class Global
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Attribution
    {
        public Attribution()
        {
            global = new List<Global>();
        }

        public string attributionId { get; set; }
        public List<Global> global { get; set; }
    }

    public class Layer
    {
        public Layer()
        {
            allowPrefetchingLowResAtZDiffs = new List<int>();
        }

        public string tileSource { get; set; }
        public string lowResTileSource { get; set; }
        public List<int> allowPrefetchingLowResAtZDiffs { get; set; }
        public int maximumOverdrawScale { get; set; }
    }

    public class Hybrid
    {
        public Hybrid()
        {
            layers = new List<Layer>();
        }

        public List<Layer> layers { get; set; }
    }

    public class Satellite
    {
        public Satellite()
        {
            layers = new List<Layer>();
        }

        public List<Layer> layers { get; set; }
    }

    public class Standard
    {
        public Standard()
        {
            layers = new List<Layer>();
        }

        public List<Layer> layers { get; set; }
    }

    public class Modes
    {
        public Modes()
        {
            hybrid = new Hybrid();
            satellite = new Satellite();
            standard = new Standard();
        }

        public Hybrid hybrid { get; set; }
        public Satellite satellite { get; set; }
        public Standard standard { get; set; }
    }

    public class AuthInfo
    {
        public AuthInfo()
        {
            created = DateTime.Now;
        }

        public DateTime created { get; set; }
        public DateTime expires => created.AddSeconds(expires_in);
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string team_id { get; set; }
    }

    public class TileSource
    {
        public TileSource()
        {
            supportedSizes = new List<int>();
            supportedResolutions = new List<int>();
            supportedLanguages = new List<string>();
            domains = new List<string>();
        }

        public string attributionId { get; set; }
        public string tileSource { get; set; }
        public List<int> supportedSizes { get; set; }
        public List<int> supportedResolutions { get; set; }
        public List<string> supportedLanguages { get; set; }
        public int minZoomLevel { get; set; }
        public int maxZoomLevel { get; set; }
        public bool showPrivacyLink { get; set; }
        public bool showTermsOfUseLink { get; set; }
        public List<string> domains { get; set; }
        public bool needsLocationShift { get; set; }
        public string path { get; set; }
    }

    public class Analytics
    {
        public string analyticsUrl { get; set; }
        public string errorUrl { get; set; }
    }
}