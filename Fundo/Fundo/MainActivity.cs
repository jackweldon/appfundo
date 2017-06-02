using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Internal;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Content.PM;
using Com.Huxq17.Swipecardsview;
using Fundo.Adapter;
using Fundo.Core;
using Fundo.Core.Model;
using Fundo.Fragments;
using FragmentTransaction = Android.Support.V4.App.FragmentTransaction;
using SupportFragment = Android.Support.V4.App.Fragment;

namespace Fundo
{
    [Activity(Label = "Fundo", Icon = "@drawable/icon",Theme="@style/DefaultTheme",
         ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        private BottomNavigationView mBottomNavigation;
        private SupportToolbar mToolbar;
        private ActionBarDrawerToggle mDrawerToggle;
        private DrawerLayout mDrawerLayout;
        private LinearLayout mLeftDrawer;
        private SwipeCardsView swipeCardView;


        private Stack<SupportFragment> mStackFragment;
        private SupportFragment mCurrenFragment;
        private HomeFragment mHomeFragment;
        private ProfileFragment mProfileFragment;
        private LikedFragment mLikedFragment;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);

            mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_search);
            mLeftDrawer = FindViewById<LinearLayout>(Resource.Id.drawer_left);

            #region Frag manager regioi

            var trans = SupportFragmentManager.BeginTransaction();

            mStackFragment = new Stack<SupportFragment>();
            mHomeFragment = new HomeFragment();
            mProfileFragment = new ProfileFragment();
            mLikedFragment = new LikedFragment();
            

            trans.Add(Resource.Id.fragmentContainer, mHomeFragment, "Home");
            trans.Commit();

            mCurrenFragment = mHomeFragment;

            #endregion

            SetSupportActionBar(mToolbar);

            mDrawerToggle = new CustomActionBarDrawerToggle(this,
                mDrawerLayout,
                Resource.String.openDrawer,
                Resource.String.ApplicationName);
                        
            mDrawerLayout.AddDrawerListener(mDrawerToggle);

            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            mDrawerToggle.SyncState();

            mBottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);

            mBottomNavigation.NavigationItemSelected += MBottomNavigationOnNavigationItemSelected;
        }

        private void MBottomNavigationOnNavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs menuItem)
        {
            
            switch (menuItem.Item.ItemId)
            {
                case Resource.Id.action_profile:
                   ReplaceFragment(mProfileFragment);
                    break;
                case Resource.Id.action_home:
                    ReplaceFragment(mHomeFragment);
                    break;
                case Resource.Id.action_like:
                    ReplaceFragment(mLikedFragment);
                    break;
            }
        }

      
        public void ReplaceFragment(SupportFragment fragment)
        {
            if (fragment.IsVisible) return;

            var trans = SupportFragmentManager.BeginTransaction();
           // trans.SetCustomAnimations(Resource.Animation.slide_in, Resource.Animation.slide_out, Resource.Animation.slide_in, Resource.Animation.slide_out);

            trans.Replace(Resource.Id.fragmentContainer, fragment);
            trans.AddToBackStack(null);
            trans.Commit();

            mCurrenFragment = fragment;
        }
        public override void OnBackPressed()
        {
            /*unrequired with replace
            if (SupportFragmentManager.BackStackEntryCount > 0)
            {
                SupportFragmentManager.PopBackStack();
                mCurrenFragment = mStackFragment.Pop();
            }
            else
            {
                base.OnBackPressed();

            }*/
            base.OnBackPressed();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            mDrawerToggle.OnOptionsItemSelected(item);
            return base.OnOptionsItemSelected(item);
        }
    }
}



