using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace XamarinCountdown
{
    [Activity(Label = "SplashScreen", MainLauncher = true, Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class SplashScreen : AppCompatActivity
    {
        private static int[] images = new int[]
        {
            Resource.Drawable.splashscreen1,
            Resource.Drawable.splashscreen
            
        };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SplashScreen);

            Random rd = new Random();
            int id = rd.Next(images.Length - 1);

            ImageView imageView = FindViewById<ImageView>(Resource.Id.imageView);
            imageView.SetImageResource(images[1]);

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 5000;
            timer.AutoReset = false;
            timer.Elapsed += (object sender, ElapsedEventArgs e) => {
                StartActivity(new Intent(this, typeof(MainActivity)));
                OverridePendingTransition(Resource.Animation.fadein, Resource.Animation.fadeout);
                base.Finish();

            };
            timer.Start();
        }
    }
}