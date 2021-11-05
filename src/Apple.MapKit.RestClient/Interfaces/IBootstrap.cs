using System.Threading.Tasks;
using Apple.MapKit.RestClient.ResponseModels;
using Refit;

namespace Apple.MapKit.RestClient.Interfaces
{
    [Headers("Authorization:Bearer", "Content-Type: application/json", "Accept: application/json")]
    public interface IBootstrap
    {
        [Get("/ma/bootstrap?apiVersion={apiVersion}&mkjsVersion={mkjsVersion}&poi={poi}")]
        Task<BootstrapResponseModel> Init([Header("Authorization")] string token, string apiVersion, string mkjsVersion, string poi);
    }
}