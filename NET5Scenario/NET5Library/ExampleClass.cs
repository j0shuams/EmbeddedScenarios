using System;
using Windows.Devices.Geolocation;

namespace NET5Library
{
    public class ExampleClass
    {
        public static async System.Threading.Tasks.Task<string> SampleMethodAsync()
        {
            var locator = new Geolocator();
            var location = await locator.GetGeopositionAsync();
            var position = location.Coordinate.Point.Position;
            var latlong = string.Format("lat:{0}, long:{1}", position.Latitude, position.Longitude);
            return latlong;
        }
    }
}
