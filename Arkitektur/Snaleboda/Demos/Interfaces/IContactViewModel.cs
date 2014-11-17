using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snaleboda.Core.Interfaces
{
    public interface IContactViewModel : INotifyPropertyChanged
    {
        string Name { get; }
        string Email { get; }
        string Phone { get; }
        void Call();
    }
}
