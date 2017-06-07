using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Auth.Api;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Common;
using Android.Gms.Common.Apis;
using Android.Gms.Plus;
using Android.Gms.Plus.Model.People;
using Android.OS;
using Android.Provider;
using Android.Support.V7.App;
using Android.Util;
using Android.Widget;
using Fundo.Core.Model;
using Newtonsoft.Json;
using Org.Apache.Http.Impl.IO;

namespace Fundo
{

    //619800327216-4oi6stqie7dvd5906muif291beu4s2hc.apps.googleusercontent.com
    [Activity(Label = "Fundo Sign Up", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/DefaultTheme",
         ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SignUpActivity : AppCompatActivity, GoogleApiClient.IOnConnectionFailedListener
    {
        private GoogleApiClient mGoogleApiClient;
        private SignInButton mGoogleSignIn;

        private bool mSignInClicked;

        private Button mLogin;

        private static int RC_SIGN_IN = 9001;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SignUp);

            ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
            if (pref != null)
            {
                AppUser deserializedProduct = JsonConvert.DeserializeObject<AppUser>(pref.GetString("AppUser", String.Empty));
                if (deserializedProduct != null)
                {
                    //todo double check user -- go to db maybe and check email and id, maybe refresh the users likes and stuff?
                    Intent intent = new Intent(this, typeof(MainActivity));
                    StartActivity(intent);
                    return;
                }
            }

            mGoogleSignIn = FindViewById<SignInButton>(Resource.Id.sign_in_button);


            mGoogleSignIn.Click += mGoogleSignInOnClick;

            GoogleSignInOptions gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn)
                .RequestEmail().RequestProfile().RequestId().Build();

            mGoogleApiClient = new GoogleApiClient.Builder(this)
                .AddApi(Auth.GOOGLE_SIGN_IN_API, gso)
                .Build();

        }



        private void mGoogleSignInOnClick(object sender, EventArgs eventArgs)
        {
            if (!mGoogleApiClient.IsConnecting)
            {
                mSignInClicked = true;
                Intent signInIntent = Auth.GoogleSignInApi.GetSignInIntent(mGoogleApiClient);
                StartActivityForResult(signInIntent, RC_SIGN_IN);
            }
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == RC_SIGN_IN)
            {
                if (resultCode == Result.Ok)
                {

                    GoogleSignInResult res = Auth.GoogleSignInApi.GetSignInResultFromIntent(data);
                    HandleSignInResult(res);

                }
            }
        }

        private void HandleSignInResult(GoogleSignInResult result)
        {

            if (result.IsSuccess)
            {
                // Signed in successfully, show authenticated UI.

                GoogleSignInAccount acct = result.SignInAccount;

                ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
                ISharedPreferencesEditor edit = pref.Edit();
                string output = JsonConvert.SerializeObject(new AppUser
                {
                    accounts = new AccountInfo
                    {
                        type = AccountType.Google,
                        uid = acct.Id

                    },
                    firstname = acct.GivenName,
                    lastname = acct.FamilyName,
                    email = acct.Email
                });
                edit.PutString("AppUser", output);

                edit.Apply();
                var intent = new Intent(this, typeof(MainActivity));
                intent.AddFlags(Intent.Flags & ActivityFlags.ClearTop);
                StartActivity(intent);
            }
        }

        public void OnConnectionFailed(ConnectionResult result)
        {
            Log.Debug("OShite!", "onConnectionFailed:" + result);
        }
    }
}