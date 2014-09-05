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

        public ObservableCollection<NewsModel> News { get; private set; }
        public ObservableCollection<ContactModel> Contacts { get; private set; }

        public MainViewModel(IAsyncServiceAgent service)
        {
            _service = service;

            News = new ObservableCollection<NewsModel>();
            Contacts = new ObservableCollection<ContactModel>();
        }

        public override async void Start()
        {
            base.Start();

            try
            {
                var news = await _service.GetNewsAsync();
                if (news == null)
                    return;

                foreach (var newsModel in news)
                {
                    News.Add(newsModel);
                }

                var contacts = await _service.GetContactsAsync();
                if (contacts == null)
                    return;

                foreach (var contact in contacts)
                {
                    Contacts.Add(contact);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
