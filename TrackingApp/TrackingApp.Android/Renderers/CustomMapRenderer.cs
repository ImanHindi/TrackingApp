using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TrackingApp.Controls;
using TrackingApp.Droid.Renderers;
using TrackingApp.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace TrackingApp.Droid.Renderers
{
   public class CustomMapRenderer : MapRenderer


    {
      //  List<Position> routeCoordinates;
         GoogleMap map;
        Polyline polyline;
        CustomMap customMap;

        public CustomMapRenderer(Context context) : base(context)
        {
        }

        //protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Map> e)
        //{
        //    base.OnElementChanged(e);

        //    if (e.OldElement != null)
        //    {
        //        // Unsubscribe
        //    }

        //    if (e.NewElement != null)
        //    {
        //        var formsMap = (CustomMap) e.NewElement;
        //        routeCoordinates = formsMap.RouteCoordinates;
        //        Control.GetMapAsync(this);
        //    }
        //}
        //protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    base.OnElementPropertyChanged(sender, e);
        //    if (this.Element == null || this.Control == null)
        //        return;

        //    if (e.PropertyName == CustomMap.RouteCoordinatesProperty.PropertyName)
        //    {
        //        UpdatePolyLine();
        //    }
        //}


        protected override void OnMapReady(GoogleMap googleMap)
        {
            base.OnMapReady(map);
            map = googleMap;
            UpdatePolyLine();

            if (map != null)
            { 
                map.MapClick += NativeMap_MapClick;
            }

        }

        private void NativeMap_MapClick(object sender, GoogleMap.MapClickEventArgs e)
        {
            var position = new Position(e.Point.Latitude, e.Point.Longitude);

            ((CustomMap)Element).OnTap(position);

        }
            protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
            {
                base.OnElementChanged(e);

                if (e.OldElement != null)
                {
                // Unsubscribe
                    if (map != null)
                    map.MapClick -= NativeMap_MapClick;
                }

            if (e.NewElement != null)
            {
                customMap = e.NewElement as CustomMap;

                ((MapView)Control).GetMapAsync(this);
            }
            UpdatePolyLine();

            }
            protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
            {
                base.OnElementPropertyChanged(sender, e);
                if (this.Element == null || this.Control == null)
                    return;

                if (e.PropertyName == CustomMap.RouteCoordinatesProperty.PropertyName)
                {
                    UpdatePolyLine();
                }
            }
        private void UpdatePolyLine()
        {
            if (map != null && ((CustomMap)this.Element).RouteCoordinates != null)

            {
                if (polyline != null)
                {
                    polyline.Remove();
                    polyline.Dispose();
                }

                var polylineOptions = new PolylineOptions();
                polylineOptions.InvokeColor(0x66FF0000);
                foreach (var position in ((CustomMap)this.Element).RouteCoordinates)
                {
                    polylineOptions.Add(new LatLng(position.Latitude, position.Longitude));
                }
                polyline = map.AddPolyline(polylineOptions);
            }
        }

    }
}

