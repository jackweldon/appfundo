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
using Fundo.Core.Model;
using Square.Picasso;

namespace Fundo.Adapter
{
    public class CardRowAdapter : BaseAdapter<ToDoItem>
    {

        public List<ToDoItem> mItems;
        private Context mContext;
        public CardRowAdapter(List<ToDoItem> List, Context Context)
        {
            this.mItems = List;
            this.mContext = Context;
        }


        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView ?? LayoutInflater.From(mContext).Inflate(Resource.Layout.Row_ToDoItem, null, false);

            var txtHeading = row.FindViewById<TextView>(Resource.Id.row_heading);
            var img = row.FindViewById<ImageView>(Resource.Id.row_Image);

            Picasso.With(mContext).Load(mItems[position].Image).Into(img);
            txtHeading.Text = mItems[position].Name;

            return row;
        }

        public override int Count => mItems.Count;

        public override ToDoItem this[int position] => mItems[position];
    }
}