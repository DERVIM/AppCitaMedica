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
    class AdapterDetalleCita : BaseAdapter<cistasmedicas.ClinicaSW>
    {
        List<ClinicaSW> mItems;
        Context mcontext;

        public AdapterDetalleCita(Context context, List<ClinicaSW> mItems)
        {
            this.mcontext = context;
            this.mItems = mItems;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        public override int Count
        {
            get { return mItems.Count; }
        }
        public override ClinicaSW this[int position]
        {
            get { return mItems[position]; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(mcontext).Inflate(Resource.Layout.DetalleCitasRow, null, false);
            }
            TextView txtNombreClinica = row.FindViewById<TextView>(Resource.Id.textNombreCliente);
            txtNombreClinica.Text = mItems[position].NombreClinica;

            TextView txtTelefono = row.FindViewById<TextView>(Resource.Id.textTelefonoClinica);
            txtTelefono.Text = mItems[position].Telefono;

            TextView txtDireccion = row.FindViewById<TextView>(Resource.Id.textDireccion);
            txtDireccion.Text = mItems[position].Direccion;


            return row;
        }
    }
}