using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace PuppyGo.Services
{

    public class LocationService
    {

        public LocationService()
        {
        }

        public async Task<Location> GetUsersLocation()
        {

            try
            {

                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    return location;
                }

            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }

            // no location for whatever reason - just return Atlanta
            return new Location(33.7490, -84.3880);

        }

    }

}
