using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snaleboda.Library.Interfaces
{
    public interface IHttpClientProvider
    {
        Task<string> GetJsonAsync(Uri uri);
        Task PutJsonAsync(Uri uri, string json);
    }
}
