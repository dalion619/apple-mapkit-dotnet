using System.Collections.Generic;
using System.Threading.Tasks;
using Apple.MapKit.RestClient.ResponseModels;

namespace Apple.MapKit.RestClient.Interfaces
{
    public interface IMapKitClient
    {
        Task<AuthInfo> GetAccessToken();

        string CreateSnapShotUrl(string latitude, string longitude, string colorScheme);

        Task<List<Place>> PlacesForGeoCode(string latitude, string longitude);
    }
}