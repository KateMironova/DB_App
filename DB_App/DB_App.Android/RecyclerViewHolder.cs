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
using Android.Support.V7.Widget;

namespace DB_App.Droid
{
    public class RecyclerViewHolder : RecyclerView.ViewHolder
    {
        private TextView personId;
        private TextView personFn;
        private TextView personLn;
        private TextView personAge;
        protected RecyclerViewHolder(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
        public RecyclerViewHolder(View itemView) : base(itemView)
        {
            personId = itemView.FindViewById<TextView>(Resource.Id.personId);
            personFn = itemView.FindViewById<TextView>(Resource.Id.personFn);
            personLn = itemView.FindViewById<TextView>(Resource.Id.personLn);
            personAge = itemView.FindViewById<TextView>(Resource.Id.personAge);

            var btn = itemView.FindViewById<Button>(Resource.Id.updatePersonBtn);
            btn.Click += delegate { UpdatePerson(itemView.Context); };
        }
        private void UpdatePerson(Context context)
        {
            Intent intent = new Intent(context, typeof(EditActivity));
            intent.PutExtra("id", int.Parse(personId.Text));
            context.StartActivity(intent);
        }
        public string Id {
            get => personId.Text;
            set => personId.Text = value;
        }
        public string Fn {
            get => personFn.Text;
            set => personFn.Text = value;
        }
        public string Ln {
            get => personLn.Text;
            set => personLn.Text = value;
        }
        public string Age {
            get => personAge.Text;
            set => personAge.Text = value;
        }

    }
}