using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using hackathon.droid.Activities;

namespace hackathon.droid
{
    [Activity(Label = "hackathon.droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.btn_start);

            button.Click += delegate { 
				StartActivity(typeof(CardListView));
			};
        }
    }
}

