using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snaleboda.Core.Models;

namespace Snaleboda.Core.Interfaces
{
    public interface INewsViewModel : INotifyPropertyChanged
    {
        ObservableCollection<News> Items { get; }

        Task LoadAsync();
    }
}
