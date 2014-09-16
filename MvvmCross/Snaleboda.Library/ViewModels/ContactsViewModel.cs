using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Snaleboda.Library.Interfaces;
using Snaleboda.Library.Models;

namespace Snaleboda.Library.ViewModels
{
    public class ContactsViewModel : CollectionViewModelBase<ContactViewModel>
    {
        public ContactsViewModel(IAsyncServiceAgent service) : base(service)
        {
            Status = "Loading";
        }


        public ICommand ItemSelected
        {
            get
            {
                return new MvxCommand<ContactViewModel>(contact => contact.CallCommand.Execute(null));
            }
        }

        public override async void Start()
        {
            base.Start();

            try
            {
                IsBusy = true;

                var items = await _service.GetContactsAsync();
                UpdateCollection(items.Select(item => new ContactViewModel(item)));
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
