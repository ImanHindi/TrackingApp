using Plugin.DeviceInfo.Abstractions;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrackingApp.Models.Device
{
  public  class DeviceInfo
    {
        [PrimaryKey, AutoIncrement]

        public string Id { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public string OSVersion { get; set; }
        [Ignore]
        public Version VersionNo { get; set; }
        public string Manufacturer { get; set; }
        [Ignore]
        public Platform Platform { get; set; }
        [Ignore]
        public Idiom Idiom { get; set; }
        public bool IsDevice { get; set; }

        public string AppVersion { get; set; }


    }

}
