using System.Collections.Generic;
using System.Threading.Tasks;
using Apple.MapKit.RestClient.ResponseModels;

namespace Apple.MapKit.RestClient.Interfaces
{
    public interface IMapKitClient
    {
        Task<AuthInfo> GetAccessToken();
        string CreateSnapShotUrl(string latitude, string longitude, string colorScheme);
        Task<List<Place>> Geocode(string query);
        Task<List<Place>> ReverseGeocode(string latitude, string longitude);
        Task<List<Place>> Search(string query);
        Task<List<AutocompleteResult>> Autocomplete(string query);     
    }
}