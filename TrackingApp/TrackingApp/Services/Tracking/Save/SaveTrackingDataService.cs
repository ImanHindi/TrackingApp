using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TrackingApp.Models.Tracking;
//using TrackingApp.Services.FixUri;
using TrackingApp.Services;
using TrackingApp.Services.WebService;

namespace TrackingApp.Services.Tracking
{
    public class SaveTrackingDataService : ISaveTrackingDataService
    {
        private readonly IRequestProvider _requestProvider;
      //  private readonly IFixUriService _fixUriService;

        public SaveTrackingDataService(IRequestProvider requestProvider)//, //IFixUriService fixUriService)
        {
            _requestProvider = requestProvider;
           // _fixUriService = fixUriService;
        }
        public async Task<int> SaveTrackingInfoAsync(TrackingData trackingData)
        {
            UriBuilder builder = new UriBuilder();//GlobalSetting.Instance.TrackingDataEndpoint);
            builder.Path = string.Format("api/TrackingData");
            string uri = builder.ToString();

            var TrackingDataSaved = await _requestProvider.PostAsync <TrackingData> (uri, trackingData);

            if (TrackingDataSaved != null)
                return 1;
            else
                return 0;


        }

    }
}
