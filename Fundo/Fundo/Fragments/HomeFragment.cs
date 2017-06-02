using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Huxq17.Swipecardsview;
using Fundo.Adapter;
using Fundo.Core;
using Fundo.Core.Model;

namespace Fundo.Fragments
{
    public class HomeFragment : Android.Support.V4.App.Fragment
    {
        private SwipeCardsView swipeCardView;
        private List<ToDoItem> _mList = new List<ToDoItem>();

        public override void OnCreate(Bundle savedInstanceState)
        {
         
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.Home, container, false);

            _mList = MockData.GetItems();

            swipeCardView = view.FindViewById<SwipeCardsView>(Resource.Id.swipeCardsView);
            swipeCardView.EnableSwipe(true);

            swipeCardView.RetainLastCard(false);
            var cardAdapter = new CardAdapter(_mList, inflater.Context);
            swipeCardView.SetAdapter(cardAdapter);
            swipeCardView.SetCardsSlideListener(cardAdapter);

            return view;
        }
    }
}