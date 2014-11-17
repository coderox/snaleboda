using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snaleboda.Core.Interfaces;

namespace Snaleboda.Core.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        public string Greeting
        {
            get { return "Hello world"; }
        }

        public INewsViewModel News { get; private set; }

        public IContactsViewModel Contacts { get; private set; }


        public MainViewModel(INewsViewModel news, IContactsViewModel contacts)
        {
            News = news;
            Contacts = contacts;
        }

        public Task LoadAsync()
        {
            return Task.WhenAll(
                News.LoadAsync(),
                Contacts.LoadAsync());
        }
    }
}
