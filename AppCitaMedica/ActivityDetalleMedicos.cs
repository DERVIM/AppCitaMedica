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
    [Activity(Label = "ActivityDetalleMedicos")]
    public class ActivityDetalleMedicos : Activity
    {
        MedicoSW medico;
        MedicoSW medico2;
        ListView vlistas;
        ListView vlistas2;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var proxy = new cistasmedicas.ClinicasSW();
            // Create your application here
            SetContentView(Resource.Layout.DetalleMedico);
            int id = Intent.GetIntExtra("id", 0);
            int id2 = Intent.GetIntExtra("id2", 0);
            medico = proxy.ListarMedico().Where(x => x.EspecialidadId == id).FirstOrDefault();
            medico2 = proxy.ListarMedico().Where(x => x.HorarioId == id2).FirstOrDefault();
            vlistas = FindViewById<ListView>(Resource.Id.listViewDetalleMedicos);
            vlistas2 = FindViewById<ListView>(Resource.Id.listViewDetalleMedicos2);

            vlistas.Adapter = new AdapterDetalleMedico(this, proxy.ListarEspecialidad().Where(x => x.Id == medico.EspecialidadId).ToList());
            // vlistas.Adapter = new AdapterDetalleMedico2(this, proxy.ListarHorario().Where(x => x.Id == medico.HorarioId).ToList());
        }
    }
}