//using TrackingApp.Services.FixUri;
using TrackingApp.Services.Settings;
using TrackingApp.Services;
using System;
using System.Globalization;
using System.Reflection;
using TinyIoC;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using TrackingApp.Services.WebService;
using TrackingApp.Services.LocalDb;
using TrackingApp.Services.Device;
using TrackingApp.Services.Motion;
using TrackingApp.Services.Tracking;
using TrackingApp.Services.Tracking.Connectivity;

namespace TrackingApp.ViewModels.Base
{
    public static class ViewModelLocator
    {
        private static TinyIoCContainer _container;

        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(ViewModelLocator.AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
        }


        static ViewModelLocator()
        {
            _container = new TinyIoCContainer();

            // View models

            _container.Register<MainViewModel>();
            _container.Register<MotionDetectionViewModel>();

            _container.Register<TrackingMapViewModel>();
            _container.Register<TrackingInfoViewModel>();
            _container.Register<DeviceInfoViewModel>();
            _container.Register<SettingsViewModel>();


            // Services
            _container.Register<IRequestProvider, RequestProvider>();
            _container.Register<IDbServices, DbServices>().AsSingleton(); 
            _container.Register<INavigationService, NavigationService>().AsSingleton();
            _container.Register<IDialogService, DialogService>();
         

           



           // _container.Register<ISettingsService, SettingsService>().AsSingleton();
            _container.Register<IConnectivity, Connectivity>().AsSingleton();
            _container.Register<IMotionDetection, MotionDetection>().AsSingleton();

            _container.Register<ICollectDeviceInfoService, CollectDeviceInfoService>().AsSingleton();
            _container.Register<ICollectTrackingDataService, CollectTrackingDataService>().AsSingleton();
            _container.Register<ISaveDeviceInfoService, SaveDeviceInfoLocalService>().AsSingleton();
            _container.Register<ISaveTrackingDataService, SaveTrackingDataLocalService>().AsSingleton();
           // _container.Register<ISaveDeviceInfoService, SaveDeviceInfoService>().AsSingleton();
           // _container.Register<ISaveTrackingDataService, SaveTrackingDataService>().AsSingleton();
        }

      

        public static void RegisterSingleton<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            _container.Register<TInterface, T>().AsSingleton();
        }

        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }
            var viewModel = _container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
    }
}