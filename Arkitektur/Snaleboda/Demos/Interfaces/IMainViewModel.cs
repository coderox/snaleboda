using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snaleboda.Core.Interfaces
{
    public interface IMainViewModel : INotifyPropertyChanged
    {
        string Greeting { get; }

        INewsViewModel News { get; }

        IContactsViewModel Contacts { get; }

        Task LoadAsync();
    }
}
