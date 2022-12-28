using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using MongoDB.Driver.Core;
using MongoDB.Driver;
using System.Security.Authentication;
using static App1.MainPage;
using System.Diagnostics;
using System.Threading;
using MongoDB.Driver.Core.Connections;

namespace App1
{
   


    public interface IMarkupExtension
    {
        object ProvideValue(IServiceProvider serviceProvider);
    }

    [ContentProperty("Member")]
    public class StaticExtension : IMarkupExtension
    {
        public string Member { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return 0;
        }
    }





    public partial class MainPage : ContentPage
    {

        //static float AccelerationX, AccelerationY, AccelerationZ;
        //static float PositionX, PositionY, PositionZ;
        AccelerometerTest at;

        public class Acceleration{
            public Acceleration(DateTime time, AccelerometerChangedEventArgs data) {

                this.time = time;

                X = data.Reading.Acceleration.X;
                Y = data.Reading.Acceleration.Y;
                Z = data.Reading.Acceleration.Z;
            }

            public float X;
            public float Y;
            public float Z;
            public DateTime time;
            public int userid;
            
        }

        public static class AccelerationAdpater {

            public static Acceleration GetAcceleration(DateTime time, AccelerometerChangedEventArgs e) { 

                var acceleration = new Acceleration(time, e);

                return acceleration;
            }
        
        }


    


    public static void ProcessAccelerometerData( Object state)
        {
            Acceleration e = (Acceleration)state;
            
            SendReading(e);
           // return WaitCallback; 
        }

        private void DisplayData(Acceleration data)
        {

            lblAccelX.Text = data.X.ToString();
            lblAccelY.Text = data.Y.ToString();
            lblAccelZ.Text = data.Z.ToString();

            lblTime.Text = data.time.ToString();

        }


       
        private static async void SendReading(Acceleration data)
        {
            var client = Connection.getClient();

            if (Connection._Acceleration == null) {
                Connection.db = client.GetDatabase("Accelerometer");
                Connection._Acceleration = Connection.db.GetCollection<Acceleration>("Acceleration");

            }
            Debug.WriteLine("Hello");
            await Connection._Acceleration.InsertOneAsync(data);
           // throw new NotImplementedException();
        }

       // public static string AccelXStr {
        //    get { return AccelerationX.ToString(); }
        //}

   

        public MainPage()
        {
            InitializeComponent();  
            at = new AccelerometerTest(this);

        }

        bool isMonitoring = false;
        void BtnStart_Clicked(object sender, System.EventArgs e)
        {
            at.ToggleAccelerometer();
            isMonitoring = Accelerometer.IsMonitoring;

            if (isMonitoring) {
                btnStart.Text = "Stop";
            }
            else {
                btnStart.Text = "Start";
               // Clear();
            }
            
        }

        private void Clear()
        {
            lblAccelX.Text = "0";
            lblAccelY.Text = "0";
            lblAccelZ.Text = "0";
        }
    }
}
