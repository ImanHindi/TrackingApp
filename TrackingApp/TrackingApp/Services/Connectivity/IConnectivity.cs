using Plugin.Connectivity.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TrackingApp.Services.Tracking.Connectivity
{
   public interface IConnectivity
    {

         bool CheckGeoLocationEnabled();

        bool CheckGeoLocationIsListening();
        bool CheckGeoLocationAvailablity();
        bool CheckInternetConnection();

        IEnumerable<ConnectionType> CheckInternetReachable();
    }
}
