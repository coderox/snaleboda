using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snaleboda.Core.Interfaces;
using Snaleboda.Core.Services;

namespace Snaleboda.Core.ViewModels
{
    public class ContactsViewModel : ViewModelBase, IContactsViewModel
    {
        private readonly IAsyncServiceAgent _service;

        public System.Collections.ObjectModel.ObservableCollection<IContactViewModel> Items { get; private set; }

        public ContactsViewModel(IAsyncServiceAgent service)
        {
            _service = service;

            Items = new ObservableCollection<IContactViewModel>();
        }

        public async Task LoadAsync()
        {
            var items = await _service.GetContactsAsync();

            foreach (var item in items)
            {
                Items.Add(new ContactViewModel(item));
            }
        }
    }
}
