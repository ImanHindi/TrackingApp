using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using TrackingApp.Services.LocalDb;
using TrackingApp.Models.Tracking;
using System.Collections.Generic;

namespace TrackingApp.Services.Tracking
{
    public class SaveTrackingDataLocalService : ISaveTrackingDataService
    {
     
       

        IDbServices dbServices;
        public SaveTrackingDataLocalService(IDbServices DbServices)
        {
              dbServices = DbServices;

        }



        public async Task<int> SaveTrackingInfoAsync(TrackingData trackingData)
        {

            return await dbServices.AddDataAsync(trackingData);
            //ObservableCollection<TrackingData> TrackingDataSaved = trackingData;
            //return TrackingDataSaved;
        }


    }
}









