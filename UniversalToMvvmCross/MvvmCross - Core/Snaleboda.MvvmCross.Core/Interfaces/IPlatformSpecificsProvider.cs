using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snaleboda.Library.Interfaces
{
    public interface IPlatformSpecificsProvider
    {
        void PhoneCall(string number, string name);
    }
}
