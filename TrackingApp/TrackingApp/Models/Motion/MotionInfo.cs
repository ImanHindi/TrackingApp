using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using DeviceMotion.Plugin.Abstractions;

namespace TrackingApp.Models.Motion
{
   public class MotionInfo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public DateTimeOffset DataTimeOffset { get; set; }

        public MotionSensorValueType ValueType { get; set; }
        public MotionSensorType SensorType { get; set; }
        public MotionValue Value { get; set; }
        public double XValue { get; set; }
        public double YValue { get; set; }
        public double ZValue { get; set; }
        public string Sensor { get; set; }
        public string Type { get; set; }


    }
}
