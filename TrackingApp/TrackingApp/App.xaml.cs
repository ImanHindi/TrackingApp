using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using TrackingApp.Models.Tracking;
using TrackingApp.Services;
using TrackingApp.Services.Device;
using TrackingApp.Services.LocalDb;
using TrackingApp.Services.Settings;
using TrackingApp.Services.Tracking;
using TrackingApp.ViewModels.Base;
using Xamarin.Forms;
using DeviceMotion.Plugin.Abstractions;
using TrackingApp.Services.Motion;

namespace TrackingApp
{
	public partial class App : Application
    {
         IDialogService _dialogService;
        ICollectTrackingDataService _collectTrackingDataService;
        IMotionDetection _motionDetectionService;
        private PermissionStatus status;
        public App ()
		{
			InitializeComponent();
		    InitApp();

            if (Device.RuntimePlatform == Device.UWP)
		    {
		        InitNavigation();
		    }
            MainPage = new NavigationPage(new Views.MainView());
		   

        }


        private  void InitApp()
        {
            _dialogService = ViewModelLocator.Resolve<IDialogService>();
            //  if (!_settingsService.UseLocalDb)
            //     ViewModelLocator.UpdateDependencies(_settingsService.UseLocalDb);
        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected   override async void OnStart ()
		{
		    base.OnStart();

		    if (Device.RuntimePlatform != Device.UWP)
		    {
		        await InitNavigation();
		    }

		    await InitLocation();

            await StartLocationListeningService();

            await StartMotionDetectionService();
		    base.OnResume();


        }

        private async Task StartMotionDetectionService()
        {
            _motionDetectionService = ViewModelLocator.Resolve<IMotionDetection>();

            await _motionDetectionService.StartMotionDetection(MotionSensorType.Accelerometer,MotionSensorDelay.Default);
            await _motionDetectionService.StartMotionDetection(MotionSensorType.Compass, MotionSensorDelay.Default);
          //  await _motionDetectionService.StartMotionDetection(MotionSensorType.Gyroscope,MotionSensorDelay.Default);
            await _motionDetectionService.StartMotionDetection(MotionSensorType.Magnetometer,MotionSensorDelay.Default);


        }
        private async Task StoptMotionDetectionService()
        {
            await _motionDetectionService.StopMotionDetection(MotionSensorType.Accelerometer);
            await _motionDetectionService.StopMotionDetection(MotionSensorType.Compass);
          //  await _motionDetectionService.StopMotionDetection(MotionSensorType.Gyroscope);
            await _motionDetectionService.StopMotionDetection(MotionSensorType.Magnetometer);


        }

        private async Task StartLocationListeningService()
        {
            if (status == PermissionStatus.Granted)
            {
                _collectTrackingDataService = ViewModelLocator.Resolve<ICollectTrackingDataService>();
                await _collectTrackingDataService.StartListening();
            }
            else
            {
                await _dialogService.ShowAlertAsync("Location Permission is Denied, We Cannot Proceed!", "No Permission", "Ok");

            }
        }

        private async Task InitLocation()
        {
            try
            {
                 status =
                    await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission
                        .Location);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        await _dialogService.ShowAlertAsync("Need Access Your Location", "Need Permission", "Ok");
                    }

                    var result = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    if (result.ContainsKey(Permission.Location))
                        status = result[Permission.Location];

                }

               

            }
            catch (Exception e)
            {
                await _dialogService.ShowAlertAsync("Error", e.Message, "Ok");

                 var result = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                if (result.ContainsKey(Permission.Location))
                    status = result[Permission.Location];
            }
         
        }


        protected override async void OnSleep ()
		{
            // Handle when your app sleeps
		    await _collectTrackingDataService.StopListening();
            await StoptMotionDetectionService();

		}

        protected override async void OnResume ()
		{
            // Handle when your app resumes
		//   await _collectTrackingDataService.StartListening();


        }





    }
}
