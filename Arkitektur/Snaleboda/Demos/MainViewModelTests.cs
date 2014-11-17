using System;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Test.Core;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snaleboda.Core.Interfaces;
using Snaleboda.Core.Services;
using Snaleboda.Core.ViewModels;

namespace Snaleboda.Tests
{
    [TestClass]
    public class MainViewModelTests
    : MvxIoCSupportingTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            //container = new UnityContainer();
            base.Setup();

            Ioc.RegisterType<IAsyncServiceAgent, AsyncServiceAgentFake>();
            Ioc.RegisterType<INewsViewModel, NewsViewModel>();
            Ioc.RegisterType<IContactsViewModel, ContactsViewModel>();
            Ioc.RegisterType<IMainViewModel, MainViewModel>();

            //var service = new AsyncServiceAgentFake();
            //var news = new NewsViewModel(service);
            //var contacts = new ContactsViewModel(service);

            //_viewModel = new MainViewModel(news, contacts);   
        }

        [TestMethod]
        public void CreateAndEverythingWillBeNotNull()
        {
            // Arrange
            var viewModel = Mvx.Resolve<IMainViewModel>();

            // Act

            // Assert
            Assert.IsNotNull(viewModel.News, "News should not be null");
            Assert.IsNotNull(viewModel.News.Items, "News.Items should not be null");

            Assert.IsNotNull(viewModel.Contacts, "Contacts should not be null");
            Assert.IsNotNull(viewModel.Contacts.Items, "Contacts.Items should not be null");
        }

        [TestMethod]
        public async Task AfterLoadContentShouldBeAvailable()
        {
            // Arrange
            var viewModel = Mvx.Resolve<IMainViewModel>();

            // Act
            await viewModel.LoadAsync();

            // Assert
            Assert.IsTrue(viewModel.News.Items.Count > 0, "No news available");
            Assert.IsTrue(viewModel.Contacts.Items.Count > 0, "No contacts available");
        }
    }
}
