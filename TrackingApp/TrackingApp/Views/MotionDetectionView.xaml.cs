﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrackingApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MotionDetectionView : ContentPage
	{
		public MotionDetectionView()
		{
			InitializeComponent ();
		}
	}
}