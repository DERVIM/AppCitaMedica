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
    [Activity(Label = "ActivityDetalleCitas")]
    public class ActivityDetalleCitas : Activity
    {
        CitaSW cita;
        ListView vlistas;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var proxy = new cistasmedicas.ClinicasSW();
            // Create your application here
            SetContentView(Resource.Layout.DetalleCitas);

            int id = Intent.GetIntExtra("id", 0);
            cita = proxy.ListarCita().Where(x => x.ClinicaId == id).FirstOrDefault();
            vlistas = FindViewById<ListView>(Resource.Id.listViewDetalleCitas);

            vlistas.Adapter = new AdapterDetalleCita(this, proxy.ListarClinica().Where(x => x.Id == cita.ClinicaId).ToList());

        }
    }
}