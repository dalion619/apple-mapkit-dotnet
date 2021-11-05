using System.Threading.Tasks;
using Apple.MapKit.RestClient.RequestModels;
using Apple.MapKit.RestClient.ResponseModels;
using Refit;

namespace Apple.MapKit.RestClient.Interfaces
{
    [Headers("Authorization:Bearer", "Content-Type: application/json", "Accept: application/json")]
    public interface IPlace
    {
        [Get("/geocode?q={query}")]
        Task<GenericResponseModel> Geocode(BaseRequestModel model, string query);

        [Get("/reverseGeocode?loc={location}")]
        Task<GenericResponseModel> ReverseGeocode(BaseRequestModel model, string location);
    }
}