using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Cirrious.MvvmCross.ViewModels;
using Snaleboda.Library.Interfaces;

namespace Snaleboda.Library.ViewModels
{
    public abstract class CollectionViewModelBase<T> : MvxViewModel
    {
        protected readonly IAsyncServiceAgent _service;
        private string _status = string.Empty;
        public string Status
        {
            get { return _status; }
            set { _status = value; RaisePropertyChanged(() => Status); }
        }

        private bool _isBusy = false;        

        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; RaisePropertyChanged(() => IsBusy);  }
        }

        public ObservableCollection<T> Items { get; private set; }

        public CollectionViewModelBase(IAsyncServiceAgent service)
        {
            _service = service;

            Items = new ObservableCollection<T>();
        }

        protected void UpdateCollection(IEnumerable<T> items)
        {
            try
            {
                Items.Clear();

                if (items == null)
                {
                    Status = "No items found";
                    return;
                }

                foreach (var item in items)
                {
                    Items.Add(item);
                }
                Status = string.Empty;
            }
            catch (Exception ex)
            {
                Status = "No items found";
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
