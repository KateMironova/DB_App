﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using DB_App.Sqlite;

namespace DB_App.Droid
{
    public class RecyclerAdapter: RecyclerView.Adapter
    {
        private List<Person> list;

        public RecyclerAdapter(List<Person> list)
        {
            this.list = list;
        }

        public override int ItemCount => list.Count;

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Item, parent, false);

            RecyclerViewHolder vh = new RecyclerViewHolder(itemView);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var myHolder = holder as RecyclerViewHolder;
            if (myHolder != null)
            {
                myHolder.Id = list[position].Id.ToString();
                myHolder.Fn = list[position].Fn;
                myHolder.Ln = list[position].Ln;
                myHolder.Age = list[position].Age.ToString();
            }
        }
    }
}