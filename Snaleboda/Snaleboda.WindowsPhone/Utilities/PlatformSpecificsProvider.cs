using Windows.ApplicationModel.Calls;
using Snaleboda.Library.Interfaces;

namespace Snaleboda.Utilities
{
    public class PlatformSpecificsProvider : IPlatformSpecificsProvider
    {
        public void PhoneCall(string number, string name)
        {
            PhoneCallManager.ShowPhoneCallUI(number, name);
        }
    }
}
