using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snaleboda.Core.Interfaces;
using Snaleboda.Core.Models;
using Snaleboda.Core.Services;

namespace Snaleboda.Core.ViewModels
{
    public class NewsViewModel : ViewModelBase, INewsViewModel
    {
        private readonly IAsyncServiceAgent _service;
        public System.Collections.ObjectModel.ObservableCollection<Models.News> Items { get; private set; }

        public NewsViewModel(IAsyncServiceAgent service)
        {
            _service = service;

            Items = new ObservableCollection<News>();
        }

        public async Task LoadAsync()
        {
            var items = await _service.GetNewsAsync();

            foreach (var item in items)
            {
                Items.Add(item);
            }
            //await Task.Delay(1000);
            //Items.Add(new News() { Id = "1", Title = "Title 1", Content = "Content 1" });
        }
    }
}
