using System;
using System.Linq;
using Snaleboda.UniversalDemo.ViewModels;

namespace Snaleboda.UniversalDemo.SampleData
{
    public class MainPageVmSampleData : MainPageVm
    {
        public MainPageVmSampleData()
        {
            ContactItems = new[]
            {
                CreateContact("John", "Doe"),
                CreateContact("Bartholmew", "Doe", "1"),
                CreateContact("Ike", "Longhorsdottir", "1"),
                CreateContact("Ike", "Longhorsdottir", "555-546546546")
            };

            NewsItems = new[]
            {
                CreateNews("Xamarin köpte Microsoft", "lång text", 2),
                CreateNews("Xamarin köpte", "lång text", 2),
                CreateNews("Xamarin", "lång text igen och igen", 25),
                CreateNews("Xamarin köpte Microsoft", "lång text", 10),
            };
        }

        private NewsVmi CreateNews(string title, string content, int contentCount)
        {
            return new NewsVmi
            {
                Title = title,
                Content = string.Join(" ", Enumerable.Repeat(content, contentCount))
            };
        }

        private ContactVmi CreateContact(string first, string last, string phone = "555-121266")
        {
            return new ContactVmi
            {
                Name = string.Format("{0} {1}", first, last),
                Email = string.Format("{0}.{1}@sampledata.org", first, last),
                Phone = phone
            };
        }
    }
}
