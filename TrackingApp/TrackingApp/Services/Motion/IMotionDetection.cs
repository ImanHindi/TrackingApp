using DeviceMotion.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TrackingApp.Services.Motion
{
   public interface IMotionDetection
   {
        Task StartMotionDetection(MotionSensorType type, MotionSensorDelay delay);
       Task StopMotionDetection(MotionSensorType type);
   }
}
