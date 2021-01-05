using System.Net.Http;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace Oink.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private readonly HttpClient _client = new HttpClient();

        private const string ServiceUrl = "http://192.168.0.31:55555/oink";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var button = FindViewById<ImageView>(Resource.Id.button);

            button.Click += async (sender, args) => { await _client.PostAsync(ServiceUrl, null); };
        }
    }
}