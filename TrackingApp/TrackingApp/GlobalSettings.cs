using System;
using System.Collections.Generic;
using System.Text;

namespace TrackingApp
{
   
        public class GlobalSetting
        {
            public const string ServerTag = "Server";
            public const string LocalTag = "LocalDB";
            public const string DefaultEndpoint = "http://localhost:54247/";

            private string _baseEndpoint;
            private static readonly GlobalSetting _instance = new GlobalSetting();

            public GlobalSetting()
            {
                AuthToken = "INSERT AUTHENTICATION TOKEN";
                BaseEndpoint = DefaultEndpoint;
            }

            public static GlobalSetting Instance
            {
                get { return _instance; }
            }

            public string BaseEndpoint
            {
                get { return _baseEndpoint; }
                set
                {
                    _baseEndpoint = value;
                    UpdateEndpoint(_baseEndpoint);
                }
            }

            public string ClientId { get { return "xamarin"; } }

            public string ClientSecret { get { return "secret"; } }

            public string AuthToken { get; set; }

            public string RegisterWebsite { get; set; }

          //  public string ToursGuideCatalogEndpoint { get; set; }
          //  public string PlacesEndpoint { get; set; }
          //  public string VenuesEndpoint { get; set; }


          //  public string CitiesEndpoint { get; set; }
         //   public string CountriesEndpoint { get; set; }
         //   public string ToursShopCatalogEndpoint { get; private set; }
        //    public string OrdersEndpoint { get; set; }

         //   public string BasketEndpoint { get; set; }

       //     public string IdentityEndpoint { get; set; }

            public string LocationEndpoint { get; set; }

       //     public string MarketingEndpoint { get; set; }

     //       public string UserInfoEndpoint { get; set; }

            public string TokenEndpoint { get; set; }

            public string LogoutEndpoint { get; set; }

            public string IdentityCallback { get; set; }

            public string LogoutCallback { get; set; }

            private void UpdateEndpoint(string baseEndpoint)
            {
                RegisterWebsite = $"{baseEndpoint}:api/Account/Register";
              //  ToursGuideCatalogEndpoint = $"{baseEndpoint}:api/ToursGuideCatalog";
                //VenuesEndpoint = $"{baseEndpoint}:api/ToursGuideCatalog/VenueInfoModels";

                //PlacesEndpoint = $"{baseEndpoint}:api/ToursGuideCatalog/PlaceInfoModels";
                //CitiesEndpoint = $"{baseEndpoint}:api/ToursGuideCatalog/CityInfoModels";
                //CountriesEndpoint = $"{baseEndpoint}:api/ToursGuideCatalog/CountryInfoModels";
              //  ToursShopCatalogEndpoint = $"{baseEndpoint}:api/ToursShopCatalog";

             //   OrdersEndpoint = $"{baseEndpoint}:api/Orders";
             //   BasketEndpoint = $"{baseEndpoint}:api/Basket";
             //   IdentityEndpoint = $"{baseEndpoint}:api/connect/authorize";
             //   UserInfoEndpoint = $"{baseEndpoint}:api/Account/UserInfoModels";
                TokenEndpoint = $"{baseEndpoint}:token";
                LogoutEndpoint = $"{baseEndpoint}:api/connect/endsession";
                IdentityCallback = $"{baseEndpoint}:api/xamarincallback";
                LogoutCallback = $"{baseEndpoint}:api/Account/Redirecting";
                LocationEndpoint = $"{baseEndpoint}:api/Location";
             //   MarketingEndpoint = $"{baseEndpoint}:api/Marketing";
            }
        }
    }


