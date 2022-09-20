// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for details.

using System;
using Xamarin.Forms;
using System.Globalization;

namespace TrackingApp.Converters
{
    //convert miles to km. Input is miles
    public class DistanceConverter : IValueConverter
    {
       
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "0 miles";

            double distance = (double)value;
            if ((value is Double))
            {
                double km = distance * 1.60934;
                return string.Format("{0:0.00} km", km);
            }
            else
                return string.Format("{0:0.00} miles", distance);
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}