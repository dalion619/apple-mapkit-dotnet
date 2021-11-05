using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Apple.MapKit.RestClient.ResponseModels;

namespace Apple.MapKit.RestClient
{
    /// <summary>
    ///     This class allows the bearer token to be inserted into Authorization Header of the request made by the HttpClient instance
    /// </summary>
    public class AuthenticatedHttpClientHandler : HttpClientHandler
    {
        private readonly Func<Task<AuthInfo>> _getAccessToken;
        private AuthInfo _accessTokenModel;

        public AuthenticatedHttpClientHandler(Func<Task<AuthInfo>> getAccessToken)
        {
            if (getAccessToken == null) throw new ArgumentNullException(nameof(getAccessToken));

            _getAccessToken = getAccessToken;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            // See if the request has an authorize header
            var auth = request.Headers.Authorization;
            if (auth != null)
            {
                if (_accessTokenModel == null || (DateTime.Now - _accessTokenModel.expires).Minutes <= 2)
                    _accessTokenModel = await _getAccessToken().ConfigureAwait(false);

                request.Headers.Authorization =
                    new AuthenticationHeaderValue(auth.Scheme, _accessTokenModel.access_token);
            }

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}