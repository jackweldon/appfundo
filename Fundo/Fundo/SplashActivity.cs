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
using Fundo.Core.Model;
using Newtonsoft.Json;

namespace Fundo
{
    [Activity(Label = "Fundo",  Icon = "@drawable/icon", Theme = "@style/DefaultTheme",
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
            Intent intent;
            if (pref != null)
            {
                AppUser deserializedProduct = JsonConvert.DeserializeObject<AppUser>(pref.GetString("AppUser", String.Empty));
                if (deserializedProduct == null)
                {
                    //not saved user, need to sign in
                    intent = new Intent(this, typeof(SignUpActivity));
                    StartActivity(intent);
                    return;
                }
            }
            //todo double check user -- go to db maybe and check email and id, maybe refresh the users likes and stuff?
            intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);

        }
    }
}