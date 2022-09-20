using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TrackingApp.Models.Device;
using TrackingApp.Models.Tracking;
//using TrackingApp.Services.FixUri;
using TrackingApp.Services;
using TrackingApp.Services.WebService;

namespace TrackingApp.Services.Device
{
    public class SaveDeviceInfoService : ISaveDeviceInfoService
    {
        private readonly IRequestProvider _requestProvider;
      //  private readonly IFixUriService _fixUriService;

        public SaveDeviceInfoService(IRequestProvider requestProvider)//, //IFixUriService fixUriService)
        {
            _requestProvider = requestProvider;
           // _fixUriService = fixUriService;
        }
        public async Task<int> SaveDeviceInfoAsync(DeviceInfo deviceInfo)
        {
            UriBuilder builder = new UriBuilder();//GlobalSetting.Instance.DeviceInfoEndpoint);
            builder.Path = string.Format("api/DeviceInfo");
            string uri = builder.ToString();

            // DeviceInfo DeviceInfoSaved = await _requestProvider.PostAsync<DeviceInfo>(uri, deviceInfo);
            var deviceInfoSaved = await _requestProvider.PostAsync<DeviceInfo>(uri, deviceInfo);

            if (deviceInfoSaved != null)
                return 1;
            else
              return 0;


        }

       

        

      

       
    }
}
