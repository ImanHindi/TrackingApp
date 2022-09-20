using Plugin.DeviceInfo;
using Plugin.DeviceInfo.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrackingApp.Models.Device;

namespace TrackingApp.Services.Device
{
   public class CollectDeviceInfoService : ICollectDeviceInfoService

    {

        public DeviceInfo deviceInfo;
        public CollectDeviceInfoService()
        {
          deviceInfo = new DeviceInfo();
        }
        public  DeviceInfo GetDeviceInfoAsync()
        {
            try
            {

                var Devicex = CrossDeviceInfo.Current;

                Devicex.GenerateAppId(true, "djskddskdsm", "djskddskdsm");

                deviceInfo.Name = Devicex.DeviceName;
                deviceInfo.Id = Devicex.Id;
                deviceInfo.Idiom = Devicex.Idiom;
                deviceInfo.Manufacturer = Devicex.Manufacturer;
                deviceInfo.Model = Devicex.Model;
                deviceInfo.Platform = Devicex.Platform;
                deviceInfo.OSVersion = Devicex.Version;
                deviceInfo.VersionNo = Devicex.VersionNumber;
                deviceInfo.IsDevice = Devicex.IsDevice;
                deviceInfo.AppVersion = Devicex.AppVersion;
            }
            catch (Exception ex)
            {
                deviceInfo.Name = "Unable to get Device Info: " + ex;
            }

            return deviceInfo;
        }

    }
}
