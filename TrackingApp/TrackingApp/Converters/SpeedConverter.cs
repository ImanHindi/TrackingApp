// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for details.

using System;
using System.Globalization;
using Xamarin.Forms;

namespace TrackingApp.Converters
{
    public class SpeedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "0 miles";

            double mph = (double) value;
            if ((value is Double))
            {
                double kmh = mph*1.60934;
                return string.Format("{0} km/h", (int) kmh);
            }
            else
                return string.Format("{0} mph", (int) mph);
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}