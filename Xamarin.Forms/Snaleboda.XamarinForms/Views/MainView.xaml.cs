using Snaleboda.XamarinForms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snaleboda.XamarinForms.Views
{
    public partial class MainView
    {
        public MainView(NewsViewModel viewModel, NewsView newsView, ContactsView contactsView, IncidentView incidentView)
        {
            InitializeComponent();
            Children.Add(newsView);
            Children.Add(contactsView);
            Children.Add(incidentView);
        }
    }
}
