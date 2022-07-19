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
    class AdapterDetalleMedico2 : BaseAdapter<cistasmedicas.HorarioSW>
    {
        List<HorarioSW> mItems;
        Context mcontext;

        public AdapterDetalleMedico2(Context context, List<HorarioSW> mItems)
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
        public override HorarioSW this[int position]
        {
            get { return mItems[position]; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(mcontext).Inflate(Resource.Layout.DetalleMedicoRow2, null, false);
            }
            TextView txtHorarioInicio = row.FindViewById<TextView>(Resource.Id.textHoraInicio);
            txtHorarioInicio.Text = mItems[position].HoraInicio;

            TextView txtHorarioFin = row.FindViewById<TextView>(Resource.Id.textHoraFin);
            txtHorarioFin.Text = mItems[position].HoraFin;


            return row;
        }

    }
}