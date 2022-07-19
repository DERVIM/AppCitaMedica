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
    class AdapterSpinnerClinica : BaseAdapter
    {
        Activity context;
        List<ClinicaSW> lista;

        public AdapterSpinnerClinica(Activity context, List<ClinicaSW> lista)
        {
            this.context = context;
            this.lista = lista;
        }

        public override int Count => lista.Count;
        public override Java.Lang.Object GetItem(int position)
        {
            return position;
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
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.NombreClinica;
            // view.FindViewById<TextView>(Android.Resource.Id.Text2).Text = item.Id.ToString();

            return view;
        }
    }
}