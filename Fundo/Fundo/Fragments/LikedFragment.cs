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
using Fundo.Adapter;
using Fundo.Core;
using Fundo.Core.Model;

namespace Fundo.Fragments
{
    public class LikedFragment  : Android.Support.V4.App.Fragment
    {
        private List<ToDoItem> mItems;
        private ListView mListView;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Liked, container, false);
            mListView = view.FindViewById<ListView>(Resource.Id.likedListView);
            mItems = MockData.GetItems();

            CardRowAdapter _adapter = new CardRowAdapter(mItems, container.Context);
            mListView.Adapter = _adapter;

            return view;
        }
    }
}