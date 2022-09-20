using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TrackingApp.Models.Tracking;
using TrackingApp.Services.Settings;
using TrackingApp.Services.WebService;
using System.Timers;
using TrackingApp.ViewModels;
using TrackingApp.ViewModels.Base;
using Xamarin.Forms;

namespace  TrackingApp.Services.Tracking
{
    public class CollectTrackingDataService : ICollectTrackingDataService
    {
       // public static TrackingData trackingData;
       // public ObservableCollection<TrackingData> TrackingDataList { get; set; }

       
        public async Task<Position> GetCurrentLocation()
        {
            Position position=new Position();
            try
                {
               var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 2;
                position = await locator.GetPositionAsync();
                    if (position != null)
                    {
                        return position;
                    }
                    if (!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
                    {
                    //not available or enabled
                   return null;
                    }
                }
                catch (Exception ex)
                {
                return null;
                }
                return null;
        }

        public async Task<double> GetCurrentLongitude()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 2;
            return (await locator.GetPositionAsync()).Longitude;
        }
        public async Task<double> GetCurrentLatitude()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 2;
            return (await locator.GetPositionAsync()).Latitude;
        }

        #region StartListenning

        public async Task StartListening()
        {
           // var locator = CrossGeolocator.Current;
            //if (!CrossGeolocator.Current.IsListening)
            //    return;

            //position = await locator.GetPositionAsync(TimeSpan.FromSeconds(0), null, true);
            await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(5), 2, true);
            //if (!_isPositionChanged)
            //{
            //    position = await GetCurrentLocation();
            //}
            
            CrossGeolocator.Current.PositionError += (sender, e) =>
            {
               var positionError = e.Error;
            };

            CrossGeolocator.Current.PositionChanged += (sender, e) => {
                var position = (Position)e.Position;
                MessagingCenter.Send( this,MessageKeys.AddData,position);
            };
           // return position;

            //if (!(position == null))
            //{
            //    trackingData.Latitude = position.Latitude;
            //    trackingData.Longitude = position.Longitude;
            //    trackingData.DataTimeOffset = position.Timestamp;
            //    trackingData.Heading = position.Heading;
            //    trackingData.Speed = position.Speed;
            //    trackingData.Accuracy = position.Accuracy;
            //    trackingData.Altitude = position.Altitude;
            //    trackingData.AltitudeAccuracy = position.AltitudeAccuracy;
            //    trackingData.Date = DateTime.Today;
            //    trackingData.Time = DateTime.Today.TimeOfDay;

            //  }
            // await StopListening();


        }


        //private Position PositionChanged(object sender, PositionEventArgs e)
        //{

        //    var position = e.Position;
        //    return position;
        //}

        //private GeolocationError PositionError(object sender, Plugin.Geolocator.Abstractions.PositionErrorEventArgs e)
        //{

        //    return e.Error;
        //    //Handle event here for errors
        //}


        #endregion

        #region StopListenning

        public async Task StopListening()
        {

            if (!CrossGeolocator.Current.IsListening)
                return;

            await CrossGeolocator.Current.StopListeningAsync();

            CrossGeolocator.Current.PositionChanged -= (sender, e) => {
                var position = (Position)e.Position;
            };
            CrossGeolocator.Current.PositionError -= (sender, e) =>
            {
              var  positionError = e.Error;
            };
        }

        #endregion

    }
}
