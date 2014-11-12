using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.MvvmCross.ViewModels;
using Snaleboda.Library.Interfaces;
using Snaleboda.Library.Models;
using System.Collections.ObjectModel;

namespace Snaleboda.Core.ViewModels
{
    public class NewsViewModel : MvxViewModel
    {
        private readonly IAsyncServiceAgent _service;
        private string _status = string.Empty;
        public string Status
        {
            get { return _status; }
            set { _status = value; RaisePropertyChanged(() => Status); }
        }

        public ObservableCollection<NewsModel> Items { get; private set; }

        public NewsViewModel(IAsyncServiceAgent service)
        {
            _service = service;

            Items = new ObservableCollection<NewsModel>();
            Status = "Loading";
        }

        public override async void Start()
        {
            base.Start();

            try
            {
                var items = await _service.GetNewsAsync();
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
            catch(Exception ex)
            {
                Status = "No items found"; 
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
