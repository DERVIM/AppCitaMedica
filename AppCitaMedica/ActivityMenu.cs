using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppCitaMedica
{
    [Activity(Label = "ActivityMenu")]
    public class ActivityMenu : Activity
    {
        Button btncitas;
        Button btnmedicos;
        Button btnlistarcitas;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Menu);
            btncitas = FindViewById<Button>(Resource.Id.btncitas);
            btnmedicos = FindViewById<Button>(Resource.Id.btnmedicos);
            btnlistarcitas = FindViewById<Button>(Resource.Id.btnlistarcitas);
            btncitas.Click += Btncitas_Click;
            btnmedicos.Click += Btnmedicos_Click;
            btnlistarcitas.Click += Btnlistarcitas_Click;
        }

        private void Btnlistarcitas_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityCitas));
            StartActivity(i);
        }

        private void Btnmedicos_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityMedicos));
            StartActivity(i);
        }

        private void Btncitas_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityAgendarCitas));
            StartActivity(i);
        }
    }
}