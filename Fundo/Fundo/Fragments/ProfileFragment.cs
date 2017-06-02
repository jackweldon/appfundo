using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Fundo.Fragments
{
    public class ProfileFragment : Android.Support.V4.App.Fragment
    {
        private TextView mEmail;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Profile, container, false);

            var sharedPreferences = Activity.ApplicationContext.GetSharedPreferences("UserInfo", FileCreationMode.Append);
            // then you use
            var email =sharedPreferences.GetString("Email",String.Empty);
            if (email != String.Empty)
            {
                mEmail = view.FindViewById<TextView>(Resource.Id.email);
                mEmail.Text = email;
            }

            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            return view;
        }


    }
}