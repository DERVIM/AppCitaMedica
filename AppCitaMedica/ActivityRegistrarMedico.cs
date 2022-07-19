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
    [Activity(Label = "ActivityRegistrarMedico")]
    public class ActivityRegistrarMedico : Activity
    {
        EditText usuario;
        EditText contraseña;
        EditText telefono;
        EditText nombres;
        EditText apellidos;
        Spinner especialidad;
        Spinner horario;
        Button btnregistrar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.RegistrarMedico);
            var proxy = new cistasmedicas.ClinicasSW();
            usuario = FindViewById<EditText>(Resource.Id.txtusuario);
            contraseña = FindViewById<EditText>(Resource.Id.txtcontraseña);
            telefono = FindViewById<EditText>(Resource.Id.txtTelefono);
            nombres = FindViewById<EditText>(Resource.Id.txtNombres);
            apellidos = FindViewById<EditText>(Resource.Id.txtApellidos);
            especialidad = FindViewById<Spinner>(Resource.Id.spinnerEspecialidad);
            horario = FindViewById<Spinner>(Resource.Id.spinnerHorario);
            btnregistrar = FindViewById<Button>(Resource.Id.btnRegistrar);

            btnregistrar.Click += Btnregistrar_Click;

            var adapter = new AdapterSpinnerEspecialidad(this, proxy.ListarEspecialidad().ToList());
            especialidad.Adapter = adapter;
            var adapter2 = new AdapterSpinnerHorario(this, proxy.ListarHorario().ToList());
            horario.Adapter = adapter2;
        }

        private void Btnregistrar_Click(object sender, EventArgs e)
        {
            var proxy = new cistasmedicas.ClinicasSW();
            string Usuario, Contraseña, Telefono, Nombres, Apellidos;
            bool registrar1;
            bool registrar2;
            int Especialidad, Horario;

            Usuario = usuario.Text;
            Contraseña = contraseña.Text;
            Telefono = telefono.Text;
            Nombres = nombres.Text;
            Apellidos = apellidos.Text;
            Especialidad = (int)especialidad.SelectedItemId + 1;
            Horario = (int)horario.SelectedItemId + 1;

            registrar1 = proxy.RegistrarUsuarioMedico(Usuario, Contraseña);
            registrar2 = proxy.AgregarMedico(Nombres, Apellidos, Usuario,int.Parse( Telefono), Horario, Especialidad);
            if (registrar2 == true)
            {
                Toast.MakeText(this, "Usuario Registrado", ToastLength.Long).Show();
                Intent i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
            }
            else
            {
                Toast.MakeText(this, "Vuelva intentarlo", ToastLength.Long).Show();
            }
        }
    }
}