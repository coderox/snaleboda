using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Snaleboda.Library.ViewModels;

namespace Snaleboda.Droid.Views
{
    public class NewsFragment : MvxFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);


            return this.BindingInflate(Resource.Layout.news_fragment, null);

            //var view = inflater.Inflate(Resource.Layout.news_fragment, null);
            //return view;
        }


    }

    public class ContactsFragment : MvxFragment
    {

        ContactsViewModel ContactsViewModel { get { return ViewModel as ContactsViewModel; } }
        private ProgressBar _progressBar = null;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);            
            ContactsViewModel.PropertyChanged += ContactsViewModelOnPropertyChanged;           
            return this.BindingInflate(Resource.Layout.contacts_fragment, null);

            //var view = inflater.Inflate(Resource.Layout.contacts_fragment, null);
            //return view;
        }


        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            _progressBar = this.View.FindViewById<ProgressBar>(Resource.Id.progressBar); 
            base.OnViewCreated(view, savedInstanceState);
        }

        private void ContactsViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "IsBusy")
            {
                if(_progressBar != null)
                    _progressBar.Visibility = ContactsViewModel.IsBusy ? ViewStates.Visible : ViewStates.Gone;
            }
        }
    }

    public class WelcomeFragment : MvxFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.welcome_fragment, null);

            //var view = inflater.Inflate(Resource.Layout.welcome_fragment, null);
            ////view.FindViewById<TextView>(Resource.Id.textView1).SetText(Resource.String.whatson_tab_label);
            ////view.FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(Resource.Drawable.ic_action_whats_on);
            //return view;
        }
    }
}