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
    [Activity(Label = "ActivityMenuRegistrar")]
    public class ActivityMenuRegistrar : Activity
    {
        Button cliente;
        Button medico;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.MenuRegistrar);

            cliente = FindViewById<Button>(Resource.Id.btnregistrarusuario);
            medico = FindViewById<Button>(Resource.Id.btnregistrarmedicos);

            cliente.Click += Cliente_Click;
            medico.Click += Medico_Click;
        }

        private void Medico_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityRegistrarMedico));
            StartActivity(i);
        }

        private void Cliente_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityRegistrarUsuario));
            StartActivity(i);
        }
    }
}