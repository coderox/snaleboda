using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snaleboda.Core.Models;

namespace Snaleboda.Core.Interfaces
{
    public interface IAsyncServiceAgent
    {
        Task<IList<News>> GetNewsAsync();
        Task<IList<Contact>> GetContactsAsync();
        Task PostIncidentAsync(Incident incident);
    }
}
