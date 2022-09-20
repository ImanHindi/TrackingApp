using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using TrackingApp.Models.Motion;
using TrackingApp.ViewModels.Base;
using Xamarin.Forms;

namespace TrackingApp.Services.Motion
{
    public class MotionDetection: IMotionDetection
    {

        public async Task  StartMotionDetection(MotionSensorType type, MotionSensorDelay delay)
        {
           
                
            await Task.Delay(2000);
            CrossDeviceMotion.Current.Start(type, delay );

            CrossDeviceMotion.Current.SensorValueChanged += (sender, a) =>
            {
                var Motion = new MotionInfo()
                {
                    Value = a.Value,
                    ValueType = a.ValueType,
                    SensorType = a.SensorType,
                };
                MessagingCenter.Send(this, MessageKeys.UpdateMotion, Motion);

                CrossDeviceMotion.Current.Stop(type);

            };

        }

        public async Task StopMotionDetection(MotionSensorType type)
        {
            if (CrossDeviceMotion.Current.IsActive(type))
            {

                await Task.Delay(2000);

                CrossDeviceMotion.Current.Stop(type);
                CrossDeviceMotion.Current.SensorValueChanged -= (sender, e) =>
                {
                    var Motion = new MotionInfo()
                    {
                        Value = e.Value,
                        ValueType = e.ValueType,
                        SensorType = e.SensorType,
                    };
                };
            }

          

        }

      

    }
}
