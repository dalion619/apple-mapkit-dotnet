using System;
using System.Collections.Generic;
using System.Text;

namespace Apple.MapKit.RestClient.RequestModels
{
    public class GeocodeRequestModel
    {
        public string q;
        public string limitToCountries;
        public string language;
        public string coordinate; //https://developer.apple.com/documentation/mapkitjs/mapkit/coordinate/2973854-mapkit_coordinate
        public string region; //https://developer.apple.com/documentation/mapkitjs/mapkit/coordinateregion/2973861-mapkit_coordinateregion
    }
}
