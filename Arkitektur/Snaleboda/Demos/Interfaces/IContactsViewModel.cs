using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snaleboda.Core.Interfaces
{
    public interface IContactsViewModel : INotifyPropertyChanged
    {
        ObservableCollection<IContactViewModel> Items { get; }

        Task LoadAsync();
    }
}
