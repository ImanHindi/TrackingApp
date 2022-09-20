using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TrackingApp.Services.Settings;

namespace TrackingApp.Models.Tracking
{
   public class TrackingData
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }


        //public ListenerSettings listenerSettings { get; set; }
        //public TimeSpan minimumTime { get; set; }
        //public double minimumDistance { get; set; }
        //public bool includeHeading { get; set; }

        //Date Info
        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public DateTimeOffset DataTimeOffset { get; set; }


        //Current Location Info
        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public double Altitude { get; set; }
        public double AltitudeAccuracy { get; set; }


        //Moving Info

        public double Speed { get; set; }

        public double Heading { get; set; }
        
        public bool IsPositionChanged { get; set; }

        public string Direction { get; set; }

        public double Accuracy { get; set; }

        //Internet & GPS Connection Info

      //  public bool InternetConnected { get; set; }

       // public bool GSMEnabled { get; set; }
        
        // Gets if you are listening for location changes
        
        //bool IsListening { get; }
    }
}
