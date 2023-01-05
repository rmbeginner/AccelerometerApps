﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace AccelerometerApps
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonStart_Clicked(object sender, EventArgs e)
        {
            if (Accelerometer.IsMonitoring)
                return;
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            Accelerometer.Start(SensorSpeed.UI);
        }

        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            LabelX.Text = e.Reading.Acceleration.X.ToString();
            LabelY.Text = e.Reading.Acceleration.Y.ToString();
            LabelZ.Text = e.Reading.Acceleration.Z.ToString();
        }

        private void ButtonStop_Clicked(object sender, EventArgs e)
        {
            if (!Accelerometer.IsMonitoring)
                return;
            Accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
            Accelerometer.Stop();
        }
    }
}
