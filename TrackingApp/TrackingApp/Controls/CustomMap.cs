using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TrackingApp.Controls
{
   public class CustomMap : Map
    {
        public CustomMap()
        {
            RouteCoordinates = new ObservableCollection<Position>();
        
        }

        public static readonly BindableProperty MapPinsProperty = BindableProperty.Create(
                 nameof(Pins),
                 typeof(ObservableCollection<Pin>),
                 typeof(CustomMap),
                 new ObservableCollection<Pin>(),
                 propertyChanged: (b, o, n) =>
                 {
                     var bindable = (CustomMap)b;
                     bindable.Pins.Clear();

                     var collection = (ObservableCollection<Pin>)n;
                     foreach (var item in collection)
                         bindable.Pins.Add(item);
                     collection.CollectionChanged += (sender, e) =>
                     {
                         Device.BeginInvokeOnMainThread(() =>
                         {
                             switch (e.Action)
                             {
                                 case NotifyCollectionChangedAction.Add:
                                 case NotifyCollectionChangedAction.Replace:
                                 case NotifyCollectionChangedAction.Remove:
                                     if (e.OldItems != null)
                                         foreach (var item in e.OldItems)
                                             bindable.Pins.Remove((Pin)item);
                                     if (e.NewItems != null)
                                         foreach (var item in e.NewItems)
                                             bindable.Pins.Add((Pin)item);
                                     break;
                                 case NotifyCollectionChangedAction.Reset:
                                     bindable.Pins.Clear();
                                     break;
                             }
                         });
                     };
                 });
        public IList<Pin> MapPins { get; set; }

        public static readonly BindableProperty MapPositionProperty = BindableProperty.Create(
                 nameof(MapPosition),
                 typeof(Position),
                 typeof(CustomMap),
                 new Position(0, 0),
                 propertyChanged: (b, o, n) =>
                 {
                     ((CustomMap)b).MoveToRegion(MapSpan.FromCenterAndRadius(
                          (Position)n,
                          Distance.FromMiles(1)));
                 });

        public Position MapPosition { get; set; }

        public static readonly BindableProperty RouteCoordinatesProperty =
                               BindableProperty.Create(nameof(RouteCoordinates),
                                   typeof(ObservableCollection<Position>), 
                                   typeof(CustomMap),
                                   new ObservableCollection<Position>(),
                                   BindingMode.TwoWay,

                propertyChanged: (b, o, n) =>
                {
                    var bindable = (CustomMap)b;
                    bindable.RouteCoordinates.Clear();
                    

                        var collection = (ObservableCollection<Position>) n;
                        foreach (var item in collection)
                            bindable.RouteCoordinates.Add(item);
                        collection.CollectionChanged += (sender, e) =>
                        {
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                switch (e.Action)
                                {
                                    case NotifyCollectionChangedAction.Add:
                                    case NotifyCollectionChangedAction.Replace:
                                    case NotifyCollectionChangedAction.Remove:
                                        if (e.OldItems != null)
                                            foreach (var item in e.OldItems)
                                                bindable.RouteCoordinates.Remove((Position) item);
                                        if (e.NewItems != null)
                                            foreach (var item in e.NewItems)
                                                bindable.RouteCoordinates.Add((Position) item);
                                        break;
                                    case NotifyCollectionChangedAction.Reset:
                                        bindable.RouteCoordinates.Clear();
                                        break;

                                }
                            });
                        };
                    
                });
        public IList<Position> RouteCoordinates
        {
            get { return (IList<Position>)GetValue(RouteCoordinatesProperty); }
            set { SetValue(RouteCoordinatesProperty, value); }
        }
        public Position SelectedPosition
        {
            get { return (Position)GetValue(SelectedPositionProperty); }
            set { SetValue(SelectedPositionProperty, value); }
        }

        public static readonly BindableProperty SelectedPositionProperty =
            BindableProperty.Create(nameof(SelectedPosition), typeof(Position), typeof(CustomMap), new Position(), BindingMode.OneWayToSource);

        //public List<Position> RouteCoordinates
        //{
        //    get; 
        //    set ; 
        //}

        public event EventHandler<MapTapEventArgs> Tapped;
        public void OnTap(Position coordinate)
        {
            OnTap(new MapTapEventArgs { SelectedPosition = coordinate });

        }
        protected virtual void OnTap(MapTapEventArgs e)
        {
            var handler = Tapped;

            if (handler != null)
                handler(this, e);
            SelectedPosition = e.SelectedPosition;
        }
    }


    public class MapTapEventArgs : EventArgs
    {
        public Position SelectedPosition { get; set; }

    }
}
