using System;
using System.Collections.Generic;
using Snaleboda.Library.Models;

namespace Snaleboda.Library.Interfaces
{
    public interface IServiceAgent
    {
        void GetNews(Action<IList<NewsModel>> callback);

        void GetContacts(Action<IList<ContactModel>> callback);

        void PostIncident(IncidentModel incident);
    }
}
