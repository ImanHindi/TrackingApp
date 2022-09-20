using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrackingApp.Models.Device;

namespace TrackingApp.Services.Device
{
   public interface ICollectDeviceInfoService
    {
        DeviceInfo GetDeviceInfoAsync();


    }
}
