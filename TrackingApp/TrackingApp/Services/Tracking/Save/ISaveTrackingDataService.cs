using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TrackingApp.Models.Tracking;

namespace TrackingApp.Services.Tracking
{
    public interface ISaveTrackingDataService
    {

        Task<int> SaveTrackingInfoAsync(TrackingData trackingData);

      

    }
}
