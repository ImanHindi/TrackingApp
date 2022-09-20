using Plugin.DeviceInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrackingApp.Models.Device;
using TrackingApp.Services.Device;
using TrackingApp.Services.Settings;
using TrackingApp.Services.Tracking.Connectivity;
using TrackingApp.ViewModels.Base;
using Xamarin.Forms;

namespace TrackingApp.ViewModels
{
    public class DeviceInfoViewModel : ViewModelBase
    {


        private readonly ICollectDeviceInfoService _collectDeviceInfoService;
        private ISaveDeviceInfoService _saveDeviceInfoService;
        private DeviceInfo _deviceInfo;
        private IConnectivity _connectivity;
        private bool _visiblity;
        private bool _isConnected;

        public DeviceInfoViewModel(IConnectivity connectivity, ICollectDeviceInfoService collectDeviceInfoService)//, ISaveDeviceInfoService saveDeviceInfoService)
        {
           _collectDeviceInfoService = collectDeviceInfoService;
          //  _saveDeviceInfoService = saveDeviceInfoService;
            _connectivity = connectivity;
            _visiblity = false;
          
          

        }

        public DeviceInfo DeviceInformation
        {
            get { return _deviceInfo; }
            set
            {
                _deviceInfo = value;
                RaisePropertyChanged(() => DeviceInformation);
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

            // Get DeviceInfo
            
            DeviceInformation =  _collectDeviceInfoService.GetDeviceInfoAsync();
          //  var result = await _saveDeviceInfoService.SaveDeviceInfoAsync(DeviceInformation);
          //  if (result != 0)
          //      Visiblity = true;

            IsBusy = false;

          
           

           
        }


      


      

    }
}
