using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TrackingApp.Models.Device;

namespace TrackingApp.Services.Device
{
    public interface ISaveDeviceInfoService
    {

         Task<int> SaveDeviceInfoAsync(DeviceInfo deviceInfo);

      

    }
}
