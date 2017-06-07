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
using Android.Locations;
using Com.Huxq17.Swipecardsview;
using Fundo.Adapter;
using Fundo.Core;
using Fundo.Core.Model;
using Fundo.Core.RestService;
using Fundo.Fragments;
using Newtonsoft.Json;
using FragmentTransaction = Android.Support.V4.App.FragmentTransaction;
using SupportFragment = Android.Support.V4.App.Fragment;
//http://android-holo-colors.com/
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

        private HomeFragment mHomeFragment;
        private ProfileFragment mProfileFragment;
        private LikedFragment mLikedFragment;

        private Spinner _spinnerCategory;
        private SeekBar _priceSeekBar;
        private Button _searchButton;

        private FundoRestService _fundoRestService;
        private AppUser _currentAppUser;
        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);
            
            mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_search);
            mLeftDrawer = FindViewById<LinearLayout>(Resource.Id.drawer_left);

            ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
            _currentAppUser = JsonConvert.DeserializeObject<AppUser>(pref.GetString("AppUser", String.Empty));

            #region Drawer Variables
            _priceSeekBar = FindViewById<SeekBar>(Resource.Id.price_seekbar);
            _priceSeekBar.Max = 200;
            _priceSeekBar.ProgressChanged += (sender, e) => {
                if (e.FromUser)
                {
                    Toast.MakeText(this, $"The value of the SeekBar is {e.Progress}", ToastLength.Long).Show();
                }
            };
            _spinnerCategory = FindViewById<Spinner>(Resource.Id.category_group);
            _spinnerCategory.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.groups_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            _spinnerCategory.Adapter = adapter;


            _searchButton = FindViewById<Button>(Resource.Id.search_button);
            _searchButton.Click += SearchButtonOnClick;
            #endregion
            #region Frag manager Region

            var trans = SupportFragmentManager.BeginTransaction();

            new Stack<SupportFragment>();
            mHomeFragment = new HomeFragment();
            mProfileFragment = new ProfileFragment();
            mLikedFragment = new LikedFragment();
            

            trans.Add(Resource.Id.fragmentContainer, mHomeFragment, "Home");
            trans.Commit();

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

            _fundoRestService = new FundoRestService();
        }

        private async void SearchButtonOnClick(object sender, EventArgs eventArgs)
        {
            //search -- user location, categoryy, price, user Id, radius,
            var items = await _fundoRestService.SearchToDoItemsAsync(new FundoSearchModel());

            LocationManager lm = (LocationManager)GetSystemService(Context.LocationService);
            Location location = lm.GetLastKnownLocation(LocationManager.GpsProvider);
            double longitude = location.Longitude;
            double latitude = location.Latitude;


        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            string toast = string.Format("The planet is {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
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
            trans.Replace(Resource.Id.fragmentContainer, fragment);
            trans.AddToBackStack(null);
            trans.Commit();
        }
        public override void OnBackPressed()
        {
            
            base.OnBackPressed();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            mDrawerToggle.OnOptionsItemSelected(item);
            return base.OnOptionsItemSelected(item);
        }
    }
}



