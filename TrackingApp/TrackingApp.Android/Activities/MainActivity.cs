using System;
using Plugin.Permissions;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace TrackingApp.Droid
{
    [Activity(Label = "TrackingApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Activity = this;

            base.OnCreate(bundle);
            Xamarin.Forms.Forms.SetFlags("FastRenderers_Experimental");
            global::Xamarin.Forms.Forms.Init(this, bundle);
            Xamarin.FormsMaps.Init(this,bundle);
            LoadApplication(new App());
        }
       
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
          
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        //public static void StartForegroundServiceComapt<T>(this Context context, Bundle args = null) where T : Service
        //{
        //    var intent = new Intent(context, typeof(T));
        //    if (args != null)
        //    {
        //        intent.PutExtras(args);
        //    }

        //    if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
        //    {
        //        context.StartForegroundService(intent);
        //    }
        //    else
        //    {
        //        context.StartService(intent);
        //    }
        //}


    }

}

