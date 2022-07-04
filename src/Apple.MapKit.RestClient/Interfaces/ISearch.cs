using System.Threading.Tasks;
using Apple.MapKit.RestClient.RequestModels;
using Apple.MapKit.RestClient.ResponseModels;
using Refit;

namespace Apple.MapKit.RestClient.Interfaces
{
    [Headers("Authorization:Bearer","Content-Type: application/json","Accept: application/json")]
    public interface ISearch {
        [Get("/search?q={query}")]
        Task<GenericResponseModel> Search(string query);
        
        [Get("/searchAutocomplete?q={query}")]
        Task<SearchAutocompleteResponseModel> SearchAutocomplete(string query);
    }
}
