using System;
using System.Diagnostics;
using Snaleboda.Library.Interfaces;
using Snaleboda.Library.Models;

namespace Snaleboda.Library.ViewModels
{
    public class ContactsViewModel : CollectionViewModelBase<ContactModel>
    {
        public ContactsViewModel(IAsyncServiceAgent service) : base(service)
        {
            Status = "Loading";
        }

        public override async void Start()
        {
            base.Start();

            try
            {
                IsBusy = true;

                var items = await _service.GetContactsAsync();
                UpdateCollection(items);
            }
            catch (Exception ex)
            {
                Status = "Something went wrong"; 
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
