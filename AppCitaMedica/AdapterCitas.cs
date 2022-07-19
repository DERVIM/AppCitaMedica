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
    class AdapterCitas : BaseAdapter<cistasmedicas.CitaSW>
    {
        List<CitaSW> mItems;
        Context mcontext;

        public AdapterCitas(Context context, List<CitaSW> mItems)
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
        public override CitaSW this[int position]
        {
            get { return mItems[position]; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            View row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(mcontext).Inflate(Resource.Layout.CitasRow, null, false);
            }
            TextView txtFecha = row.FindViewById<TextView>(Resource.Id.textFecha);
            txtFecha.Text = mItems[position].Fecha;

            TextView txtDescripcion = row.FindViewById<TextView>(Resource.Id.textDescripcon);
            txtDescripcion.Text = mItems[position].Descripcion;

            //TextView txtCliente = row.FindViewById<TextView>(Resource.Id.textCliente);
            //txtCliente.Text = mItems[position].ClienteId.ToString();

            //TextView txtClinica = row.FindViewById<TextView>(Resource.Id.textClinica);
            //txtClinica.Text = mItems[position].ClinicaId.ToString();

            return row;
        }
    }
}