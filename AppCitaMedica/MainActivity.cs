using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Threading;

namespace AppCitaMedica
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        //Timer timer = new Timer();
        EditText usuario;
        EditText pass;
        Button btnLogear, btncrearcuenta;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
        
            usuario = FindViewById<EditText>(Resource.Id.usuario);
            pass = FindViewById<EditText>(Resource.Id.contraseña);
            btnLogear = FindViewById<Button>(Resource.Id.btnIngresar);
            btncrearcuenta = FindViewById<Button>(Resource.Id.btnRegistrar);
            btncrearcuenta.Click += Btncrearcuenta_Click;
            btnLogear.Click += BtnLogear_Click;
        }

        private void BtnLogear_Click(object sender, EventArgs e)
        {
            var proxy = new cistasmedicas.ClinicasSW();
            string usu, pswd, logear;
            usu = usuario.Text;
            pswd = pass.Text;

            logear = proxy.LogueoUsuario(usu, pswd);
            if (logear == "Cliente" || logear == "Medico" || logear == "Admin")
            {
                Intent i = new Intent(this, typeof(ActivityMenu));
                StartActivity(i);
            }
            else
            {
                Toast.MakeText(this, "Este usuario no existe", ToastLength.Long).Show();
            }
        }

        private void Btncrearcuenta_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityMenuRegistrar));
            StartActivity(i);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}