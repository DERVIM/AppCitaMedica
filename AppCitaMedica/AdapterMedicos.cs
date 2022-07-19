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
    class AdapterMedicos : BaseAdapter
    {
        Activity context;
        List<MedicoSW> lista;

        public AdapterMedicos(Activity context, List<MedicoSW> lista)
        {
            this.context = context;
            this.lista = lista;
        }


        public override int Count => lista.Count;
        //public override int Count
        //{
        //    get { return lista.Count; }
        //}
        public override Java.Lang.Object GetItem(int position)
        {
            throw new NotImplementedException();
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = lista[position];
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Nombres;
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Apellidos;
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Email;
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Telefono;
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.EspecialidadId.ToString();
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.HorarioId.ToString();

            return view;

        }
    }
}