using Plugin.Connectivity;
using System;
using Xamarin.Forms;

namespace TrackingApp.Services.Settings
{
    public class SettingsService : ISettingsService
    {

        ISettingsServiceImplementation AppSettings
        {
            get { return DependencyService.Get<ISettingsServiceImplementation>(); ; }
        }

   

        #region Setting Constants

        private const string AccessToken = "access_token";
        private const string IdToken = "id_token";
        private const string IdUseLocalDb = "use_LocalDbs";
        private const string IdUrlBase = "url_base";
        private const string IdUseDefaultLocation = "use_location";
        private const string IdLatitude = "latitude";
        private const string IdLongitude = "longitude";
        private const string IdAllowGpsLocation = "allow_gps_location";
        private const string IdAccessTokenExpirationDate = "AccessTokenExpirationDate";
        private const string IdPassword = "Password";
        private const string IdUsername = "Username";
        private readonly string UrlBaseDefault = GlobalSetting.Instance.BaseEndpoint;

        private readonly string AccessTokenDefault = string.Empty;
        private readonly string IdTokenDefault = string.Empty;
        private readonly bool UseLocalDbDefault = false;//!CrossConnectivity.Current.IsConnected;
        private readonly bool UseLocationDefault = false;
        private readonly bool AllowGpsLocationDefault = false;
        private readonly double LatitudeDefault = 47.604610d;
        private readonly double LongitudeDefault = -122.315752d;
       // private readonly string UrlBaseDefault = GlobalSetting.Instance.BaseEndpoint;

        private readonly DateTime AccessTokenExpirationDateDefault = DateTime.UtcNow;

        private readonly string PasswordDefault = string.Empty;

        private readonly string UsernameDefault = string.Empty;
        #endregion

        public string AuthAccessToken
        {
            get => AppSettings.GetValueOrDefault(AccessToken, AccessTokenDefault);
            set => AppSettings.AddOrUpdateValue(AccessToken, value);
        }

        public string AuthIdToken
        {
            get => AppSettings.GetValueOrDefault(IdToken, IdTokenDefault);
            set => AppSettings.AddOrUpdateValue(IdToken, value);
        }

        public bool UseLocalDb
        {
            get => AppSettings.GetValueOrDefault(IdUseLocalDb, UseLocalDbDefault);
            set => AppSettings.AddOrUpdateValue(IdUseLocalDb, value);
        }

        public string UrlBase
        {
            get => AppSettings.GetValueOrDefault(IdUrlBase, UrlBaseDefault);
            set => AppSettings.AddOrUpdateValue(IdUrlBase, value);
        }

        public bool UseDefaultLocation
        {
            get => AppSettings.GetValueOrDefault(IdUseDefaultLocation, UseLocationDefault);
            set => AppSettings.AddOrUpdateValue(IdUseDefaultLocation, value);
        }

        public string Latitude
        {
            get => AppSettings.GetValueOrDefault(IdLatitude, LatitudeDefault.ToString());
            set => AppSettings.AddOrUpdateValue(IdLatitude, value);
        }

        public string Longitude
        {
            get => AppSettings.GetValueOrDefault(IdLongitude, LongitudeDefault.ToString());
            set => AppSettings.AddOrUpdateValue(IdLongitude, value);
        }

        public bool AllowGpsLocation
        {
            get => AppSettings.GetValueOrDefault(IdAllowGpsLocation, AllowGpsLocationDefault);
            set => AppSettings.AddOrUpdateValue(IdAllowGpsLocation, value);
        }

        public string Username
        {
            get => AppSettings.GetValueOrDefault(IdUsername, UsernameDefault);
            set => AppSettings.AddOrUpdateValue(IdUsername, value);
        }
        public string Password
        {
            get => AppSettings.GetValueOrDefault(IdPassword, PasswordDefault);
            set => AppSettings.AddOrUpdateValue(IdPassword, value);
        }

        public DateTime AccessTokenExpirationDate
        {
            get => AppSettings.GetValueOrDefault(IdAccessTokenExpirationDate, AccessTokenExpirationDateDefault);
            set => AppSettings.AddOrUpdateValue(IdAccessTokenExpirationDate, value);
        }
    }
}