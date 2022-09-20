using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TrackingApp.Services.Tracking.Connectivity
{
    public class Connectivity : IConnectivity
    {
        

        public bool CheckGeoLocationEnabled()
        {
           

            return CrossGeolocator.Current.IsGeolocationEnabled; 
        }

        public  bool CheckGeoLocationIsListening()
        {

            return CrossGeolocator.Current.IsListening;

        }
        public  bool CheckGeoLocationAvailablity()
        {
            

            return CrossGeolocator.Current.IsGeolocationAvailable;

        }
        public  bool CheckInternetConnection()
        {

            return CrossConnectivity.Current.IsConnected;
        }
        public IEnumerable<ConnectionType> CheckInternetReachable()
        {

            return CrossConnectivity.Current.ConnectionTypes;
        }
    }
}
