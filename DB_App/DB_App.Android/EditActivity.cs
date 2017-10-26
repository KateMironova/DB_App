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

namespace DB_App.Droid
{
    [Activity(Label = "EditActivity")]
    public class EditActivity: Activity
    {
        IDBHandler db;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Edit);
        }
        protected override void OnResume()
        {
            base.OnResume();
            db = new RealmHandler();
            Person p = db.Read(Intent.GetIntExtra("id", 0)) as Person;

            if (p != null)
            {
                FindViewById<TextView>(Resource.Id.editPersonId).Text = p.Id.ToString();
                FindViewById<EditText>(Resource.Id.editPersonFn).Text = p.Fn;
                FindViewById<EditText>(Resource.Id.editPersonLn).Text = p.Ln;
                FindViewById<EditText>(Resource.Id.editPersonAge).Text = p.Age.ToString();
            }

            FindViewById<Button>(Resource.Id.editPersonSaveBtn).Click += delegate { OnBackPressed(); };
        }

        public override void OnBackPressed()
        {
            Person p = new Person()
            {
                Id = int.Parse(FindViewById<TextView>(Resource.Id.editPersonId).Text),
                Fn = FindViewById<EditText>(Resource.Id.editPersonFn).Text,
                Ln = FindViewById<EditText>(Resource.Id.editPersonLn).Text,
                Age = int.Parse(FindViewById<EditText>(Resource.Id.editPersonAge).Text)
            };

            db.Update(p);

            base.OnBackPressed();
        }
    }
}