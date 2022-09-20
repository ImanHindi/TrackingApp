using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using TrackingApp.Services.LocalDb;
using TrackingApp.Models.Device;
using System.Collections.Generic;

namespace TrackingApp.Services.Device
{
    public class SaveDeviceInfoLocalService : ISaveDeviceInfoService
    {
     
       

        private readonly IDbServices dbServices;
        public SaveDeviceInfoLocalService(IDbServices DbServices)
        {
             dbServices = DbServices;

        }

        public async Task<int> SaveDeviceInfoAsync(DeviceInfo deviceInfo)
        {

           return await dbServices.AddDataAsync<DeviceInfo>(deviceInfo);
        }





    }
}













