using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Snaleboda.Xamarin.Core.Models;
using System.Threading.Tasks;
using Snaleboda.Xamarin.Core.Services;

namespace Snaleboda.Xamarin.Droid.Adapters
{
    public class ContactsAdapter : ArrayAdapter<Contact>
    {
        private Activity _context;
        private ContactService _contactService;
        private List<Contact> _contacts;

        public ContactsAdapter(Activity context) : base(context,Resource.Layout.contact_listitem)
        {
            _context = context;
            _contactService = new ContactService();
        }

        public async Task Init()
        {
            _contacts = await _contactService.GetContactsAsync();
            AddAll(_contacts);
            NotifyDataSetChanged();
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View rowView = convertView;
            ViewHolder holder;

            if (rowView == null)
            {
                LayoutInflater inflater = _context.LayoutInflater;
                rowView = inflater.Inflate(Resource.Layout.contact_listitem, null);
                holder = new ViewHolder();
                holder.Name = (TextView)rowView.FindViewById(Resource.Id.name);
                holder.Number = (TextView)rowView.FindViewById(Resource.Id.number);
                holder.Email = (TextView)rowView.FindViewById(Resource.Id.email);
                rowView.Tag = holder;
            }
            else
            {
                holder = (ViewHolder)rowView.Tag;
            }

            holder.Name.Text = _contacts[position].Name;
            holder.Number.Text = _contacts[position].Phone;
            holder.Email.Text = _contacts[position].Email;


            return rowView;
        }

        private class ViewHolder : Java.Lang.Object
        {
            public TextView Name {get;set;}
            public TextView Number { get; set; }
            public TextView Email { get; set; }
        }
    }
}