using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TrackingApp.Models.Tracking;
using TrackingApp.Services.Settings;
using TrackingApp.Services.Tracking;
using TrackingApp.Services.Tracking.Connectivity;
using TrackingApp.ViewModels.Base;
using Xamarin.Forms;

namespace TrackingApp.ViewModels
{
    public class TrackingInfoViewModel : ViewModelBase
    {
        // private readonly ISettingsService _settingsService;

        private readonly ICollectTrackingDataService _collectTrackingDataService;

        private readonly ISaveTrackingDataService _saveTrackingDataService;
        private ObservableCollection<TrackingData> _listofTrackingData;
        private TrackingData _trackingData;
        private IConnectivity _connectivity;
        private bool _visiblity;
        private bool _isConnected;

        public TrackingInfoViewModel(ICollectTrackingDataService collectTrackingDataService , 
                                     IConnectivity connectivity ,
                                     ISaveTrackingDataService saveTrackingDataService)//, IConnectivity connectivity,ISettingsService settingsService,
        {
            // _settingsService = settingsService;
            _collectTrackingDataService = collectTrackingDataService;
            _saveTrackingDataService = saveTrackingDataService;
            _connectivity=connectivity  ;
             _visiblity = false;
           // _listofTrackingData = new ObservableCollection<TrackingData>();
           // _trackingData = new TrackingData();

        }
        public TrackingData TrackingData
        {
            get
            {
                return _trackingData;
            }
            set
            {
                _trackingData = value;
                RaisePropertyChanged(() => TrackingData);
            }
        }
        public ObservableCollection<TrackingData> ListofTrackingData
        {
            get { return _listofTrackingData; }
            set
            {
                _listofTrackingData = value;
                RaisePropertyChanged(() => ListofTrackingData);
            }
        }


       public bool Visiblity
       {
           get => _visiblity;
           set
           {
               _visiblity = value;
       
       
               RaisePropertyChanged(() => Visiblity);
           }
       }


       public bool IsConnected
       {
           get => _isConnected;
           set
           {
               _isConnected = value;


               RaisePropertyChanged(() => IsConnected);
           }
       }








        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;
            //Timer timer = new Timer(5000);
            //timer.Enabled = true;
            //timer.Start();

            //timer.Elapsed += async (sender, e) =>
            //{
              // var position =await  _collectTrackingDataService.GetCurrentLocation();
                //   MessagingCenter.Send(this, MessageKeys.AddData, position);
                //_trackingData =  AddDataAsync(position);
                //TrackingData = _trackingData;
                //ListofTrackingData.Add(_trackingData);
                //RaisePropertyChanged(() => ListofTrackingData);
          //  };
            //if (ListofTrackingData == null)
            //    ListofTrackingData = new ObservableCollection<TrackingData>();
            //var data = await _collectTrackingDataService.GetCurrentLocation();
            //_trackingData = AddDataAsync(data);
            //  TrackingData = _trackingData;
            //ListofTrackingData.Add(_trackingData);
            //RaisePropertyChanged(() => ListofTrackingData);


          
       //     MessagingCenter.Unsubscribe<App, TrackingData>(this, MessageKeys.AddData);

            MessagingCenter.Subscribe<CollectTrackingDataService, Position>(this, MessageKeys.AddData, (sender, arg) =>
           {
             _trackingData=  AddDataAsync(arg);
               TrackingData = _trackingData;
               if (ListofTrackingData == null)
                   ListofTrackingData = new ObservableCollection<TrackingData>();
               ListofTrackingData.Add(new TrackingData {
                   Latitude = _trackingData.Latitude,
                   Longitude = _trackingData.Longitude,
                   DataTimeOffset = _trackingData.DataTimeOffset,
                   Date= DateTime.Now,
                   Time = DateTime.Now.TimeOfDay,
                   Heading = _trackingData.Heading,
                   Speed = _trackingData.Speed,
                   Accuracy = _trackingData.Accuracy,
                   Altitude = _trackingData.Altitude,
                   AltitudeAccuracy = _trackingData.AltitudeAccuracy,
               });
              RaisePropertyChanged(() => ListofTrackingData);

            });


            IsBusy = false;

        }

        //private async Task<Position> CollectDataAsync()

        //{

        //    var locator = CrossGeolocator.Current;
        //    locator.DesiredAccuracy = 2;
        //    var position = await locator.GetPositionAsync();
        //    if (position != null)
        //    {
        //        return position;
        //    }
        //    if (!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
        //    {
        //        //not available or enabled
        //        position = null;
        //    }


        //    return position;
        
        //}

        private TrackingData AddDataAsync(Position Data)
        {
            _trackingData=new TrackingData
            {
            Latitude = Data.Latitude,
            Longitude = Data.Longitude,
            DataTimeOffset = Data.Timestamp,
            Heading = Data.Heading,
            Speed = Data.Speed,
            Accuracy = Data.Accuracy,
            Altitude = Data.Altitude,
            AltitudeAccuracy = Data.AltitudeAccuracy,
          
            };

            return _trackingData;
        }


    }









}
