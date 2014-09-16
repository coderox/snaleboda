using Snaleboda.Library.Interfaces;
using Snaleboda.Library.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Snaleboda.XamarinForms.ViewModels
{
    public class ContactsViewModel : INotifyPropertyChanged
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

        private IList<ContactModel> _contacts;
        public IList<ContactModel> Contacts
        {
            get { return _contacts; }
            set
            {
                _contacts = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
