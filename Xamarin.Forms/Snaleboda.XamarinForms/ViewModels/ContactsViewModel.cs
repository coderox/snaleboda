using Snaleboda.Library.Interfaces;
using Snaleboda.Library.Models;
using System.Collections.Generic;

namespace Snaleboda.XamarinForms.ViewModels
{
    public class ContactsViewModel
    {

        private IAsyncServiceAgent _asyncServiceAgent;

        public ContactsViewModel(IAsyncServiceAgent asyncServiceAgent)
        {
            _asyncServiceAgent = asyncServiceAgent;

            Initialize();
        }

        private async void Initialize()
        {
            Contacts = await _asyncServiceAgent.GetContactsAsync();
        }

        public IList<ContactModel> Contacts { get; set; }
    }
}
