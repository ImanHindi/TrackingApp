using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingApp.ViewModels;
using TrackingApp.ViewModels.Base;
using Xamarin.Forms;

namespace TrackingApp.Views
{
	public partial class MainView : TabbedPage
	{
		public MainView()
		{
			InitializeComponent();
		}


        protected override async void OnAppearing()
        {
            base.OnAppearing();


            MessagingCenter.Subscribe<MainViewModel, int>(this, MessageKeys.ChangeTab, (sender, arg) =>
            {
                switch (arg)
                {
                    case 0:
                        CurrentPage = MotionDetectionView;
                        break;
                    case 1:
                        CurrentPage = TrackingInfoView;
                        break;
                    case 2:
                        CurrentPage = DeviceInfoView;
                        break;
                    case 3:
                        CurrentPage = TrackingMapView;
                        break;
                }
            });

            await ((MotionDetectionViewModel)MotionDetectionView.BindingContext).InitializeAsync(null);
            await ((TrackingInfoViewModel)TrackingInfoView.BindingContext).InitializeAsync(null);
            await ((DeviceInfoViewModel)DeviceInfoView.BindingContext).InitializeAsync(null);
            await ((TrackingMapViewModel)TrackingMapView.BindingContext).InitializeAsync(null);
        }

        protected override async void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
         //   if (CurrentPage is MotionDetectionView)
          //  {
                // Force basket view refresh every time we access it
           //     await (MotionDetectionView.BindingContext as ViewModelBase).InitializeAsync(null);
           // }

            if (CurrentPage is TrackingInfoView)
            {
                // Force basket view refresh every time we access it
                await (TrackingInfoView.BindingContext as ViewModelBase).InitializeAsync(null);
            }
            else if (CurrentPage is DeviceInfoView)
            {
                // Force campaign view refresh every time we access it
                await (DeviceInfoView.BindingContext as ViewModelBase).InitializeAsync(null);
            }
            else if (CurrentPage is TrackingMapView)
           {
               // Force profile view refresh every time we access it
               await (TrackingMapView.BindingContext as ViewModelBase).InitializeAsync(null);
           }
        }
    }
}
