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
using Org.Apache.Http.Impl.IO;

namespace Fundo
{

    //619800327216-4oi6stqie7dvd5906muif291beu4s2hc.apps.googleusercontent.com
    [Activity(Label = "Sign Up", Icon = "@drawable/icon", Theme = "@style/DefaultTheme",
         ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SignUpActivity : AppCompatActivity, GoogleApiClient.IOnConnectionFailedListener
    {
        private GoogleApiClient mGoogleApiClient;
        private SignInButton mGoogleSignIn;

        private bool mSignInClicked;

        private EditText mEmail;
        private EditText mPassword;
        private Button   mLogin;

        private static int RC_SIGN_IN = 9001;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SignUp);

            mGoogleSignIn = FindViewById<SignInButton>(Resource.Id.sign_in_button);

            mLogin = FindViewById<Button>(Resource.Id.sign_up_btn);
            mPassword = FindViewById<EditText>(Resource.Id.email);
            mEmail = FindViewById<EditText>(Resource.Id.password);


            mGoogleSignIn.Click += mGoogleSignInOnClick;
            mLogin.Click += mLoginOnClick;

            GoogleSignInOptions gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn)
                .RequestEmail().RequestProfile().RequestId().Build();

            mGoogleApiClient = new GoogleApiClient.Builder(this)
                .AddApi(Auth.GOOGLE_SIGN_IN_API, gso)
                .Build();

        }

        private void mLoginOnClick(object sender, EventArgs eventArgs)
        {
            //validate username and password
            //return errors if any
            //send to db
            //validate all that
            //register
            //sign in 
            if (mEmail.Text == String.Empty) return;
            ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
            ISharedPreferencesEditor edit = pref.Edit();
            edit.PutString("Email", mEmail.Text);
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
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

                edit.PutString("Email", acct.Email);
                edit.PutString("Id", acct.Id);

                edit.Apply();
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            }
        }

        public void OnConnectionFailed(ConnectionResult result)
        {
            Log.Debug("OShite!", "onConnectionFailed:" + result);
        }
    }
}