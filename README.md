# Apple MapKit .NET Standard 2.0 REST Client

This client library is a reimplementation of Apple MapKit JS to enable its use in .NET projects. For more information, refer to https://developer.apple.com/maps/web/. 

## Usage
Register and configure the service with the `AddMapKitService` extension method.
```c#
.AddMapKitService(options =>
                {
                    options.TeamId = "YourTeamId";
                    options.KeyId = "YourKeyId";
                    options.PrivateKeyContent = File.ReadAllText("PrivateKeyFile.p8");
                })
```

Inject or resolve the client service.
```c#
var mapkitClient = serviceProvider.GetService<IMapKitClient>();
```

Have fun!

```c#
var places = await mapkitClient.Search(query);
```

```c#
var places = await mapkitClient.Autocomplete(query);
```
```json
{
    [
        {
            "completionUrl": "/v1/search?q=Apple%20Park%20Apple%20Inc.%2C%20One%20Apple%20Park%20Way%2C%20Cupertino%2C%20CA%2095014%2C%20United%20States&metadata=ChIKCkFwcGxlIFBhcmsSBAgAEAUSRApCQXBwbGUgSW5jLiwgT25lIEFwcGxlIFBhcmsgV2F5LCBDdXBlcnRpbm8sIENBIDk1MDE0LCBVbml0ZWQgU3RhdGVzGAEqIQoSCQAAAADeqkJAEQAAAMCTgF7AEMrsrO6smpThBxiuTWISChBBcHBsZSBIZWFkcXVhdGVygvEEEEFwcGxlIEhlYWRxdWF0ZXKI8QQA2vEEFgkAAABAmvXIQBEAAACAJIrUQDICZW7q8QQA",
            "displayLines": [
                "Apple Park",
                "Apple Inc., One Apple Park Way, Cupertino, CA 95014, United States"
            ],
            "location": {
                "lat": 37.33489990234375,
                "lng": -122.00901794433594
            },
            "muid": "559098170073364042",
            "type": "BUSINESS",
            "administrativeArea": "California",
            "subAdministrativeArea": "Santa Clara",
            "administrativeAreaCode": "CA",
            "locality": "Cupertino",
            "postCode": "95014",
            "subLocality": "Pruneridge Tantau",
            "thoroughfare": "Apple Park Way",
            "subThoroughfare": "One",
            "fullThoroughfare": "One Apple Park Way",
            "areasOfInterest": [
                "Apple Park",
                "Apple Park"
            ],
            "dependentLocalities": [
                "Pruneridge Tantau"
            ],
            "timezone": "America/Los_Angeles",
            "timezoneSecondsFromGmt": -25200
        }, ...
```
```c#
var places = await mapkitClient.Geocode(query);
```
```json
 {
            "center": {
                "lat": 37.3349,
                "lng": -122.00902
            },
            "displayMapRegion": {
                "southLat": 37.3266671,
                "westLng": -122.0141205,
                "northLat": 37.3388225764206,
                "eastLng": -122.0024368016418
            },
            "name": "Apple Park",
            "formattedAddressLines": [
                "Apple Inc.",
                "One Apple Park Way",
                "Cupertino, CA 95014",
                "United States"
            ],
            "administrativeArea": "California",
            "subAdministrativeArea": "Santa Clara",
            "administrativeAreaCode": "CA",
            "locality": "Cupertino",
            "postCode": "95014",
            "subLocality": "Pruneridge Tantau",
            "thoroughfare": "Apple Park Way",
            "subThoroughfare": "One",
            "fullThoroughfare": "One Apple Park Way",
            "areasOfInterest": [
                "Apple Park",
                "Apple Park"
            ],
            "dependentLocalities": [
                "Pruneridge Tantau"
            ],
            "country": "United States",
            "countryCode": "US",
            "geocodeAccuracy": "UNKNOWN",
            "muid": "559098170073364042",
            "mapsId": {
                "muid": "559098170073364042",
                "resultProviderId": "9902"
            },
            "telephone": "+14089961010",
            "urls": [
                "https://www.apple.com"
            ],
            "timezone": "America/Los_Angeles",
            "timezoneSecondsFromGmt": -25200,
            "placecardUrl": "https://maps.apple.com/place?q=Apple%20Park&auid=559098170073364042&address=Apple%20Inc.,%20One%20Apple%20Park%20Way,%20Cupertino,%20CA%2095014,%20United%20States&ll=37.3349,-122.00902"
}
```
```c#
var places = await mapkitClient.ReverseGeoCode(latitude,longitude);
var places = await mapkitClient.ReverseGeoCode("37.3349","-122.00902");

```
```json
{
   [
        {
            "center": {
                "lat": 37.3348892,
                "lng": -122.0088363
            },
            "displayMapRegion": {
                "southLat": 37.3266671,
                "westLng": -122.01448534033632,
                "northLat": 37.3393807764206,
                "eastLng": -122.00318725966368
            },
            "name": "Apple Park",
            "formattedAddressLines": [
                "Apple Park",
                "1 Apple Park Way",
                "Cupertino, CA  95014",
                "United States"
            ],
            "administrativeArea": "California",
            "subAdministrativeArea": "Santa Clara County",
            "administrativeAreaCode": "CA",
            "locality": "Cupertino",
            "postCode": "95014",
            "thoroughfare": "Apple Park Way",
            "subThoroughfare": "1",
            "fullThoroughfare": "1 Apple Park Way",
            "areasOfInterest": [
                "Apple Park"
            ],
            "country": "United States",
            "countryCode": "US",
            "geocodeAccuracy": "REGION",
            "timezone": "America/Los_Angeles",
            "timezoneSecondsFromGmt": -25200,
            "placecardUrl": "https://maps.apple.com/place?q=Apple%20Park&address=Apple%20Park,%201%20Apple%20Park%20Way,%20Cupertino,%20CA%20%2095014,%20United%20States&ll=37.3348892,-122.0088363&lsp=7618",
            "iso3166": {
                "countryCode": "US",
                "subdivisonCode": "US-CA"
            }
        }
    ]
}
```
```c#
var snapshot = mapkitClient.CreateSnapShotUrl(latitude, longitude, colorScheme);
// https://snapshot.apple-mapkit.com/api/v1/snapshot?center=-26.13778%2C28.19756&z=16&t=standard&scale=2&size=500x500&poi=1&colorScheme={colorScheme}&annotations={annotations}&teamId={teamId}&keyId={keyId}}&signature={signature}
```
#### Dark Colour Scheme
![Dark](./docs/snapshot-dark.png)
#### Light Colour Scheme
![Light](./docs/snapshot-light.png)

## Useful links

* [Documentation](https://developer.apple.com/documentation/mapkitjs)
* [MapKit JS Dashboard](https://maps.developer.apple.com/)
* [Snapshots Studio](https://maps.developer.apple.com/snapshot)
