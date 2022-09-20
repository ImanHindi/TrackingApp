using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrackingApp.Models.Tracking;

namespace TrackingApp.Services.Tracking
{
  public  interface ICollectTrackingDataService
    {

        Task<Position> GetCurrentLocation();

        Task<double> GetCurrentLongitude();

        Task<double> GetCurrentLatitude();


        Task StartListening();

        Task StopListening();
    }
}
