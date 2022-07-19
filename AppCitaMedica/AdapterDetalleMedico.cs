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
    class AdapterDetalleMedico : BaseAdapter<cistasmedicas.EspecialidadSW>
    {
        List<EspecialidadSW> mItems;
        Context mcontext;


        public AdapterDetalleMedico(Context context, List<EspecialidadSW> mItems)
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
        public override EspecialidadSW this[int position]
        {
            get { return mItems[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(mcontext).Inflate(Resource.Layout.DetalleMedicoRow, null, false);
            }
            TextView txtDescripcion = row.FindViewById<TextView>(Resource.Id.textDescripciones);
            txtDescripcion.Text = mItems[position].Descripcion;

            TextView txtHonorarios = row.FindViewById<TextView>(Resource.Id.textHonorarios);
            txtHonorarios.Text = mItems[position].Honorarios;


            return row;
        }
    }
}