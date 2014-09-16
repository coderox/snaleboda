using Snaleboda.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snaleboda.Library.Interfaces
{
    public interface IAsyncServiceAgent
    {
        Task<IList<NewsModel>> GetNewsAsync();
        
        Task<IList<ContactModel>> GetContactsAsync();
        
        Task PostIncidentAsync(IncidentModel incident);
    }
}
