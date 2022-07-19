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
    [Activity(Label = "ActivityAgendarCitas")]
    public class ActivityAgendarCitas : Activity
    {
        EditText fecha;
        EditText telefono;
        EditText descripcion;
        Spinner cliente;
        Spinner clinica;
        Button btnagendar;
        int idcliente, idclinica;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AgendarCitas);

            fecha = FindViewById<EditText>(Resource.Id.Fecha);
            telefono = FindViewById<EditText>(Resource.Id.Telefono);
            descripcion = FindViewById<EditText>(Resource.Id.Descripcion);
            cliente = FindViewById<Spinner>(Resource.Id.spinnerCliente);
            clinica = FindViewById<Spinner>(Resource.Id.spinnerClinica);
            btnagendar = FindViewById<Button>(Resource.Id.btnAgendar);
            //clinica.ItemSelected += Clinica_ItemSelected;
            // clinica.ItemSelected += Clinica_ItemSelected;
            btnagendar.Click += Btnagendar_Click;
            var proxy = new cistasmedicas.ClinicasSW();

            //ClienteSW[] items = proxy.ListarCliente().ToArray();
            //ClinicaSW[] items2 = proxy.ListarClinica().ToArray();

            //ArrayAdapter<ClienteSW> adapter = new ArrayAdapter<ClienteSW>(this, Android.Resource.Layout.SimpleSpinnerItem, items);
            //adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            //cliente.Adapter = adapter;
            //clinica.ItemSelected += Clinica_ItemSelected;

            //ArrayAdapter<ClinicaSW> adapter2 = new ArrayAdapter<ClinicaSW>(this, Android.Resource.Layout.SimpleSpinnerItem, items2);
            //adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            //clinica.Adapter = adapter2;
            //clinica.ItemSelected += Clinica_ItemSelected;
            var adapter = new AdapterSpinnerCliente(this, proxy.ListarCliente2().ToList());

            cliente.Adapter = adapter;

            var adapter2 = new AdapterSpinnerClinica(this, proxy.ListarClinica().ToList());
            clinica.Adapter = adapter2;

        }
        private void Clinica_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            Spinner clinica = (Spinner)sender;

            string toast = string.Format("El cliente es {0}", clinica.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
            idclinica = (int)clinica.GetItemAtPosition(e.Position);
        }
        private void Btnagendar_Click(object sender, EventArgs e)
        {
            var proxy = new cistasmedicas.ClinicasSW();
            string Fecha, Telefono, Descripcion;
            int Cliente, Clinica;
            bool agendar;
            Fecha = fecha.Text;
            Telefono = telefono.Text;
            Descripcion = descripcion.Text;
            Cliente = (int)cliente.SelectedItemId + 1;
            Clinica = (int)clinica.SelectedItemId + 1;

            agendar = proxy.AgregarCita(Fecha,int.Parse(Telefono), Descripcion, Cliente, Clinica);
            if (agendar == true)
            {
                Toast.MakeText(this, "Cita Registrada", ToastLength.Long).Show();

            }
            else
            {
                Toast.MakeText(this, "No se puede registrar la cita", ToastLength.Long).Show();
            }

        }
    }
}