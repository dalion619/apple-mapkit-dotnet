using System.Collections.Generic;
using System.Globalization;

namespace Apple.MapKit.RestClient.ResponseModels
{
    public class GenericResponseModel
    {
        public GenericResponseModel()
        {
            results = new List<Place>();
        }

        public List<Place> results { get; set; }
    }

    public class Place
    {
        public Place()
        {
            dependentLocalities = new List<string>();
            areasOfInterest = new List<string>();
            formattedAddressLines = new List<string>();
            iso3166 = new Iso3166();
            displayMapRegion = new DisplayMapRegion();
            center = new Center();
        }

        public Center center { get; set; }
        public DisplayMapRegion displayMapRegion { get; set; }
        public string name { get; set; }
        public string formattedAddressLine => string.Join(" ", formattedAddressLines);
        public List<string> formattedAddressLines { get; set; }
        public string administrativeArea { get; set; }
        public string subAdministrativeArea { get; set; }
        public string administrativeAreaCode { get; set; }
        public string locality { get; set; }
        public string postCode { get; set; }
        public string subLocality { get; set; }
        public string thoroughfare { get; set; }
        public string subThoroughfare { get; set; }
        public string fullThoroughfare { get; set; }
        public List<string> areasOfInterest { get; set; }
        public List<string> dependentLocalities { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
        public string geocodeAccuracy { get; set; }
        public string timezone { get; set; }
        public int timezoneSecondsFromGmt { get; set; }
        public string placecardUrl { get; set; }
        public Iso3166 iso3166 { get; set; }
    }

    public class Center
    {
        public double lat { get; set; }
        public double lng { get; set; }
        public string geocode => $"{lat.ToString(CultureInfo.InvariantCulture)},{lng.ToString(CultureInfo.InvariantCulture)}";
    }

    public class DisplayMapRegion
    {
        public double southLat { get; set; }
        public double westLng { get; set; }
        public double northLat { get; set; }
        public double eastLng { get; set; }
    }

    public class Iso3166
    {
        public string countryCode { get; set; }
        public string subdivisonCode { get; set; }
    }
}