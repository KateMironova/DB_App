using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;

namespace DB_App.Droid
{
	[Activity (Label = "DB_App.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        private IDBHandler _db;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            _db = new RealmHandler();

            SetContentView(Resource.Layout.Main);

            var recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));
        }

        protected override void OnResume()
        {
            base.OnResume();

            List<Person> list = new List<Person>();
            for (int i = 0; i < 20; i++)
            {
                list.Add((Person)_db.Read(i));
            }

            FindViewById<RecyclerView>(Resource.Id.recyclerView).SetAdapter(new RecyclerAdapter(list));
        }
    }
}


