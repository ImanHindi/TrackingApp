using Plugin.Connectivity.Abstractions;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.ExternalMaps;
using TrackingApp.Models.Tracking;
using TrackingApp.Services.Settings;
using TrackingApp.Services.Tracking;
using TrackingApp.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Position = Xamarin.Forms.Maps.Position;

namespace TrackingApp.ViewModels
{
    public class TrackingMapViewModel : ViewModelBase
    {
        //private readonly ISettingsService _settingsService;

        private readonly ICollectTrackingDataService _collectTrackingDataService;
        private Xamarin.Forms.Maps.Position _position;
       
        private ObservableCollection<Pin> _currentPositionPin;
        private ObservableCollection<Position> _routeCoordinates;
        private Xamarin.Forms.Maps.Position _selectedPosition;
        public TrackingMapViewModel(ICollectTrackingDataService collectTrackingDataService)
        {
            _collectTrackingDataService = collectTrackingDataService;

            _currentPositionPin = new ObservableCollection<Pin>();
            _routeCoordinates = new ObservableCollection<Position>();


        }

        public Xamarin.Forms.Maps.Position Position
        {
            get { return _position; }
            set
          {
                _position = value;
               RaisePropertyChanged(() => Position);
            }
        }
        public Xamarin.Forms.Maps.Position SelectedPosition
        {
            get { return _selectedPosition; }
            set
            {
                _selectedPosition = value;
                RaisePropertyChanged(() => SelectedPosition);
                CurrentPositionPin.Add(new Pin() { Position = SelectedPosition, Type = PinType.Place, Label = "Your Distination" });
            }
        }
        public ObservableCollection<Pin> CurrentPositionPin
        {
            get { return _currentPositionPin; }
            set
            {
                _currentPositionPin = value;
                RaisePropertyChanged(() => CurrentPositionPin);
            }
        }

        public ObservableCollection<Position> RouteCoordinates
        {
            get { return _routeCoordinates; }
            set
            {
                _routeCoordinates = value;
                RaisePropertyChanged(() => RouteCoordinates);
            }
        }










        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;

            // Get TrackingData
            //var position = new Plugin.Geolocator.Abstractions.Position((await CrossGeolocator.Current.GetPositionAsync()).Latitude, (await CrossGeolocator.Current.GetPositionAsync()).Longitude);
            //  Position = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            // MapCurrentPoint.MoveToRegion(new MapSpan(Position, 2, 2));
            //  RaisePropertyChanged(() => MapCurrentPoint);
            await Task.Delay(2);
            MessagingCenter.Subscribe<CollectTrackingDataService, Plugin.Geolocator.Abstractions.Position>(this, MessageKeys.AddData, (sender, arg) =>
            {
             _position= new Xamarin.Forms.Maps.Position(arg.Latitude,arg.Longitude);
                Position = _position;
               //CurrentPositionPin.Add(new Pin(){Position = Position , Type = PinType.Place, Label = "Your Current Location"});
               // RaisePropertyChanged(() => CurrentPositionPin);
                _routeCoordinates.Add(new Position(Position.Latitude, Position.Longitude));
                RouteCoordinates = new ObservableCollection<Position>(_routeCoordinates);
                RaisePropertyChanged(() => RouteCoordinates);

            });

            //MessagingCenter.Subscribe<App, Position>(this, MessageKeys.AddData,
            //    (sender, arg) => { });

                //await  CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(2), 2);
                //CrossGeolocator.Current.PositionChanged += (sender, e) =>
                //{
                //    position = e.Position;
                //    Position = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);

                //    MapCurrentPoint.MoveToRegion(new MapSpan(new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude), 2, 2));
                //};
                IsBusy = false;


           // Map map= new Map();
            


        }
        public ICommand Show_Route => new Command(async () => await ShowRouteAsync());

        private async Task ShowRouteAsync()
        {
          //  var Success = await CrossExternalMaps.Current.NavigateTo("DistinationWay", CurrentPositionPin);
        }
    }
}
