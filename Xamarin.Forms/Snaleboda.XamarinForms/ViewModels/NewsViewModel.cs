using Snaleboda.Library.Interfaces;
using Snaleboda.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Snaleboda.XamarinForms.ViewModels
{
    public class NewsViewModel : INotifyPropertyChanged
    {
        private IAsyncServiceAgent _asyncServiceAgent;

        public NewsViewModel(IAsyncServiceAgent asyncServiceAgent)
        {
            _asyncServiceAgent = asyncServiceAgent;

            Initialize();
        }

        private async void Initialize()
        {
            News = await _asyncServiceAgent.GetNewsAsync();
        }

        private IList<NewsModel> _news;
        public IList<NewsModel> News
        {
            get { return _news; }
            set
            {
                _news = value;
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
