using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snaleboda.Library.Interfaces
{
    public interface ISerializer
    {
        T Deserialize<T>(string content);
        string Serialize(object content);
    }
}
