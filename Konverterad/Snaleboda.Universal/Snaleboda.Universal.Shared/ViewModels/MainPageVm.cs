using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.Web.Syndication;
using Snaleboda.Xamarin.Core.Models;
using Snaleboda.Xamarin.Core.Services;

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
            var newsService = new NewsService();
            var items = await newsService.GetNewsAsync();
            NewsItems = items.Select(CreateNewsItem).ToList();
        }

        private NewsVmi CreateNewsItem(News arg)
        {
            return new NewsVmi
            {
                Title = arg.Title,
                Content = arg.Content,
                Id = arg.Id
            };
        }
    }
}
