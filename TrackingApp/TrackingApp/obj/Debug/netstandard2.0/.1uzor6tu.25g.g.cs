//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("", "", typeof(global::TrackingApp.Views.MainView))]

namespace TrackingApp.Views {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("Views/MainView.xaml")]
    public partial class MainView : global::Xamarin.Forms.TabbedPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::TrackingApp.Views.MotionDetectionView MotionDetectionView;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::TrackingApp.Views.TrackingInfoView TrackingInfoView;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::TrackingApp.Views.DeviceInfoView DeviceInfoView;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::TrackingApp.Views.TrackingMapView TrackingMapView;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(MainView));
            MotionDetectionView = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::TrackingApp.Views.MotionDetectionView>(this, "MotionDetectionView");
            TrackingInfoView = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::TrackingApp.Views.TrackingInfoView>(this, "TrackingInfoView");
            DeviceInfoView = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::TrackingApp.Views.DeviceInfoView>(this, "DeviceInfoView");
            TrackingMapView = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::TrackingApp.Views.TrackingMapView>(this, "TrackingMapView");
        }
    }
}
