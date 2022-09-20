using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreLocation;
using Foundation;
using MapKit;
using ObjCRuntime;
using TrackingApp.Controls;
using TrackingApp.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace TrackingApp.iOS.Renderers
{
 public class CustomMapRenderer : MapRenderer
        {
            MKPolylineRenderer polylineRenderer;
            private readonly UITapGestureRecognizer _tapRecogniser;
            CustomMap map;
        public CustomMapRenderer()
            {
                _tapRecogniser = new UITapGestureRecognizer(OnTap)
                {
                    NumberOfTapsRequired = 1,
                    NumberOfTouchesRequired = 1
                };
            }
            private void OnTap(UITapGestureRecognizer recognizer)
            {
                var cgPoint = recognizer.LocationInView(Control);

                var location = ((MKMapView)Control).ConvertPoint(cgPoint, Control);

                ((CustomMap)Element).OnTap(new Position(location.Latitude, location.Longitude));
            }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
            {
                base.OnElementChanged(e);

                if (e.OldElement != null)
                {
                    var nativeMap = Control as MKMapView;
                    if (nativeMap != null)
                    {
                        nativeMap.RemoveOverlays(nativeMap.Overlays);
                        nativeMap.OverlayRenderer = null;
                        polylineRenderer = null;
                        if (Control != null)
                        Control.RemoveGestureRecognizer(_tapRecogniser);

                }
            }

                if (e.NewElement != null)
                {
                    var formsMap = (CustomMap)e.NewElement;
                    var nativeMap = Control as MKMapView;
                    nativeMap.OverlayRenderer = GetOverlayRenderer;

                    CLLocationCoordinate2D[] coords = new CLLocationCoordinate2D[formsMap.RouteCoordinates.Count];
                    int index = 0;
                    foreach (var position in formsMap.RouteCoordinates)
                    {
                        coords[index] = new CLLocationCoordinate2D(position.Latitude, position.Longitude);
                        index++;
                    }

                    var routeOverlay = MKPolyline.FromCoordinates(coords);
                    nativeMap.AddOverlay(routeOverlay);
                    if (Control != null)
                    Control.AddGestureRecognizer(_tapRecogniser);

            }
        }
        MKOverlayRenderer GetOverlayRenderer(MKMapView mapView, IMKOverlay overlayWrapper)
        {
            if (polylineRenderer == null && !Equals(overlayWrapper, null))
            {
                var overlay = Runtime.GetNSObject(overlayWrapper.Handle) as IMKOverlay;
                polylineRenderer = new MKPolylineRenderer(overlay as MKPolyline)
                {
                    FillColor = UIColor.Blue,
                    StrokeColor = UIColor.Red,
                    LineWidth = 3,
                    Alpha = 0.4f
                };
            }
            return polylineRenderer;
        }

            protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
            {
                base.OnElementPropertyChanged(sender, e);

                if ((this.Element == null) || (this.Control == null))
                    return;

                if (e.PropertyName == CustomMap.RouteCoordinatesProperty.PropertyName)
                {
                    map = (CustomMap)sender;
                    UpdatePolyLine();
                }
            }
            private void UpdatePolyLine()
            {

                var nativeMap = Control as MKMapView;

                nativeMap.OverlayRenderer = GetOverlayRenderer;

                CLLocationCoordinate2D[] coords = new CLLocationCoordinate2D[map.RouteCoordinates.Count];

                int index = 0;
                foreach (var position in map.RouteCoordinates)
                {
                    coords[index] = new CLLocationCoordinate2D(position.Latitude, position.Longitude);
                    index++;
                }

                var routeOverlay = MKPolyline.FromCoordinates(coords);
                nativeMap.AddOverlay(routeOverlay);
            }

    }
}
   