using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Apple.MapKit.RestClient.Interfaces;
using Apple.MapKit.RestClient.Options;
using Apple.MapKit.RestClient.RequestModels;
using Apple.MapKit.RestClient.ResponseModels;
using Microsoft.Extensions.Options;
using Refit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Apple.MapKit.RestClient.Services
{
    /// <summary>
    ///     REST client for interacting with Apple MapKit JS.
    /// </summary>
    public class MapKitClient : IMapKitClient
    {
        private readonly HttpClient _httpClient;
        private readonly MapKitOptions _options;
        private IBootstrap _bootstrapEndpoint { get; }
        private IPlace _placeEndpoint { get; }
        private ISearch _searchEndpoint { get; }

        public MapKitClient(IOptions<MapKitOptions> optionsAccessor)
        {
            if (optionsAccessor == null) throw new ArgumentNullException(nameof(optionsAccessor));

            _options = optionsAccessor.Value;
            _httpClient = new HttpClient(
                new AuthenticatedHttpClientHandler(GetAccessToken))
            {
                Timeout = TimeSpan.FromMinutes(1),
                BaseAddress = new Uri(MapKitConstants.ApiUrl)
            };
            _bootstrapEndpoint = RestService.For<IBootstrap>(MapKitConstants.CdnUrl);
            _placeEndpoint = RestService.For<IPlace>(_httpClient);
            _searchEndpoint = RestService.For<ISearch>(_httpClient);
        }

        public string CreateSnapShotUrl(string latitude, string longitude, string colorScheme)
        {
            var marker = "[{\"point\":\"" + $"{latitude},{longitude}" + "\",\"markerStyle\":\"large\",\"color\":\"e6523b\"}]";
            var center = $"{latitude},{longitude}";
            var path =
                $"/api/v1/snapshot?center={WebUtility.UrlEncode(center)}&z=16&t=standard&scale=2&size=500x500&colorScheme={colorScheme}&poi=1&annotations={WebUtility.UrlEncode(marker)}&teamId={_options.TeamId}&keyId={_options.KeyId}";
            var sig = WebUtility.UrlEncode(Convert.ToBase64String(CryptographicHelper.CreateSignature(_options.PrivateKeyContent, path)));
            return MapKitConstants.SnapShotUrl + path + "&signature=" + sig;
        }

        public async Task<List<Place>> Geocode(string query)
        {
            var response = await _placeEndpoint.Geocode($"{query}");
            if (response == null) throw new NullReferenceException(nameof(Geocode));
            
            return response.results;
        }

        public async Task<List<Place>> ReverseGeocode(string latitude, string longitude)
        {
            var response = await _placeEndpoint.ReverseGeocode($"{latitude},{longitude}");
            if (response == null) throw new NullReferenceException(nameof(ReverseGeocode));
            return response.results;
        }

        public async Task<List<Place>> Search(string query)
        {
            var response = await _searchEndpoint.Search($"{query}");
            if (response == null) throw new NullReferenceException(nameof(Search));
            return response.results;
        }

        public async Task<List<AutocompleteResult>> Autocomplete(string query)
        {
            var response = await _searchEndpoint.SearchAutocomplete($"{query}");
            if (response == null) throw new NullReferenceException(nameof(Autocomplete));
            return response.results;
        }

        public async Task<AuthInfo> GetAccessToken()
        {
            var jwt = "Bearer " + CryptographicHelper.CreateJWT(_options.PrivateKeyContent, _options.TeamId, _options.KeyId);
            var bootstrapResponse = await _bootstrapEndpoint.Init(jwt, "2", MapKitConstants.MK_JS_Version, "1");
            if (bootstrapResponse == null) throw new ArgumentNullException(nameof(bootstrapResponse));
            return bootstrapResponse.authInfo;
        }
    }     
}
