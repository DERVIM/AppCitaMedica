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
    class AdapterSpinnerCliente : BaseAdapter
    {
        Activity context;
        List<ClienteSW> lista;

        public AdapterSpinnerCliente(Activity context, List<ClienteSW> lista)
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
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Nombres;
            //view.FindViewById<TextView>(Android.Resource.Id.Text2).id = item.Id.ToString();

            return view;
        }

    }
}