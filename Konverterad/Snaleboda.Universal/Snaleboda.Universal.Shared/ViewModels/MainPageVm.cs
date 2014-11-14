using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Web.Syndication;

namespace Snaleboda.Universal.ViewModels
{
    public class MainPageVm : VmBase
    {
        public IList<NewsVmi> NewsItems { get; set; }
        public IList<ContactVmi> ContactItems { get; set; }

        public MainPageVm()
        {
        }

        public async Task InitAsync()
        {
        }
    }
}
