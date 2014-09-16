using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Cirrious.MvvmCross.ViewModels;
using Snaleboda.Library.Interfaces;
using Snaleboda.Library.Models;

namespace Snaleboda.Library.ViewModels
{
    public class MainViewModel
        : MvxViewModel
    {
        private readonly IAsyncServiceAgent _service;
        private string _hello = "Hello MvvmCross";
        public string Hello
        {
            get { return _hello; }
            set { _hello = value; RaisePropertyChanged(() => Hello); }
        }

        public NewsViewModel News { get; private set; }
        public ContactsViewModel Contacts { get; private set; }

        public MainViewModel(IAsyncServiceAgent service)
        {
            _service = service;

            News = new NewsViewModel(service);
            Contacts = new ContactsViewModel(service);
        }

        public override async void Start()
        {
            base.Start();

            try
            {
                News.Start();
                Contacts.Start();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
