using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Fundo
{
    [Activity(Label = "Fundo", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/DefaultTheme",
         ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Splash);

            //todo change uerinfo to the user model and fetch from DB etc
            ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
            string email = pref.GetString("Email", String.Empty);
            string id = pref.GetString("Id", String.Empty);

            if (email == String.Empty || id == String.Empty)
            {
                //not saved user, need to sign in
                var intent = new Intent(this, typeof(SignUpActivity));
                StartActivity(intent);
            }
            else
            {
                //todo double check user -- go to db maybe and check email and id, maybe refresh the users likes and stuff?
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            }
        }
    }
}