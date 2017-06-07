using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Huxq17.Swipecardsview;
using Fundo.Core.Model;
using Square.Picasso;

//https://github.com/huxq17/SwipeCardsView
namespace Fundo.Adapter
{
    public class CardAdapter : BaseCardAdapter, SwipeCardsView.ICardsSlideListener
    {
        private List<ToDoItem> mList;
        private Context mContext;

        public CardAdapter(List<ToDoItem> List, Context Context)
        {
            this.mList = List;
            this.mContext = Context;
        }

        public override int CardLayoutId => Resource.Layout.Card_ToDoItem;

        public override int Count => mList.Count;

        public override void OnBindData(int position, View card)
        {
            if (mList == null || mList.Count == 0)
                return;

            var imageView = card.FindViewById<ImageView>(Resource.Id.cardImage);
            var heading = card.FindViewById<TextView>(Resource.Id.heading);
            var description = card.FindViewById<TextView>(Resource.Id.description);
            RatingBar ratingbar = (RatingBar)card.FindViewById(Resource.Id.starRatingBar);
           
            var _item = mList[position];

            heading.Text = _item.Name;
            description.Text = _item.Description;
            ratingbar.Rating = _item.Rating;
            Picasso.With(mContext).Load(_item.Image).Into(imageView);

        }

        public void OnCardVanish(int position, SwipeCardsView.SlideType slideType)
        {
            if (slideType == SwipeCardsView.SlideType.Left)
            {
                //dislike
                Toast.MakeText(mContext, "left", ToastLength.Short).Show();
            }
            if (slideType == SwipeCardsView.SlideType.Right)
            {
                Toast.MakeText(mContext, "right", ToastLength.Short).Show();
            }
        }

        public void OnItemClick(View card, int postion)
        {
            Toast.MakeText(mContext, " Clicked", ToastLength.Short).Show();
        }

        public void OnShow(int positom)
        {
            Toast.MakeText(mContext, $"Showing card at pos {positom}", ToastLength.Short).Show();

        }
    }
 
}