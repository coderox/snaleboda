using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snaleboda.Core.Interfaces
{
    public interface ISerializerProvider
    {
        T Deserialize<T>(string json);

        string Serialize<T>(T data);
    }
}
