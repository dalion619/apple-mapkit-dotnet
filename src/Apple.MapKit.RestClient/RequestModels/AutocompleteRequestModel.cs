using System;
using System.Collections.Generic;
using System.Text;

namespace Apple.MapKit.RestClient.RequestModels
{
    public class AutocompleteRequestModel
    {
        public string q;
        public string language;
        public string coordinate; //https://developer.apple.com/documentation/mapkitjs/mapkit/coordinate/2973854-mapkit_coordinate
        public string region; //https://developer.apple.com/documentation/mapkitjs/mapkit/coordinateregion/2973861-mapkit_coordinateregion
        public bool includeAddresses;
        public bool includePointsOfInterest;
        public bool includeQueries;
        public string pointOfInterestFilter;
        public string limitToCountries;
    }
}
