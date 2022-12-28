using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Essentials;
using System.Threading;

namespace App1
{
    public class AccelerometerTest
    {
        // Set speed delay for monitoring changes.
        SensorSpeed speed = SensorSpeed.UI;
        MainPage OwnerForm;

        public AccelerometerTest(MainPage Owner)
        {
            // Register for reading changes, be sure to unsubscribe when finished
            OwnerForm = Owner;
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
        }

        async void  Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)//, AccelerometerChangedEventArgs e
        {

            ThreadPool.QueueUserWorkItem(MainPage.ProcessAccelerometerData, MainPage.AccelerationAdpater.GetAcceleration(DateTime.Now, e));

            //OwnerForm.DisplayData(e);

           // var Acceleration = 


            //Debug.WriteLine($"Reading: X: {data.Acceleration.X}, Y: {data.Acceleration.Y}, Z: {data.Acceleration.Z}");
            // Process Acceleration X, Y, and Z

           // await OwnerForm.ProcessAccelerometerData(Acceleration);
        }

        public void ToggleAccelerometer()
        {
            try
            {
                if (Accelerometer.IsMonitoring)
                    Accelerometer.Stop();
                else
                    Accelerometer.Start(speed);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }
    }
}
