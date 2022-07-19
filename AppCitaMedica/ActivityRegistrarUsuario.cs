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
    [Activity(Label = "ActivityRegistrarUsuario")]
    public class ActivityRegistrarUsuario : Activity
    {
        EditText usuario;
        EditText contraseña;
        EditText telefono;
        EditText nombres;
        EditText apellidos;
        Button btnRegistrar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.RegistrarUsuario);

            usuario = FindViewById<EditText>(Resource.Id.usuario);
            contraseña = FindViewById<EditText>(Resource.Id.contraseña);
            telefono = FindViewById<EditText>(Resource.Id.Telefono);
            nombres = FindViewById<EditText>(Resource.Id.Nombres);
            apellidos = FindViewById<EditText>(Resource.Id.Apellidos);
            btnRegistrar = FindViewById<Button>(Resource.Id.btnRegistrar);

            btnRegistrar.Click += BtnRegistrar_Click;
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            var proxy = new cistasmedicas.ClinicasSW();
            string Usuario, Contraseña, Telefono, Nombres, Apellidos;
            bool registrar1;
            bool registrar2;
            Usuario = usuario.Text;
            Contraseña = contraseña.Text;
            Telefono = telefono.Text;
            Nombres = nombres.Text;
            Apellidos = apellidos.Text;

            registrar1 = proxy.AgregarCliente(Nombres, Apellidos,int.Parse( Telefono), Usuario);
            registrar2 = proxy.RegistrarUsuarioCliente(Usuario, Contraseña);
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