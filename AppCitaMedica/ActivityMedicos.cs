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
    [Activity(Label = "ActivityMedicos")]
    public class ActivityMedicos : Activity
    {
        ListView vlistas;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Medicos);
            vlistas = FindViewById<ListView>(Resource.Id.listViewMedicos);

            var proxy = new cistasmedicas.ClinicasSW();



            vlistas.Adapter = new AdapterMedicos2(this, proxy.ListarMedico().ToList());

            vlistas.ItemClick += Vlistas_ItemClick;
        }

        private void Vlistas_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityDetalleMedicos));
            var proxy = new cistasmedicas.ClinicasSW();
            MedicoSW medico = proxy.ListarMedico()[e.Position];

            i.PutExtra("id", medico.EspecialidadId);
            i.PutExtra("id2", medico.HorarioId);

            StartActivity(i);
        }
    }
}