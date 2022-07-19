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
    class AdapterMedicos2 : BaseAdapter<cistasmedicas.MedicoSW>
    {
        List<MedicoSW> mItems;
        Context mcontext;

        public AdapterMedicos2(Context context, List<MedicoSW> mItems)
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
        public override MedicoSW this[int position]
        {
            get { return mItems[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(mcontext).Inflate(Resource.Layout.MedicosRow, null, false);
            }
            TextView txtNombres = row.FindViewById<TextView>(Resource.Id.textNombres);
            txtNombres.Text = mItems[position].Nombres;

            TextView txtApellidos = row.FindViewById<TextView>(Resource.Id.textApellidos);
            txtApellidos.Text = mItems[position].Apellidos;

            TextView txtEmail = row.FindViewById<TextView>(Resource.Id.textEmail);
            txtEmail.Text = mItems[position].Email;

            TextView txtTelefono = row.FindViewById<TextView>(Resource.Id.texttelefono);
            txtTelefono.Text = mItems[position].Telefono;

            //TextView txtHorario = row.FindViewById<TextView>(Resource.Id.textHorario);
            //txtHorario.Text = mItems[position].HorarioId.ToString();

            //TextView txtEspecialidad = row.FindViewById<TextView>(Resource.Id.textespecialidad);
            //txtEspecialidad.Text = mItems[position].EspecialidadId.ToString();


            return row;
        }
    }
}