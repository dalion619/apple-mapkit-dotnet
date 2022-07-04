using System;
using System.Collections.Generic;

namespace Apple.MapKit.RestClient.ResponseModels
{
    public class SearchAutocompleteResponseModel
    {
        public SearchAutocompleteResponseModel()
        {
            results = new List<AutocompleteResult>();
        }
        public List<AutocompleteResult> results { get; set; }
    }

    public class AutocompleteResult
    {
        public AutocompleteResult()
        {
            displayLines = new List<string>();
            location = new Location();
            id = Guid.NewGuid();
        }

        public Guid id { get; set; }
        public string muid { get; set; }     
        public string completionUrl { get; set; }
        public string queryLine => string.Join(" ", displayLines);
        public List<string> displayLines { get; set; }
        public Location location { get; set; }
        public string type { get; set; }
        public string administrativeArea { get; set; }
        public string subAdministrativeArea { get; set; }
        public string locality { get; set; }
        public string postCode { get; set; }
        public string administrativeAreaCode { get; set; }
        public string timezone { get; set; }
            
    }

    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }
}