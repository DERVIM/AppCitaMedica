using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppCitaMedica.cistasmedicas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppCitaMedica
{
    [Activity(Label = "ActivityCitas")]
    public class ActivityCitas : Activity
    {
        ListView vlistas;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Citas);

            vlistas = FindViewById<ListView>(Resource.Id.listViwCitas);

            var proxy = new cistasmedicas.ClinicasSW();

            vlistas.Adapter = new AdapterCitas(this, proxy.ListarCita().ToList());

            vlistas.ItemClick += Vlistas_ItemClick;
        }

        private void Vlistas_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityDetalleCitas));
            var proxy = new cistasmedicas.ClinicasSW();
            CitaSW cita = proxy.ListarCita()[e.Position];

            i.PutExtra("id", cita.ClinicaId);

            StartActivity(i);
        }
    }
}