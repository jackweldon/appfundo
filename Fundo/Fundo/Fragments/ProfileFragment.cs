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
using Fundo.Core.Model;
using Newtonsoft.Json;

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

            ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);

            AppUser _currentAppUser = JsonConvert.DeserializeObject<AppUser>(pref.GetString("AppUser", String.Empty));
            if (_currentAppUser != null)
            {
                mEmail = view.FindViewById<TextView>(Resource.Id.email);
                mEmail.Text = _currentAppUser.email;
            }
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            return view;
        }
        
    }
}